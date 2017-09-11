using System;

namespace DataLayer {
    public partial class Venda {
        public DateTime Data => Compra?.Data ?? DateTime.Today;
        public decimal QtdComprada => Compra?.Qtd ?? 0;
        public decimal QtdDisponivel => Compra == null ? 0 : QtdComprada - QtdAssociada;
    }
}