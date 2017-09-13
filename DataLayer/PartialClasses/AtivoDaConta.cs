using System.Collections.Generic;
using System.Linq;

namespace DataLayer {
    public partial class AtivoDaConta {
        public decimal ValorMedioCompra => _valorMedioCompra(false);

        public decimal ValorMedioCompraReal => _valorMedioCompra(true);

        private decimal _valorMedioCompra(bool real) {
            var ops = Operacoes.AsEnumerable().Reverse();
            var compras = ops
                .TakeWhile(c => c.QtdAcumulada > 0).
                Where(c => c.QtdReal > 0).ToArray();
            var qtd = ((decimal)compras.Sum(c => c.QtdReal));
            return qtd == 0 ? 0 : compras.Sum(c => (decimal)c.QtdReal * (real ? c.ValorReal : c.Valor)) / qtd;
        }

        public List<Operacao> Operacoes {
            get {
                var currentTotal = 0;
                return Entradas.Select(e => new Operacao(e)).Concat(Saidas.Select(s => new Operacao(s))).OrderBy(o => o.Data).ThenBy(o => o.OperacaoId).Select(o => {
                    currentTotal += o.QtdReal;
                    return new Operacao(o, currentTotal);
                }
                    ).ToList();
            }
        }

        public List<Operacao> Vendas => Operacoes.Where(o => o.QtdReal < 0).ToList();
    }
}