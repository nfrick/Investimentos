using System;

namespace DataLayer {
    public static class Extensions {
        public static DateTime RoundToMinutes(this DateTime dt) {
            var ticks = dt.Ticks;
            return new DateTime(ticks - (ticks % (1000 * 1000 * 10 * 60)));
        }
    }
}