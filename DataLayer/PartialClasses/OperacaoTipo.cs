namespace DataLayer {
    public partial class OperacaoTipo {
        public override string ToString() {
            return Tipo;
        }

        public bool IsSaida => !SinalPositivo;

        public bool IsEntrada => SinalPositivo;

        public int Sinal => SinalPositivo ? 1 : -1;
    }
}