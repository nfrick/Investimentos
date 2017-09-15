using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer {
    public partial class Saida {
        
        public int QtdComprada => Associacoes?.Sum(e => e.QtdAssociada) ?? 0;
        public int QtdPendente => QtdReal - QtdComprada;
        public decimal ValorMedioCompra => _ValorMedioCompra(false);
        public decimal ValorMedioCompraReal => _ValorMedioCompra(true);
        public decimal Lucro => QtdReal * (ValorMedioCompra - Valor);
        public decimal LucroReal => QtdReal * (ValorMedioCompraReal - Valor);

        private decimal _ValorMedioCompra(bool real) {
            if (QtdComprada == 0) return 0;
            var total = Associacoes.Sum(a => a.QtdAssociada * (real ? a.Entrada.ValorReal : a.Entrada.Valor));
            return (total) / QtdComprada;
        }
    }
}
