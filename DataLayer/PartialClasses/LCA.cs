using System.Linq;

namespace DataLayer {
    public partial class LCA {
        public override string ToString() {
            return Numero;
        }

        public string Codigo => Numero.Substring(8);

        public decimal Saldo =>
            LCAMeses.Count == 0 ? 0.0m :
                LCAMeses.OrderByDescending(m => m.Mes).First().SaldoAtual;

        public decimal RendimentoLiquido =>
            LCAMeses.Sum(lcames => lcames.RendimentoLiquido);

        public decimal RendimentoPercentual =>
            RendimentoLiquido / ValorEmissao;

        public int Meses => (Vencimento.Month - Aplicacao.Month) + 12 * (Vencimento.Year - Aplicacao.Year);

        public decimal RendimentoMensal =>
            (RendimentoLiquido / ValorEmissao) / Meses;
    }
}
