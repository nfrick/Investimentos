using System.Collections.Specialized;
using System.Linq;

namespace DataLayer {
    public partial class ContaFundo {
        public override string ToString() {
            return FundoNome;
        }

        public string FundoNome => Fundo.Nome;

        public decimal SaldoAtual =>
            Resultados.OrderByDescending(r => r.Mes).First().SaldoAtual;
    }
}