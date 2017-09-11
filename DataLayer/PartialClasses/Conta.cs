using System.Linq;

namespace DataLayer {

    public partial class Conta {
        public decimal LucroTotal => OperacoesDeSaida.Sum(o => o.Lucro);
        public decimal LucroTotalReal => OperacoesDeSaida.Sum(o => o.LucroReal);
    }
}
