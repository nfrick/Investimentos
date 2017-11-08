using System;
using System.Globalization;
using System.Linq;

namespace DataLayer {
    public class CotacaoYahoo {
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

        public CotacaoYahoo() {
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
}