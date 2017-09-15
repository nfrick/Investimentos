using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer {
    public partial class Saida {
        
        //public int QtdComprada => Entradas == null ? 0 : Entradas.Sum(e => e.QtdAssociada) ?? 0;
        //public int QtdPendente => -1 * (QtdReal - QtdComprada);
        //public decimal ValorMedioCompra => _ValorMedioCompra(false);
        //public decimal ValorMedioCompraReal => _ValorMedioCompra(true);
        //public decimal Lucro => QtdReal * (ValorMedioCompra - Valor);
        //public decimal LucroReal => QtdReal * (ValorMedioCompraReal - Valor);
        //private decimal _ValorMedioCompra(bool real) {
        //    if (QtdComprada == 0) return 0;
        //    var total = Entradas.Sum(c => c.QtdAssociada * (real ? c.ValorReal : c.Valor));
        //    return (total ?? 0) / QtdComprada;
        //}
    }
}
