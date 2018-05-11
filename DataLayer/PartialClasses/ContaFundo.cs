using System.Collections.Specialized;
using System.Linq;

namespace DataLayer {
    public partial class ContaFundo {
        public override string ToString() {
            return FundoNome;
        }

        public string FundoNome => Fundo.Nome;

        public string FundoCNPJ => Fundo.CNPJ;

        public decimal Saldo =>
            ContasMeses.Count == 0 ? 0.0m : 
            ContasMeses.OrderByDescending(cm => cm.FundoMes.Mes).First().Saldo;

        public decimal RendimentoBruto =>
            ContasMeses.Sum(cm => cm.RendimentoBruto);

        public decimal ImpostoRenda =>
            ContasMeses.Sum(cm => cm.ImpostoRenda);

        public decimal RendimentoLiquido =>
            RendimentoBruto - ImpostoRenda;
    }
}