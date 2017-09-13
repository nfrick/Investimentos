using System.Linq;

namespace DataLayer {
    public partial class AtivoDaConta {
        public decimal ValorMedioCompra => _valorMedioCompra(false);

        public decimal ValorMedioCompraReal => _valorMedioCompra(true);

        private decimal _valorMedioCompra(bool real) {
            var compras = OperacoesComQtdAcumulada
                .OrderByDescending(c => c.Data)
                .ThenByDescending(c => c.OperacaoId)
                .TakeWhile(c => c.QtdAcumulada > 0).
                Where(c => c.Qtd > 0).ToArray();
            var qtd = ((decimal)compras.Sum(c => c.Qtd));
            return qtd == 0 ? 0 : compras.Sum(c => (decimal)c.Qtd * (real ? c.ValorReal : c.Valor)) / qtd;
        }
    }
}