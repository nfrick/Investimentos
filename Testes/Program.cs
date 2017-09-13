using System;
using System.Linq;
using DataLayer;

namespace Testes {
    class Program {
        static void Main(string[] args) {

            using (var ctx = new InvestimentosEntities()) {
                foreach (var ativo in ctx.AtivosDaConta.Where(a=>a.ContaId == 1)) {
                    Console.WriteLine($"\n{ativo.Codigo}\t{ativo.ValorMedioCompraReal:N2}");
                    foreach (var op in ativo.Operacoes) {
                        Console.WriteLine($"\t{op.Data:dd/MM/yy}\t{op.OperacaoTipo.Tipo}\t{op.QtdReal}\t{op.QtdAcumulada}");
                    }
                }
            }

            Console.ReadLine();
        }
    }

}