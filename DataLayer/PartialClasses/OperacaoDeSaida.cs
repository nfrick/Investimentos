using System;
using System.Linq;

namespace DataLayer {
    public partial class OperacaoComQtdAcumulada {
        //public int QtdAntes => QtdAcumulada - Qtd;

        //public int QtdAssociada => Venda.Sum(c => c.QtdAssociada);

        //public int QtdPendente => -1 * (Qtd + QtdAssociada);

        //private Decimal _VMCompra(bool real) {
        //    if (QtdAssociada == 0) return 0;
        //    var total = Venda.Sum(c => c.QtdAssociada * (real ? c.Compra.ValorReal : c.Compra.Valor));
        //    return total / QtdAssociada;
        //}

        //public decimal VMCompra => _VMCompra(false);
        //public decimal VMCompraReal => _VMCompra(true);
        //public decimal Lucro => Qtd * (VMCompra - Valor);
        //public decimal LucroReal => Qtd * (VMCompraReal - Valor);
    }
}