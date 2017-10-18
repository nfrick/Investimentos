﻿using System;
using System.Linq;
using DataLayer;

namespace Testes {
    class Program {
        static void Main(string[] args) {

            using (var ctx = new InvestimentosEntities()) {
                //foreach (var conta in ctx.Contas) {
                //    Console.WriteLine($"{conta.Nome}");
                //    foreach (var ativo in conta.AtivosDaConta) {
                //        Console.WriteLine($"\n\t{ativo.Codigo}\t{ativo.QtdTotal:N0}\t{ativo.ValorMedioCompraReal:N2}");
                //        foreach (var op in ativo.Operacoes) {
                //            Console.WriteLine(
                //                $"\t{op.Data:dd/MM/yy}" +
                //                $"\t{op.OperacaoTipo.Tipo}" +
                //                $"\t{op.QtdComSinal:N0}" +
                //                $"\t{op.QtdAcumulada:N0}" +
                //                $"\t{op.Valor:N2}" +
                //                $"\t{op.ValorReal:N2}");
                //        }
                //    }
                //    Console.WriteLine("\n\n");
                //}

                //var cta = ctx.Contas.Find(1);
                //var ativo = cta.AtivosDaConta.First(a => a.Codigo == "BBAS3");
                //var op = ativo.Operacoes.First();
                //op.QtdReal += 1;
                //ctx.SaveChanges();

                //var op = ctx.Operacoes.First();
                //var entrada = op as Entrada;
                //var y = entrada.QtdReal;
                //var saida = op as Saida;
                //var x = saida.QtdReal;

                foreach (var conta in ctx.Contas) {
                    Console.WriteLine(conta.Nome);
                    foreach (var sh in conta.ContasFundos) {
                        Console.WriteLine($"\t{sh.ToString()}");
                    }
                }

            }

            Console.WriteLine(@"Done.");
            Console.ReadLine();
        }
    }
}
