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


            using (var ctx = new InvestimentosEntities()) {
                var conta = ctx.Contas.Find(3);
                foreach (var ativoCorrente in conta.AtivosCorrentes) {
                    Console.WriteLine(ativoCorrente.Codigo);
                    foreach (var opSaida in ativoCorrente.OperacoesDeSaida) {
                        Console.WriteLine($"\t{opSaida.Data:dd/MM/yy}\t{opSaida.Qtd}\t{opSaida.Valor}\t{opSaida.Venda.FirstOrDefault().Compra.Valor}");
                    }
                    
                }
            }






            Console.ReadLine();
        }
    }

}