using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace DataLayer {
    public partial class AtivoCotacao {
        //private CotacaoYahoo _cotacaoYahoo;
        //private Dictionary<DateTime, decimal> _newerTrades;
        //private Dictionary<DateTime, decimal> _olderTrades;
        public SortedDictionary<DateTime, StockInfo> Cotacoes = new SortedDictionary<DateTime, StockInfo>();
        //private bool _jaNegociado;
        //private int? _qtdTotal;
        private List<OperacaoCotacao> _operacoes;

        public const string TrendUp = "é";
        public const string TrendDown = "ê";
        public const string TrendNeutral = "l";
        public const string TrendNone = "¡";

        public void Initialize(int contaId) {  //Dictionary<string, CotacaoYahoo> cotacoes, int contaId) {
            SetarConta(contaId);
            //_newerTrades = new Dictionary<DateTime, decimal>();
            //_olderTrades = new Dictionary<DateTime, decimal>();
            //AtualizarCotacao();  //cotacoes);
        }

        public void SetarConta(int contaId) {
            _operacoes = Operacoes.Where(o => o.ContaId == contaId).ToList();
            //_jaNegociado = _operacoes.Any();
            //_qtdTotal = JaNegociado ? _operacoes.Last().QtdAcumulada : 0;
        }

        public void AtualizarCotacao() {
            var cotacao1 = ObterCotacao(1);
            if (!Cotacoes.Any()) {
                var horaInicio = DateTime.Today + new TimeSpan(10, 0, 0);
                var maisAntigo = cotacao1.TimeSeries.Last().Key;
                if (maisAntigo.CompareTo(horaInicio) < 0) {
                    var fechamento = cotacao1.TimeSeries
                        .SkipWhile(c => c.Key.CompareTo(horaInicio) > 0).Take(1);
                    Cotacoes.Add(horaInicio, fechamento.ElementAt(0).Value);
                }
                else {
                    var cotacao5 = ObterCotacao(5);
                    var fechamento = cotacao5.TimeSeries
                        .SkipWhile(c => c.Key.CompareTo(horaInicio) > 0).Take(1);
                    Cotacoes.Add(horaInicio, fechamento.ElementAt(0).Value);
                    foreach (var cot in cotacao5.TimeSeries
                        .SkipWhile(c => c.Key.CompareTo(maisAntigo) > 0)
                        .TakeWhile(c => c.Key.CompareTo(horaInicio) > 0)) {
                        Cotacoes.Add(cot.Key, cot.Value);
                    }
                }
            }
            var maisRecente = Cotacoes.Last().Key;
            foreach (var cot in cotacao1.TimeSeries.TakeWhile(c => c.Key.CompareTo(maisRecente) > 0)) {
                Cotacoes.Add(cot.Key, cot.Value);
            }
        }

        public AlphaVantage ObterCotacao(int interval) {
            var request = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={Codigo}&interval={interval}min&apikey=5M72TGSVJXVYAO5W";

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

        public void PackTrades(bool forcePack) {
            //if (!_newerTrades.Any())
            //    return;
            //var last = forcePack ? DateTime.Now : _newerTrades.Last().Key.RoundToMinutes().AddMinutes(-3);
            //if (!_newerTrades.Any(x => x.Key < last))
            //    return;

            //var packedTrades =
            //    from trade in _newerTrades
            //    let minute = trade.Key.RoundToMinutes()
            //    where minute < last
            //    group trade by minute into tradeGroup
            //    select new KeyValuePair<DateTime, decimal>(tradeGroup.Key,
            //        tradeGroup.Average(p => p.Value));

            //_newerTrades = _newerTrades.Where(x => x.Key >= last).ToDictionary(x => x.Key, x => x.Value);
            //foreach (var trade in packedTrades) {
            //    _olderTrades.Add(trade.Key, trade.Value);
            //}
        }

        public bool JaNegociado => _operacoes.Any(); // _jaNegociado;

        public bool Corrente => QtdTotal > 0;

        public int QtdTotal => JaNegociado ? _operacoes.Last().QtdAcumulada : 0;  // _qtdTotal;

        private IEnumerable<OperacaoCotacao> Vendaveis => _operacoes.Where(o => o.QtdDisponivel > 0 && o.ValorReal < LastTrade);

        public int QtdVendavel => QtdTotal == 0 ? 0 : Vendaveis.Sum(o => o.QtdDisponivel);

        public decimal VMVendavel => QtdVendavel == 0 ? 0 : Vendaveis.Sum(o => o.QtdDisponivel * o.ValorReal) / QtdVendavel;

        public decimal? LucroImediato => QtdVendavel * (LastTrade - VMVendavel);

        public decimal ValorMedioCompra => _valorMedioCompra(false);

        public decimal ValorMedioCompraReal => _valorMedioCompra(true);

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

        public decimal Patrimonio => LastTrade == null ? 0 : (decimal)LastTrade * QtdTotal;

        public decimal Lucro => LastTrade == null ? 0 : ((decimal)LastTrade - ValorMedioCompra) * QtdTotal;

        public decimal LucroReal => LastTrade == null ? 0 : ((decimal)LastTrade - ValorMedioCompraReal) * QtdTotal;

        public bool HasTrades => Cotacoes.Any();  //Trades != null && Trades.Any();

        //public Dictionary<DateTime, decimal> Trades => Cotacoes.ToDictionary(c => c.Key, c => c.Value.close);
        //_olderTrades.Union(_newerTrades).ToDictionary(k => k.Key, v => v.Value);

        public decimal? Bid => -1; // _cotacaoYahoo?.Bid;

        public decimal? Ask => -1; //_cotacaoYahoo?.Ask;

        public decimal? Open => HasTrades ? (decimal?)Cotacoes.First().Value.open : 0; //_cotacaoYahoo?.Open;

        public decimal? PreviousClose => HasTrades ? (decimal?) Cotacoes.ElementAt(0).Value.close : 0;  //_cotacaoYahoo?.PreviousClose;

        public decimal? LastTrade => HasTrades ? Cotacoes.Last().Value.close : 0; //_cotacaoYahoo?.LastTrade;

        public DateTime? LastTradeDate => HasTrades ? (DateTime?)Cotacoes.Last().Key : null;  //_cotacaoYahoo?.LastTradeDate;

        public decimal? PreviousTrade => HasTrades ? (decimal?)Cotacoes.ElementAt(Cotacoes.Count - 2).Value.close : null;

        public double MaxTrade => (double)DayHigh;  //HasTrades ? (double)Math.Max((decimal)LastTrade, Trades.Max(s => s.Value)) : 0;

        public double MinTrade => (double)DayLow; //HasTrades ? ((double)Math.Min((decimal)LastTrade, Trades.Min(s => s.Value)) - 0.01) : 50;

        public string Trend {
            get {
                if (LastTrade == null || PreviousTrade == 0)
                    return TrendNone;
                return LastTrade > PreviousTrade ? TrendUp :
                    (LastTrade < PreviousTrade ? TrendDown :
                        TrendNeutral);
            }
        }

        public decimal DayLow => HasTrades ? Cotacoes.Min(c => c.Value.low) : 0; //_cotacaoYahoo?.DayLow;

        public decimal DayHigh => HasTrades ? Cotacoes.Max(c => c.Value.high) : 0; //_cotacaoYahoo?.DayHigh;

        public decimal? Change => -1; //_cotacaoYahoo?.Change;

        public decimal? ChangePercent => -1; //_cotacaoYahoo?.ChangePercent;

        public decimal? Week52Low => null; //_cotacaoYahoo?.Week52Low;

        public decimal? Week52High => null; //_cotacaoYahoo?.Week52High;
    }
}