namespace DataLayer {
    public partial class OperacaoCotacao {
        public int QtdDisponivel => Qtd - QtdVendida;
    }
}