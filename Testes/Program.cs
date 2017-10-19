using System;
using System.Linq;
using DataLayer;

namespace Testes {
    class Program {
        static void Main(string[] args) {

            using (var ctx = new InvestimentosEntities()) {
                foreach (var conta in ctx.Contas) {
                    Console.WriteLine($"\n\n{conta.Nome}");
                    foreach (var f in conta.ContasFundos) {
                        Console.WriteLine($"\t{f}");
                        foreach (var r in f.Resultados) {
                            Console.WriteLine($"\t\t{r.Mes}\t{r.CotaValor}\t{r.RendimentoMes}");
                            foreach (var m in r.Movimentos) {
                                Console.WriteLine($"\t\t\t{m.Data}\t{m.Historico}\t{r.RendimentoMes}");
                            }
                        }
                        Console.WriteLine("");
                    }
                }
            }

            Console.WriteLine(@"Done.");
            Console.ReadLine();
        }
    }
}
