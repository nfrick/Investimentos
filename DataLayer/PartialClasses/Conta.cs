using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;

namespace DataLayer {

    public partial class Conta {

        public string ContaEdicao {
            get => ContaCorrente.PadLeft(6);
            set => ContaCorrente = value.Trim();
        }
        public decimal LucroTotal => Saidas.Sum(o => o.Lucro);
        public decimal LucroTotalReal => Saidas.Sum(o => o.LucroReal);

        public IEnumerable<Patrimonio> AtivosNaoZerados => AtivosDaConta.Where(a => a.QtdTotal > 0)
            .Select(a => new
            Patrimonio { Item = a.Codigo, Valor = a.Patrimonio });

        public IEnumerable<Patrimonio> FundosNaoZerados => Fundos.Where(f => f.Saldo > 0)
            .Select(f => new Patrimonio { Item = f.FundoNome.Substring(3), Valor = f.Saldo });

        public IEnumerable<Patrimonio> PatrimonioTotal => AtivosNaoZerados.Concat(FundosNaoZerados).OrderByDescending(a=>a.Valor);
    }

    public class Patrimonio {
        public string Item { get; set; }
        public decimal Valor { get; set; }
    }

}
