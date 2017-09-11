using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer {
    public partial class AtivoCotacao {
        private Cotacao _cotacao;
        private Dictionary<DateTime, decimal> _newerTrades;
        private Dictionary<DateTime, decimal> _olderTrades;
        private bool _jaNegociado;
        private int? _qtdTotal;
        private List<OperacaoCotacao> _operacoes;

        public const string TrendUp = "é";
        public const string TrendDown = "ê";
        public const string TrendNeutral = "l";
        public const string TrendNone = "¡";

        public void Initialize(Dictionary<string, Cotacao> cotacoes, int contaId) {
            SetarConta(contaId);
            _newerTrades = new Dictionary<DateTime, decimal>();
            _olderTrades = new Dictionary<DateTime, decimal>();
            AtualizarCotacao(cotacoes);
        }

        public void SetarConta(int contaId) {
            _operacoes = Operacoes.Where(o => o.ContaId == contaId).ToList();
            _jaNegociado = _operacoes.Any();
            _qtdTotal = _jaNegociado ? _operacoes.Last().QtdAcumulada : 0;
        }

        public void AtualizarCotacao(Dictionary<string, Cotacao> cotacoes) {
            if (!cotacoes.ContainsKey(Codigo))
                return;
            if (_cotacao != null && !_newerTrades.ContainsKey(_cotacao.LastTradeDate))
                _newerTrades.Add(_cotacao.LastTradeDate, _cotacao.LastTrade);
            _cotacao = cotacoes[Codigo];
        }

        public void PackTrades(bool forcePack) {
            if (!_newerTrades.Any())
                return;
            var last = forcePack ? DateTime.Now : _newerTrades.Last().Key.RoundToMinutes().AddMinutes(-3);
            if (!_newerTrades.Any(x => x.Key < last))
                return;

            var packedTrades =
                from trade in _newerTrades
                let minute = trade.Key.RoundToMinutes()
                where minute < last
                group trade by minute into tradeGroup
                select new KeyValuePair<DateTime, decimal>(tradeGroup.Key,
                    tradeGroup.Average(p => p.Value));

            _newerTrades = _newerTrades.Where(x => x.Key >= last).ToDictionary(x => x.Key, x => x.Value);
            foreach (var trade in packedTrades) {
                _olderTrades.Add(trade.Key, trade.Value);
            }
        }

        public bool JaNegociado => _jaNegociado;

        public bool Corrente => _qtdTotal > 0;

        public int? QtdTotal => _qtdTotal;

        private IEnumerable<OperacaoCotacao> Vendaveis => _operacoes.Where(o => o.QtdDisponivel > 0 && o.ValorReal < LastTrade);

        public int QtdVendavel => _qtdTotal == 0 ? 0 : Vendaveis.Sum(o => o.QtdDisponivel);

        public decimal VMVendavel => QtdVendavel == 0 ? 0 : Vendaveis.Sum(o => o.QtdDisponivel * o.ValorReal) / QtdVendavel;

        public decimal? LucroImediato => QtdVendavel * (LastTrade - VMVendavel);

        public decimal ValorMedioCompra => _valorMedioCompra(false);

        public decimal ValorMedioCompraReal => _valorMedioCompra(true);

        private decimal _valorMedioCompra(bool real) =>
            QtdTotal == 0 ? 0 :
                _operacoes
                    .OrderByDescending(o => o.Data)
                    .ThenByDescending(o => o.OperacaoId)
                    .TakeWhile(o => o.QtdAcumulada > 0)
                    .Where(o => o.Qtd > 0)
                    .Select(o => new { o.Qtd, Valor = o.Qtd * (real ? o.ValorReal : o.Valor) })
                    .Aggregate(new { SumQtd = 0, ValorTotal = 0.0m }, (a, o) => new { SumQtd = a.SumQtd + o.Qtd, ValorTotal = a.ValorTotal + o.Valor },
                        a => a.SumQtd == 0 ? 0 : a.ValorTotal / a.SumQtd);

        public decimal Patrimonio => LastTrade == null ? 0 : (decimal)LastTrade * (int)_qtdTotal;

        public decimal Lucro => LastTrade == null ? 0 : ((decimal)LastTrade - ValorMedioCompra) * (int)_qtdTotal;

        public decimal LucroReal => LastTrade == null ? 0 : ((decimal)LastTrade - ValorMedioCompraReal) * (int)_qtdTotal;

        public bool HasTrades => Trades != null && Trades.Any();

        public Dictionary<DateTime, decimal> Trades => _olderTrades.Union(_newerTrades).ToDictionary(k => k.Key, v => v.Value);

        public decimal? Bid => _cotacao?.Bid;

        public decimal? Ask => _cotacao?.Ask;

        public decimal? Open => _cotacao?.Open;

        public decimal? PreviousClose => _cotacao?.PreviousClose;

        public decimal? LastTrade => _cotacao?.LastTrade;

        public DateTime? LastTradeDate => _cotacao?.LastTradeDate;

        public decimal? PreviousTrade => (decimal?)Trades.LastOrDefault().Value;

        public double MaxTrade => HasTrades ? (double)Math.Max((decimal)LastTrade, Trades.Max(s => s.Value)) : 0;

        public double MinTrade => HasTrades ? ((double)Math.Min((decimal)LastTrade, Trades.Min(s => s.Value)) - 0.01) : 50;

        public string Trend {
            get {
                if (LastTrade == null || PreviousTrade == 0)
                    return TrendNone;
                return LastTrade > PreviousTrade ? TrendUp :
                    (LastTrade < PreviousTrade ? TrendDown :
                        TrendNeutral);
            }
        }

        public decimal? DayLow => _cotacao?.DayLow;

        public decimal? DayHigh => _cotacao?.DayHigh;

        public decimal? Change => _cotacao?.Change;

        public decimal? ChangePercent => _cotacao?.ChangePercent;

        public decimal? Week52Low => _cotacao?.Week52Low;

        public decimal? Week52High => _cotacao?.Week52High;
    }
}