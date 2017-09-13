using System.Collections.Generic;

namespace DataLayer {
    public partial class Operacao {
        public Operacao() {
            this.Associacoes = new HashSet<Associacao>();
        }

        public int OperacaoId { get; set; }
        public int ContaId { get; set; }
        public string Codigo { get; set; }
        public int TipoId { get; set; }
        public System.DateTime Data { get; set; }
        public int QtdPrevista { get; set; }
        public int QtdReal { get; set; }
        public int QtdAcumulada { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorReal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Associacao> Associacoes { get; set; }
        public virtual OperacaoTipo OperacaoTipo { get; set; }
        public virtual AtivoDaConta AtivoDaConta { get; set; }

        public Operacao(Entrada entrada) {
            OperacaoId = entrada.EntradaId;
            ContaId = entrada.ContaId;
            Codigo = entrada.Codigo;
            TipoId = entrada.TipoId;
            Data = entrada.Data;
            QtdPrevista = entrada.QtdPrevista;
            QtdReal = entrada.QtdReal;
            Valor = entrada.Valor;
            ValorReal = entrada.ValorReal;
            Associacoes = entrada.Associacoes;
            OperacaoTipo = entrada.OperacaoTipo;
            AtivoDaConta = entrada.AtivoDaConta;
        }

        public Operacao(Saida saida) {
            OperacaoId = saida.SaidaId;
            ContaId = saida.ContaId;
            Codigo = saida.Codigo;
            TipoId = saida.TipoId;
            Data = saida.Data;
            QtdPrevista = -1 * saida.QtdPrevista;
            QtdReal = -1 * saida.QtdReal;
            Valor = saida.Valor;
            ValorReal = saida.ValorReal;
            Associacoes = saida.Associacoes;
            OperacaoTipo = saida.OperacaoTipo;
            AtivoDaConta = saida.AtivoDaConta;
        }

        public Operacao(Operacao operacao, int qtdAcumulada) {
            OperacaoId = operacao.OperacaoId;
            ContaId = operacao.ContaId;
            Codigo = operacao.Codigo;
            TipoId = operacao.TipoId;
            Data = operacao.Data;
            QtdPrevista = operacao.QtdPrevista;
            QtdReal = operacao.QtdReal;
            QtdAcumulada = qtdAcumulada;
            Valor = operacao.Valor;
            ValorReal = operacao.ValorReal;
            Associacoes = operacao.Associacoes;
            OperacaoTipo = operacao.OperacaoTipo;
            AtivoDaConta = operacao.AtivoDaConta;
        }
    }
}