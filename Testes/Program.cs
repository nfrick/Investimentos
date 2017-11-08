using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Testes {
    class Program {
        static void Main(string[] args) {

            var acoes = new List<Acao>
            {
                new Acao {Codigo = "BRFS3.SA"},
                new Acao {Codigo = "BBAS3.SA"},
                new Acao {Codigo = "VALE3.SA"}
            };

            var sw = Stopwatch.StartNew();
            Parallel.ForEach(acoes, (acao) =>
            {
                Console.WriteLine(acao.Codigo);
                acao.Atualiza();
            });
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            foreach (var acao in acoes) {
                Console.Write(acao.Codigo);
                if (acao.Cotacoes.Any())
                    Console.WriteLine($"  {acao.Cotacoes.ElementAt(0).Value.volume}");
                else {
                    Console.WriteLine("  no data");
                }
            }

            Console.WriteLine(@"Done.");
            Console.ReadLine();
        }
    }

    public static class Converter {
        public static DateTime ToLocalTime(DateTime easternTime) {
            var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var timeUTC = TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone);
            return timeUTC.ToLocalTime();
        }
    }

    public class Acao {
        public string Codigo { get; set; }
        public SortedDictionary<DateTime, StockInfo> Cotacoes = new SortedDictionary<DateTime, StockInfo>();

        //public List<CotacaoYahoo> Cotacoes => _Cotacoes.Select(c => new CotacaoYahoo(c)).OrderBy(c => c.Data);

        public void Atualiza() {
            var mode = "";  // Cotacoes.Any() ? "" : "&outputsize=full";
            var request = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={Codigo}&interval=1min{mode}&apikey=5M72TGSVJXVYAO5W";
          
            AlphaVantage cotacao;
            using (var web = new WebClient()) {
                try {
                    do {
                        var json = web.DownloadString(request);
                        cotacao = JsonConvert.DeserializeObject<AlphaVantage>(json);
                    } while (cotacao.MetaData == null);
                }
                catch (System.Net.WebException ex) {
                    return;
                }
            }
            foreach (var cot in cotacao.TimeSeries) {
                var data = Converter.ToLocalTime(cot.Key);
                if (Cotacoes.ContainsKey(data)) // || data.Date != DateTime.Today)
                    break;
                Cotacoes.Add(data, cot.Value);
            }
        }
    }

    public class AlphaVantage {
        [JsonProperty(PropertyName = "Meta Data")]
        public Header MetaData { get; set; }

        [JsonProperty(PropertyName = "Time Series (1min)")]
        public Dictionary<DateTime, StockInfo> TimeSeries { get; set; }

        public DateTime? Data => Converter.ToLocalTime(MetaData.LastRefreshed);
    }

    public class Header {
        [JsonProperty(PropertyName = "1. Information")]
        public string Information { get; set; }

        [JsonProperty(PropertyName = "2. Symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "3. Last Refreshed")]
        public DateTime LastRefreshed { get; set; }

        [JsonProperty(PropertyName = "4. Interval")]
        public string Interval { get; set; }

        [JsonProperty(PropertyName = "5. Output Size")]
        public string OutputSize { get; set; }

        [JsonProperty(PropertyName = "6. Time Zone")]
        public string TimeZone { get; set; }
    }

    public class StockInfo {
        [JsonProperty(PropertyName = "1. open")]
        public decimal open { get; set; }

        [JsonProperty(PropertyName = "2. high")]
        public decimal high { get; set; }

        [JsonProperty(PropertyName = "3. low")]
        public decimal low { get; set; }

        [JsonProperty(PropertyName = "4. close")]
        public decimal close { get; set; }

        [JsonProperty(PropertyName = "5. volume")]
        public int volume { get; set; }
    }
}
