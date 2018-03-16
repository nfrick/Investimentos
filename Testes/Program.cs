using System;
using DataLayer;
using System.Linq;

namespace Testes {
    class Program {
        static void Main(string[] args) {
            using (var ctx = new InvestimentosEntities()) {
                var conta = ctx.Contas.FirstOrDefault(c => c.ContaId == 1);
                foreach (var ativo in conta.AtivosDaConta.Where(a => a.QtdTotal > 0)) {
                    var operacoes = ativo.Operacoes.AsEnumerable()
                        .Reverse().TakeWhile(o => o.QtdAcumulada > 0).Where(o => o.IsEntrada).Reverse();
                    var media = 0.0m;
                    Console.WriteLine(ativo.Codigo);
                    foreach (var op in operacoes) {
                        Console.Write($"\t{op.Data}\t{op.OperacaoTipo.Tipo}\t({media:F2} * {op.QtdAntes:F2} + " +
                                      $"{op.Qtd:F0} * {op.Valor:F2} + {op.CustoOperacao:F2}) " +
                                      $"/ {op.QtdAcumulada:F2} = ");
                        media = (media * op.QtdAntes + op.ValorOperacaoComTaxas) / op.QtdAcumulada;
                        Console.WriteLine($"{media:F2}");
                    }
                    Console.WriteLine($"{ativo.ValorMedioCompra:F2}   {ativo.ValorMedioCompraReal:F2}\n\n");
                }
            }
            Console.ReadLine();
        }
    }
}
