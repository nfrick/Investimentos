using System;

namespace DataLayer {
    public partial class Associacao {
        public DateTime Data => Entrada?.Data ?? DateTime.Today;

        public string Tipo => Entrada?.OperacaoTipo.Tipo ?? string.Empty;

        public int QtdEntrada => Entrada?.QtdReal ?? 0;

        public int QtdSaida => Saida?.QtdReal ?? 0;

        public int QtdDisponivel => QtdEntrada - QtdAssociada;

        public decimal ValorReal => Entrada?.ValorReal ?? 0;
    }
}