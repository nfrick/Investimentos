using System.Linq;

namespace DataLayer {
    public partial class Operacao {
        private const decimal TaxaNegociacao = 0.004657m;
        private const decimal TaxaLiquidacao = 0.0275m;

        public bool IsEntrada => OperacaoTipo.SinalPositivo;

        public bool IsSaida => !OperacaoTipo.SinalPositivo;

        public int QtdComSinal => Qtd * OperacaoTipo.Sinal;

        public bool IncideTaxa => OperacaoTipo.IncideTaxa;

        public int QtdAcumulada => AtivoDaConta?.Operacoes.Where(o => o.Data <= Data).Sum(o => o.QtdComSinal) ?? 0;

        public int QtdAntes => AtivoDaConta?.Operacoes.Where(o => o.Data < Data).Sum(o => o.QtdComSinal) ?? 0;

        public decimal ValorOperacao => Qtd * Valor;

        public decimal ValorOperacaoReal => Qtd * ValorReal;

        public decimal CustoOperacao => IncideTaxa ? 
            20 + (ValorOperacao * (TaxaNegociacao + TaxaLiquidacao) / 100) : 0.0m;

        public decimal CustoOperacaoReal => IncideTaxa ?
            20 + (ValorOperacaoReal * (TaxaNegociacao + TaxaLiquidacao) / 100) : 0.0m;

        public decimal ValorComTaxas => (ValorOperacao + CustoOperacao) / Qtd;

        public decimal ValorComTaxasReal => (ValorOperacaoReal + CustoOperacaoReal) / Qtd;

        public decimal ValorOperacaoComTaxas => Qtd * ValorComTaxas;

        public decimal ValorOperacaoComTaxasReal => Qtd * ValorComTaxasReal;

        public Entrada ToEntrada => new Entrada() {
            OperacaoId = this.OperacaoId,
            ContaId = this.ContaId,
            Codigo = this.Codigo,
            TipoId = this.TipoId,
            Data = this.Data,
            Qtd = this.Qtd,
            Valor = this.Valor,
            ValorReal = this.ValorReal,
            OperacaoTipo = this.OperacaoTipo,
            AtivoDaConta = this.AtivoDaConta
        };

        public Saida ToSaida => new Saida() {
            OperacaoId = this.OperacaoId,
            ContaId = this.ContaId,
            Codigo = this.Codigo,
            TipoId = this.TipoId,
            Data = this.Data,
            Qtd = this.Qtd,
            Valor = this.Valor,
            ValorReal = this.ValorReal,
            OperacaoTipo = this.OperacaoTipo,
            AtivoDaConta = this.AtivoDaConta
        };
    }
}