using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace DataLayer {

    public partial class Conta {

        public string ContaEdicao {
            get => ContaCorrente.PadLeft(6);
            set => ContaCorrente = value.Trim();
        }
        public decimal LucroTotal => Saidas.Sum(o => o.Lucro);
        public decimal LucroTotalReal => Saidas.Sum(o => o.LucroReal);
    }
}
