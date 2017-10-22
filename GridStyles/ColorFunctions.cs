using System;
using System.Drawing;

namespace GridAndChartStyleLibrary {
    public class ColorFunctions {
        public static int PerceivedBrightness(Color c) {
            return (int)Math.Sqrt(
                c.R * c.R * .299 +
                c.G * c.G * .587 +
                c.B * c.B * .114);
        }

        public static Color ContrastColor(Color c) {
            return PerceivedBrightness(c) < 120 ? Color.White : Color.Black;
        }
    }
}
