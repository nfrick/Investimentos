using System.Collections.Generic;
using System.Linq;

namespace DataLayer {

    public partial class Conta {

        public decimal LucroTotal => Saidas.Sum(o => o.Lucro);
        public decimal LucroTotalReal => Saidas.Sum(o => o.LucroReal);

        public IEnumerable<Patrimonio> AtivosNaoZerados => AtivosDaConta.Where(a => a.QtdTotal > 0)
            .Select(a => new Patrimonio { Item = a.Codigo, Valor = a.Patrimonio });

        public IEnumerable<Patrimonio> FundosNaoZerados => Fundos.Where(f => f.Saldo > 0)
            .Select(f => new Patrimonio { Item = f.FundoNome.Substring(3), Valor = f.Saldo })
            .Concat(SaldoEmContaCorrente);

        public IEnumerable<Patrimonio> SaldoEmContaCorrente =>
            SaldosEmConta.Select(s => new Patrimonio {
                Item = s.Item, Valor = s.Valor
            });

        public IEnumerable<Patrimonio> PatrimonioTotal => AtivosNaoZerados.Concat(FundosNaoZerados).OrderByDescending(a => a.Valor);

        public IEnumerable<sp_SituacaoImpostoRenda_Result> ImpostoRenda(int Ano) {
            using (var ctx = new InvestimentosEntities()) {
                return ctx.sp_SituacaoImpostoRenda(ContaId, Ano).ToList();
            }
        }
    }

    public class Patrimonio {
        public string Item { get; set; }
        public decimal Valor { get; set; }
    }

    public class IR {
        public string Codigo { get; set; }
        public int Qtd { get; set; }
        public decimal Preco { get; set; }
    }
}