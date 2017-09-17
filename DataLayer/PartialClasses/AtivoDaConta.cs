using System.Collections.Generic;
using System.Linq;

namespace DataLayer {
    public partial class AtivoDaConta {
        public decimal ValorMedioCompra => _valorMedioCompra(false);

        public decimal ValorMedioCompraReal => _valorMedioCompra(true);

        private decimal _valorMedioCompra(bool real) {
            var ops = Operacoes.AsEnumerable().Reverse();
            var compras = ops
                .TakeWhile(o => o.QtdAcumulada > 0)
                .Where(o => o.IsEntrada).ToArray();
            var qtd = ((decimal)compras.Sum(c => c.QtdComSinal));
            return qtd == 0 ? 0 : compras.Sum(c => (decimal)c.QtdComSinal * (real ? c.ValorReal : c.Valor)) / qtd;
        }

        //public List<Saida> Saidas => 
        //    Operacoes.Where(o => o.OperacaoTipo.IsSaida).Select(o => o.ToSaida).ToList();
        //public List<Entrada> Entradas => 
        //    Operacoes.Where(o => o.OperacaoTipo.IsEntrada).Select(o=>o.ToEntrada).ToList();
    }
}