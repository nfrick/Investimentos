using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace DataLayer {
    public partial class AtivoCotacao {
        public SortedDictionary<DateTime, StockInfo> Cotacoes = new SortedDictionary<DateTime, StockInfo>();
        private IEnumerable<OperacaoCotacao> _operacoes;

        public const string TrendUp = "é";
        public const string TrendDown = "ê";
        public const string TrendNeutral = "l";
        public const string TrendNone = "¡";

        public void SetarConta(int contaId) {
            _operacoes = Operacoes.Where(o => o.ContaId == contaId);
        }

        public void AtualizarCotacao(bool reset = false) {
            var offTime = DateTime.Now.Hour < 10 || DateTime.Now.Hour >= 17;
            if (reset || offTime)
                Cotacoes.Clear();

            if (offTime) {
                var cotacao5 = ObterCotacao(5);
                if (cotacao5 == null) return;
                var serie = cotacao5.TimeSeries;
                var data = serie.ElementAt(0).Key.Date;
                foreach (var cot in serie.Where(c => c.Key.Date == data)) {
                    Cotacoes.Add(cot.Key, cot.Value);
                }
            }
            else {
                var cotacao1 = ObterCotacao(1);
                if (cotacao1 == null) return;
                var serie = cotacao1.TimeSeries.Take(60);
                if (!Cotacoes.Any()) {
                    var horaInicio = DateTime.Today + new TimeSpan(10, 0, 0);
                    var maisAntigo = serie.Last().Key;
                    if (maisAntigo.CompareTo(horaInicio) < 0) {
                        var fechamento = serie
                            .First(c => c.Key.CompareTo(horaInicio) <= 0);
                        Cotacoes.Add(horaInicio, fechamento.Value);
                    }
                    else {
                        var cotacao5 = ObterCotacao(5);
                        if (cotacao5 != null) {
                            var fechamento = cotacao5.TimeSeries
                                .First(c => c.Key.CompareTo(horaInicio) <= 0);
                            if (!Cotacoes.ContainsKey(horaInicio))
                                Cotacoes.Add(horaInicio, fechamento.Value);
                            foreach (var cot in cotacao5.TimeSeries
                                .SkipWhile(c => c.Key.CompareTo(maisAntigo) > 0)
                                .TakeWhile(c => c.Key.CompareTo(horaInicio) > 0)) {
                                if (!Cotacoes.ContainsKey(cot.Key))
                                    Cotacoes.Add(cot.Key, cot.Value);
                            }
                        }
                    }
                }
                var maisRecente = Cotacoes.Last().Key;
                foreach (var cot in serie.TakeWhile(c => c.Key.CompareTo(maisRecente) > 0)) {
                    Cotacoes.Add(cot.Key, cot.Value);
                }
            }
        }

        public AlphaVantage ObterCotacao(int interval) {
            var request = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={Codigo}.SA&interval={interval}min&apikey=5M72TGSVJXVYAO5W";

            using (var web = new WebClient()) {
                try {
                    AlphaVantage cotacao;
                    do {
                        var json = web.DownloadString(request);
                        cotacao = JsonConvert.DeserializeObject<AlphaVantage>(json);
                    } while (cotacao.MetaData == null);
                    return cotacao;
                }
                catch (System.Net.WebException ex) {
                    return null;
                }
            }
        }

        public bool JaNegociado => _operacoes.Any();

        public bool Corrente => QtdTotal > 0;

        public int QtdTotal => JaNegociado ? _operacoes.Last().QtdAcumulada : 0;

        private IEnumerable<OperacaoCotacao> Vendaveis => _operacoes.Where(o => o.QtdDisponivel > 0 && o.ValorReal < LastTrade);

        public int QtdVendavel => QtdTotal == 0 ? 0 : Vendaveis.Sum(o => o.QtdDisponivel);

        public decimal VMVendavel => QtdVendavel == 0 ? 0 : Vendaveis.Sum(o => o.QtdDisponivel * o.ValorReal) / QtdVendavel;

        public decimal? LucroImediato => QtdVendavel * (LastTrade - VMVendavel);

        public decimal ValorMedioCompra => _valorMedioCompra(false);

        public decimal ValorMedioCompraReal => _valorMedioCompra(true);

        public decimal? AlertaVenda => LastTrade == 0 ? 10m : LastTrade / ValorMedioCompraReal;

        private decimal _valorMedioCompra(bool real) =>
            !JaNegociado ? 0 :
                _operacoes
                    .OrderByDescending(o => o.Data)
                    .ThenByDescending(o => o.OperacaoId)
                    .TakeWhile(o => o.QtdAcumulada > 0)
                    .Where(o => o.Qtd > 0)
                    .Select(o => new { o.Qtd, Valor = o.Qtd * (real ? o.ValorReal : o.Valor) })
                    .Aggregate(new { SumQtd = 0, ValorTotal = 0.0m }, (a, o) => new { SumQtd = a.SumQtd + o.Qtd, ValorTotal = a.ValorTotal + o.Valor },
                        a => a.SumQtd == 0 ? 0 : a.ValorTotal / a.SumQtd);

        public decimal Patrimonio => LastTrade * QtdTotal;

        public decimal Lucro => (LastTrade - ValorMedioCompra) * QtdTotal;

        public decimal LucroReal => ((decimal)LastTrade - ValorMedioCompraReal) * QtdTotal;

        public bool HasTrades => Cotacoes.Any();

        public decimal? Open => HasTrades ? (decimal?)Cotacoes.First().Value.open : 0;

        public decimal? PreviousClose => HasTrades ? (decimal?)Cotacoes.ElementAt(0).Value.close : 0;

        public decimal LastTrade => HasTrades ? Cotacoes.Last().Value.close : 0;

        public DateTime? LastTradeDate => HasTrades ? (DateTime?)Cotacoes.Last().Key : null;

        public decimal? PreviousTrade => Cotacoes.Count > 1 ? (decimal?)Cotacoes.ElementAt(Cotacoes.Count - 2).Value.close : 0;

        public string Trend {
            get {
                if (LastTrade == 0 || PreviousTrade == 0)
                    return TrendNone;
                return LastTrade > PreviousTrade ? TrendUp :
                    (LastTrade < PreviousTrade ? TrendDown :
                        TrendNeutral);
            }
        }

        public double DayLow => (double)(HasTrades ? Cotacoes.Min(c => c.Value.low) : 0);

        public double DayHigh => (double)(HasTrades ? Cotacoes.Max(c => c.Value.high) : 0);

        public decimal? Change => LastTrade - Open;

        public decimal? ChangePercent => HasTrades ? Change / Open : 0;
    }
}