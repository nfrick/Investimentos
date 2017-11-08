using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer {

    public class AlphaVantage {
        [JsonProperty(PropertyName = "Meta Data")]
        public Header MetaData { get; set; }

        [JsonProperty(PropertyName = "Time Series (1min)")]
        public Dictionary<DateTime, StockInfo> TimeSeries1 { get; set; }

        [JsonProperty(PropertyName = "Time Series (5min)")]
        public Dictionary<DateTime, StockInfo> TimeSeries5 { get; set; }

        public Dictionary<DateTime, StockInfo> TimeSeries => TimeSeries5?.ToDictionary(c => EasternToLocalTime(c.Key), c => c.Value) ?? TimeSeries1.ToDictionary(c => EasternToLocalTime(c.Key), c => c.Value);

        public static DateTime EasternToLocalTime(DateTime easternTime) {
            var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var timeUTC = TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone);
            return timeUTC.ToLocalTime();
        }
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
