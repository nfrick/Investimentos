using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace LeitorExtratoFundo {
    class Program {
        static void Main(string[] args) {

            IFormatProvider format = new CultureInfo("pt-BR");

            var Resultados = new List<Resultado>();

            const string fileName = @"D:\investimentos.txt";
            const int BufferSize = 128;
            string d;
            using (var fileStream = File.OpenRead(fileName)) {
                using (var streamReader = new StreamReader(fileStream, Encoding.Default, true, BufferSize)) {
                    string line;
                    do {
                        do {
                            // Ler até achar o inicio dos dados do Fundo
                            line = streamReader.ReadLine();
                            if (line == null)
                                return;
                        } while (!line.Trim().StartsWith("BB"));
                        var Fundo = line.Substring(0, 30).Trim();

                        var resultado = new Resultado();

                        // Mover até inicio dos Movimentos
                        do {
                            // nothing
                        } while (!(line = streamReader.ReadLine().Trim()).Contains("SALDO ANTERIOR"));

                        // Ler movimentos
                        DateTime data;
                        while (!(line = streamReader.ReadLine().Trim()).Contains("SALDO ATUAL")) {
                            if (string.IsNullOrEmpty(line)) continue;
                            if (DateTime.TryParse(line.Substring(0, 10), format, DateTimeStyles.AssumeLocal, out data)) {
                                var mov = line.Split(new[] { ' ' }).Where(x => !string.IsNullOrEmpty(x)).ToArray();
                                var size = mov.Length;
                                var movimento = new Movimento() {
                                    Data = data,
                                    Historico = mov[1],
                                    Valor = decimal.Parse(mov[2]),
                                    ImpostoRenda = decimal.Parse(mov[size-3]),
                                    CotaQtd = decimal.Parse(mov[size-2]),
                                    CotaValor = decimal.Parse(mov[size-1])
                                };
                                resultado.Movimentos.Add(movimento);
                            }
                        }
                        resultado.Mes = DateTime.Parse(line.Substring(0, 10), format, DateTimeStyles.AssumeLocal);
                        resultado.Mes = resultado.Mes.AddDays(-1 * resultado.Mes.Day + 1);

                        // Ler até achar o novo anterior da cota
                        do {
                            line = streamReader.ReadLine().Trim();
                        } while (string.IsNullOrEmpty(line) || !DateTime.TryParse(line.Substring(0, 10), format,
                                     DateTimeStyles.AssumeLocal, out data));

                        // Ler até achar o novo atual da cota
                        do {
                            line = streamReader.ReadLine().Trim();
                            if (string.IsNullOrEmpty(line)) continue;
                        } while (string.IsNullOrEmpty(line) || !DateTime.TryParse(line.Substring(0, 10), format, DateTimeStyles.AssumeLocal, out data));

                        resultado.CotaValor = GetValor(line);

                        // Mover até inicio dos rendimentos
                        do {
                            line = streamReader.ReadLine().Trim();
                        } while (line == string.Empty || !line.StartsWith("No mês:"));

                        resultado.RendimentoMes = GetValor(line); // Mes
                        resultado.RendimentoAno = GetValor(streamReader); // Ano
                        resultado.Rendimento12Meses = GetValor(streamReader); // 12 meses

                        Resultados.Add(resultado);

                    } while (line != null);
                }
            }
        }

        private static decimal GetValor(TextReader stream) {
            string linha;
            while ((linha = stream.ReadLine().Trim()) == "") ;
            return GetValor(linha);
        }

        private static decimal GetValor(string linha) {
            var valores = linha.Split(new[] { ' ' }).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return decimal.Parse(valores[valores.Length - 1]);
        }
    }
}
