using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer {
    public class Operacao {
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
        public ICollection<Associacao> Associacoes { get; set; }
        public OperacaoTipo OperacaoTipo { get; set; }
        public AtivoDaConta AtivoDaConta { get; set; }

        // Entradas only
        public int? SaidaId { get; set; }
        public int? QtdAssociada { get; set; }
        public Saida Saida { get; set; }

        // Saidas only
        public ICollection<Entrada> Entradas { get; set; }
        public int QtdAntes => QtdAcumulada - QtdReal;
        public int QtdComprada => Entradas == null ? 0 : Entradas.Sum(e => e.QtdAssociada) ?? 0;
        public int QtdPendente => -1 * (QtdReal - QtdComprada);
        public decimal ValorMedioCompra => _ValorMedioCompra(false);
        public decimal ValorMedioCompraReal => _ValorMedioCompra(true);
        public decimal Lucro => QtdReal * (ValorMedioCompra - Valor);
        public decimal LucroReal => QtdReal * (ValorMedioCompraReal - Valor);
        private decimal _ValorMedioCompra(bool real) {
            if (QtdComprada == 0) return 0;
            var total = Entradas.Sum(c => c.QtdAssociada * (real ? c.ValorReal : c.Valor));
            return (total ?? 0) / QtdComprada;
        }

        // Constructors
        public Operacao() {
            this.Associacoes = new HashSet<Associacao>();
            this.Entradas = new HashSet<Entrada>();
        }

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
            OperacaoTipo = entrada.OperacaoTipo;
            AtivoDaConta = entrada.AtivoDaConta;
            SaidaId = entrada.SaidaId;
            QtdAssociada = entrada.QtdAssociada;
            Saida = entrada.Saida;
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
            OperacaoTipo = saida.OperacaoTipo;
            AtivoDaConta = saida.AtivoDaConta;
            Entradas = saida.Entradas;
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
            OperacaoTipo = operacao.OperacaoTipo;
            AtivoDaConta = operacao.AtivoDaConta;
            SaidaId = operacao.SaidaId;
            QtdAssociada = operacao.QtdAssociada;
            Saida = operacao.Saida;
            Entradas = operacao.Entradas;
        }
    }
}