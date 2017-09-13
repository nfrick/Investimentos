using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Testes {
    class Program {
        static void Main(string[] args) {

            using (var ctx = new Investimentos2Entities()) {
                foreach (var ativo in ctx.Ativos) {
                    Console.WriteLine(ativo.Codigo);
                    foreach (var sh in ativo.SeriesHistoricas) {
                        Console.WriteLine($"\t{sh.Data:dd/MM/yy}\t{sh.PrecoMedio}");
                    }
                }
            }

            Console.ReadLine();
        }
    }

}