using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBackground {
    public class HoraNew {
        public int relogio { get; set; }
        public string hora { get; set; }

        public HoraNew(int r, string h) {
            relogio = r;
            hora = h;
        }
    }
}
