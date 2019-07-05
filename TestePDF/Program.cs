using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using DataLayer;
using Investimentos;
using Toxy;
using Toxy.Parsers;

namespace TestePDF {
    class Program {
        static void Main(string[] args) {

            var extratos = new ExtratoCEFReader[] {
                new ExtratoCEFReader(@"F:\Users\Nelson\Desktop\CAIXA - Extrato de Fundos - Petrobras.pdf"),
                new ExtratoCEFReader(@"F:\Users\Nelson\Desktop\CAIXA - Extrato de Fundos - Performance.pdf"),
                new ExtratoCEFReader(@"F:\Users\Nelson\Desktop\CAIXA - Extrato de Fundos - Consumo.pdf"),
                new ExtratoCEFReader(@"F:\Users\Nelson\Desktop\CAIXA - Extrato de Fundos - Objetivo.pdf"),
                new ExtratoCEFReader(@"F:\Users\Nelson\Desktop\CAIXA - Extrato de Fundos - Simples.pdf")
            };

            foreach (var extrato in extratos) {
                foreach (var mov in extrato.Movimentos) {
                    Console.WriteLine($"\t{mov}");
                }
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }
    }


}
