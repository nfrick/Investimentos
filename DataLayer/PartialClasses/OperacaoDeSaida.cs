using System;
using System.Linq;

namespace DataLayer {
    public partial class OperacaoDeSaida {
        public int QtdAntes => QtdAcumulada - Qtd;

        public int QtdComprada => Venda.Sum(c => c.QtdAssociada);

        public int QtdPendente => -1 * (Qtd + QtdComprada);

        private Decimal _VMCompra(bool real) {
            if (QtdComprada == 0) return 0;
            var total = Venda.Sum(c => c.QtdAssociada * (real ? c.Compra.ValorReal : c.Compra.Valor));
            return total / QtdComprada;
        }

        public decimal VMCompra => _VMCompra(false);
        public decimal VMCompraReal => _VMCompra(true);
        public decimal Lucro => Qtd * (VMCompra - Valor);
        public decimal LucroReal => Qtd * (VMCompraReal - Valor);
    }
}