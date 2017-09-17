using System.Linq;

namespace DataLayer {
    public partial class Operacao {
        public bool IsEntrada => OperacaoTipo.SinalPositivo;

        public bool IsSaida => !OperacaoTipo.SinalPositivo;

        public int QtdComSinal => QtdReal * OperacaoTipo.Sinal;

        public int QtdAcumulada => AtivoDaConta?.Operacoes.Where(o => o.Data <= Data).Sum(o => o.QtdComSinal) ?? 0;

        public int QtdAntes => AtivoDaConta?.Operacoes.Where(o => o.Data < Data).Sum(o => o.QtdComSinal) ?? 0;

        public Entrada ToEntrada => new Entrada() {
            OperacaoId = this.OperacaoId,
            ContaId = this.ContaId,
            Codigo = this.Codigo,
            TipoId = this.TipoId,
            Data = this.Data,
            QtdPrevista = this.QtdPrevista,
            QtdReal = this.QtdReal,
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
            QtdPrevista = this.QtdPrevista,
            QtdReal = this.QtdReal,
            Valor = this.Valor,
            ValorReal = this.ValorReal,
            OperacaoTipo = this.OperacaoTipo,
            AtivoDaConta = this.AtivoDaConta
        };
    }
}