using System.Linq;

namespace DataLayer {
    public partial class AtivoDaConta {
        public decimal? CotacaoAtual { get; set; }

        public decimal UltimaCotacao => CotacaoAtual ?? Ativo.CotacoesDiarias.OrderByDescending(c => c.Data).First().PrecoMedio;

        public decimal Patrimonio => UltimaCotacao * QtdTotal ?? 0;

        public decimal ValorMedioCompra => _valorMedioCompra(false);

        public decimal ValorMedioCompraReal => _valorMedioCompra(true);

        private decimal _valorMedioCompraOld(bool real) {
            var ops = Operacoes.AsEnumerable().Reverse();
            var compras = ops
                .TakeWhile(o => o.QtdAcumulada > 0)
                .Where(o => o.IsEntrada).ToArray();
            var qtd = ((decimal)compras.Sum(c => c.QtdComSinal));
            return qtd == 0 ? 0 : compras.Sum(c => (decimal)c.QtdComSinal * (real ? c.ValorReal : c.Valor)) / qtd;
        }

        private decimal _valorMedioCompra(bool real) =>
            Operacoes.AsEnumerable()
                .Reverse().TakeWhile(o => o.QtdAcumulada > 0).Where(o => o.IsEntrada).Reverse()
                .Aggregate(0.0m,
                    (current, operacao) => (current * operacao.QtdAntes +
                            (real ? operacao.ValorOperacaoComTaxasReal : operacao.ValorOperacaoComTaxas)) / operacao.QtdAcumulada);
    }
}