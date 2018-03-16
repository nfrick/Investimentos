namespace DataLayer {
    public partial class OperacaoCotacao {
        private const decimal TaxaNegociacao = 0.004657m;
        private const decimal TaxaLiquidacao = 0.0275m;

        public int QtdDisponivel => Qtd - QtdVendida;

        public int QtdAntes => QtdAcumulada - Qtd;

        public decimal CustoOperacao => IncideTaxa ?
            20 + (Valor * (TaxaNegociacao + TaxaLiquidacao) / 100) : 0.0m;

        public decimal ValorComTaxas => (Valor * Qtd + CustoOperacao) / Qtd;

        public decimal ValorOperacaoComTaxas => Qtd * ValorComTaxas;

        public decimal CustoOperacaoReal => IncideTaxa ?
            20 + (ValorReal * (TaxaNegociacao + TaxaLiquidacao) / 100) : 0.0m;

        public decimal ValorComTaxasReal => (ValorReal * Qtd + CustoOperacao) / Qtd;

        public decimal ValorOperacaoComTaxasReal => Qtd * ValorComTaxasReal;
    }
}