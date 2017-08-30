using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.IO;
using System.Globalization;
using System.Diagnostics;

namespace Testes {
    class Program {
        static void Main(string[] args) {


            using (var ctx = new AtivoCotacaoEntities()) {
                List<AtivoCotacao> ativos = ctx.Ativos.ToList();
                ativos.Reverse();
                foreach (AtivoCotacao ativo in ativos)
                    if (ativo.ValorMedioCompra > 0)
                        Console.WriteLine("{0} {1} {2}",
                            ativo.Nome,
                            ativo.ValorMedioCompra,
                            ativo.ValorMedioCompraReal);
            }






            Console.ReadLine();
        }
    }

}