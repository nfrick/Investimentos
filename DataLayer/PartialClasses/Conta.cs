using System.Linq;

namespace DataLayer {

    public partial class Conta {
        public decimal LucroTotal => Saidas.Sum(o => o.Lucro);
        public decimal LucroTotalReal => Saidas.Sum(o => o.LucroReal);
    }
}
