using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DataLayer {
    public partial class Ativo {
        public override string ToString() {
            return Codigo;
        }
    }

    public partial class OperacaoTipo {
        public override string ToString() {
            return Tipo;
        }
    }

    public partial class Operacao {
        public int Qtd => QtdReal * (OperacaoTipo.SinalPositivo ? 1 : -1);
    }

    public partial class AtivoCorrente {

        public decimal ValorMedioCompra => _valorMedioCompra(false);

        public decimal ValorMedioCompraReal => _valorMedioCompra(true);

        private decimal _valorMedioCompra(bool real) {
            var compras = OperacoesTodas
                        .OrderByDescending(c => c.Data)
                        .ThenByDescending(c => c.OperacaoId)
                        .TakeWhile(c => c.QtdAcumulada > 0).
                        Where(c => c.Qtd > 0).ToArray();
            var qtd = ((decimal)compras.Sum(c => c.Qtd));
            return qtd == 0 ? 0 : compras.Sum(c => (decimal)c.Qtd * (real ? c.ValorReal : c.Valor)) / qtd;
        }
    }

    public partial class OperacaoDeSaida {
        public int QtdAntes => QtdAcumulada - Qtd;

        public int QtdComprada => Venda.Sum(c => c.QtdAssociada);

        public int QtdPendente => -1 * (Qtd + QtdComprada);

        private Decimal _VMCompra(bool real) {
            if (QtdComprada == 0) return 0;
            var total = Venda.Sum(c => c.QtdAssociada * (real ? c.Compra.ValorReal : c.Compra.Valor));
            return total / QtdComprada;
        }

        public decimal VMCompra => _VMCompra(false);
        public decimal VMCompraReal => _VMCompra(true);
        public decimal Lucro => Qtd * (VMCompra - Valor);
        public decimal LucroReal => Qtd * (VMCompraReal - Valor);
    }

    public partial class Venda {
        public DateTime Data => Compra?.Data ?? DateTime.Today;
        public decimal QtdComprada => Compra?.Qtd ?? 0;
        public decimal QtdDisponivel => Compra == null ? 0 : QtdComprada - QtdAssociada;
    }

    public partial class CompraDisponivelParaVenda {
        public int QtdDisponivel => QtdComprada - QtdVendida;
    }

    public partial class SerieHistorica {
        public static CultureInfo Culture { get; } = CultureInfo.CreateSpecificCulture("en-US");

        /// <summary>
        /// Lê arquivo e retorna uma lista
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns>List<SerieHistorica></returns>
        public static List<SerieHistorica> LerArquivo(string arquivo) {
            using (var ctx = new InvestimentosEntities()) {
                var maxData = ctx.SeriesHistoricas.Max(c => c.Data).ToString("yyyyMMdd");
                var serie = from linha in File.ReadLines(arquivo)
                            join ativo in ctx.Ativos
                            on linha.Substring(12, 12).Trim() equals ativo.Codigo
                            where linha.StartsWith("01")
                                 && linha.Substring(24, 3) == "010"
                                 && string.Compare(linha.Substring(2, 8), maxData, StringComparison.Ordinal) > 0
                            select new SerieHistorica(linha);
                return serie.ToList();
            }
        }

        /// <summary>
        /// Lê arquivo e grava no banco de dados
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns>Número de registros gravados</returns>
        public static long LerArquivoParaDatabase(string arquivo) {
            long recordsAdded;
            using (var ctx = new InvestimentosEntities()) {
                var serie = LerArquivo(arquivo);
                recordsAdded = serie.Count;
                ctx.SeriesHistoricas.AddRange(serie);
                ctx.SaveChanges();
            }
            return recordsAdded;
        }

        public SerieHistorica() {
        }
        public SerieHistorica(string linha) {

            Data = DateTime.ParseExact(linha.Substring(2, 8), "yyyyMMdd",
                CultureInfo.InvariantCulture, DateTimeStyles.None);
            Codigo = linha.Substring(12, 12).Trim();
            PrecoAbertura = Convert.ToDecimal(linha.Substring(56, 13)) / 100;
            PrecoMaximo = Convert.ToDecimal(linha.Substring(69, 13)) / 100;
            PrecoMinimo = Convert.ToDecimal(linha.Substring(82, 13)) / 100;
            PrecoMedio = Convert.ToDecimal(linha.Substring(95, 13)) / 100;
            PrecoUltimo = Convert.ToDecimal(linha.Substring(108, 13)) / 100;
            PrecoMelhorOfertaCompra = Convert.ToDecimal(linha.Substring(121, 13)) / 100;
            PrecoMelhorOfertaVenda = Convert.ToDecimal(linha.Substring(134, 13)) / 100;
        }
    }

    public class Cotacao {
        enum YahooCols {
            codigo,
            nome,
            bid,
            bidRT,
            ask,
            askRT,
            open,
            previousClose,
            lastTrade,
            lastTradeDate,
            lastTradeTime,
            dayLow,
            dayHigh,
            change,
            changeRT,
            changePercent,
            changePercentRT,
            Week52Low,
            Week52High
        }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Open { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal LastTrade { get; set; }
        public DateTime LastTradeDate { get; set; }
        public decimal DayLow { get; set; }
        public decimal DayHigh { get; set; }
        public decimal Change { get; set; }
        public decimal ChangePercent { get; set; }
        public decimal Week52Low { get; set; }
        public decimal Week52High { get; set; }

        private static char[] _trimchars = { '"', ' ', '%' };
        private static NumberStyles _style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        private static CultureInfo _culture = CultureInfo.CreateSpecificCulture("en-US");
        private static string[] _cols;

        public static bool CotacaoValida(string row) {
            if (string.IsNullOrEmpty(row)) return false;
            _cols = row.Replace("N/A", string.Empty).Split(',');
            var nome = String.Join(" ", _cols[(int)YahooCols.nome].Trim(_trimchars).Split(_trimchars).Where(x => !string.IsNullOrEmpty(x)).ToArray());
            return nome != string.Empty;
        }

        public static string Codigo => _cols[(int)YahooCols.codigo].Substring(1, 5);

        public Cotacao() {
            Bid = StringToDecimal(_cols[(int)YahooCols.bid]);
            Ask = StringToDecimal(_cols[(int)YahooCols.ask]);
            Open = StringToDecimal(_cols[(int)YahooCols.open]);
            PreviousClose = StringToDecimal(_cols[(int)YahooCols.previousClose]);
            LastTrade = StringToDecimal(_cols[(int)YahooCols.lastTrade]);
            //LastTradeDate = Convert.ToDateTime((_cols[(int)yahooCols.lastTradeDate] +
            //    " " + _cols[(int)yahooCols.lastTradeTime])
            //    .Replace("\"", string.Empty), _culture);
            LastTradeDate = DateTime.Now.AddMinutes(-16);
            DayLow = StringToDecimal(_cols[(int)YahooCols.dayLow]);
            DayHigh = StringToDecimal(_cols[(int)YahooCols.dayHigh]);
            Change = StringToDecimal(_cols[(int)YahooCols.change]);
            ChangePercent = StringToDecimal(_cols[(int)YahooCols.changePercent].Trim(_trimchars)) / 100;
            Week52Low = StringToDecimal(_cols[(int)YahooCols.Week52Low]);
            Week52High = StringToDecimal(_cols[(int)YahooCols.Week52High]);
        }

        private static decimal StringToDecimal(string v) {
            return (decimal.TryParse(v, _style, _culture, out decimal x)) ? x : -1;
        }
    }

    public partial class OperacaoCotacao {
        public int QtdDisponivel => Qtd - QtdVendida;
    }

    public partial class AtivoCotacao {
        private Cotacao _cotacao;
        private Dictionary<DateTime, decimal> _newerTrades;
        private Dictionary<DateTime, decimal> _olderTrades;
        private bool _jaNegociado;
        private int? _qtdTotal;

        public const string TrendUp = "é";
        public const string TrendDown = "ê";
        public const string TrendNeutral = "l";
        public const string TrendNone = "¡";

        public void Initialize(Dictionary<string, Cotacao> cotacoes) {
            _jaNegociado = Operacoes.Any();
            _qtdTotal = _jaNegociado ? Operacoes.Last().QtdAcumulada : 0;
            _newerTrades = new Dictionary<DateTime, decimal>();
            _olderTrades = new Dictionary<DateTime, decimal>();
            AtualizarCotacao(cotacoes);
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

        private IEnumerable<OperacaoCotacao> Vendaveis => Operacoes.Where(o => o.QtdDisponivel > 0 && o.ValorReal < LastTrade);

        public int QtdVendavel => _qtdTotal == 0 ? 0 : Vendaveis.Sum(o => o.QtdDisponivel);

        public decimal VMVendavel => QtdVendavel == 0 ? 0 : Vendaveis.Sum(o => o.QtdDisponivel * o.ValorReal) / QtdVendavel;

        public decimal? LucroImediato => QtdVendavel * (LastTrade - VMVendavel);

        public decimal ValorMedioCompra => _valorMedioCompra(false);

        public decimal ValorMedioCompraReal => _valorMedioCompra(true);

        private decimal _valorMedioCompra(bool real) =>
            QtdTotal == 0 ? 0 :
                Operacoes
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

        public decimal? PreviousTrade => HasTrades ? (decimal?)_newerTrades.Last().Value : null;

        public double MaxTrade => HasTrades ? (double)Math.Max((decimal)LastTrade, Trades.Max(s => s.Value)) : 0;

        public double MinTrade => HasTrades ? ((double)Math.Min((decimal)LastTrade, Trades.Min(s => s.Value)) - 0.01) : 50;

        public string Trend {
            get {
                if (LastTrade == null || PreviousTrade == null)
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

    public static class Extensions {
        public static DateTime RoundToMinutes(this DateTime dt) {
            var ticks = dt.Ticks;
            return new DateTime(ticks - (ticks % (1000 * 1000 * 10 * 60)));
        }
    }

    public class AtivoCotacaoTotal {
        public string Col0 { get; set; }
        public decimal? Col1 { get; set; }
        public decimal? Col2 { get; set; }
        public decimal? Col3 { get; set; }
        public decimal? Col4 { get; set; }
        public decimal? Col5 { get; set; }
        public decimal? Col6 { get; set; }
        public decimal? Col7 { get; set; }
        public decimal? Col8 { get; set; }
        public decimal? Col9 { get; set; }
        public decimal? Col10 { get; set; }
        public decimal? Col11 { get; set; }
        public decimal? Col12 { get; set; }
        public decimal? Col13 { get; set; }
        public decimal? Col14 { get; set; }
        public decimal? Col15 { get; set; }
        public decimal? Col16 { get; set; }
        public decimal? Col17 { get; set; }
        public decimal? Col18 { get; set; }

        public static List<AtivoCotacaoTotal> New(IReadOnlyCollection<AtivoCotacao> cotacoes) {
            var lista = new List<AtivoCotacaoTotal>();
            lista.Add(new AtivoCotacaoTotal(cotacoes));
            return lista;

        }
        public AtivoCotacaoTotal(IReadOnlyCollection<AtivoCotacao> cotacoes) {
            Col0 = "TOTAL";
            Col2 = cotacoes.Sum(c => c.Patrimonio);
            Col16 = cotacoes.Sum(c => c.LucroReal);
            Col18 = cotacoes.Sum(c => c.LucroImediato);

            Col1 = null;
            Col3 = null;
            Col4 = null;
            Col5 = null;
            Col6 = null;
            Col7 = null;
            Col8 = null;
            Col9 = null;
            Col10 = null;
            Col11 = null;
            Col12 = null;
            Col13 = null;
            Col14 = null;
            Col15 = null;
            Col17 = null;
        }
    }


}
