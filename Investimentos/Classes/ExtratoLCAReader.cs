using DataLayer;
using EFWinforms;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Investimentos {
    public static class ExtratoLCAReader {
        public static void LerExtratoLCA(string fileName, Conta conta, EntityDataSource entity) {
            var LCAs = entity.DbContext.Set<LCA>();

            const int bufferSize = 128;

            using (var fileStream = File.OpenRead(fileName)) {
                using (var streamReader = new StreamReader(fileStream, Encoding.Default, true, bufferSize)) {

                    // Ler até achar o inicio dos dados
                    var line = ReadUntil(streamReader, "NÚMERO");
                    var lcaNumero = line.Substring(18).Trim();

                    // Localiza a LCA, criando se necessário
                    var lca = LCAs.Local.FirstOrDefault(l => l.Numero == lcaNumero);
                    if (lca == null) {
                        lca = new LCA {
                            Numero = lcaNumero,
                            Conta = conta,
                            Aplicacao = DateTime.Parse(GetNextLine(streamReader).Substring(18).Trim(),
                                ExtratoReader.FormatPT_BR),
                            ValorEmissao = decimal.Parse(GetNextLine(streamReader).Substring(18).Trim(),
                                ExtratoReader.FormatPT_BR)
                        };
                        var saldo = GetNextLine(streamReader); // skip that line
                        lca.Taxa = decimal.Parse(GetNextLine(streamReader).Substring(18).Trim(), ExtratoReader.FormatPT_BR);
                        lca.Vencimento = DateTime.Parse(GetNextLine(streamReader).Substring(18).Trim(), ExtratoReader.FormatPT_BR);
                        LCAs.Add(lca);
                    }

                    // Localiza o mês
                    line = ReadUntil(streamReader, "EXTRATO REF AO MÊS");

                    // Cria o Mes
                    var lcaMes = new LCAMes { LCA = lca, Mes = DateTime.Parse($"01/{line.Substring(18).Trim()}") };
                    lca.LCAMeses.Add(lcaMes);

                    // Ler movimentos
                    do {
                        if (string.IsNullOrEmpty(line)) {
                            continue;
                        }

                        if (!DateTime.TryParse(line.Substring(0, 10), ExtratoReader.FormatPT_BR, DateTimeStyles.AssumeLocal,
                            out DateTime data)) {
                            continue;
                        }

                        lcaMes.LCAMovimentos.Add(CreateLCAMovimento(line));
                    } while (!(line = GetNextLine(streamReader)).Contains("Saldo Atual"));
                    // Adiciona o saldo atual (última input)
                    lcaMes.LCAMovimentos.Add(CreateLCAMovimento(line));

                    // Localiza o mês
                    line = ReadUntil(streamReader, "SALDO ANTERIOR");
                    lcaMes.SaldoAnterior = GetValor(line);
                    lcaMes.Aplicacoes = GetValor(streamReader);
                    lcaMes.Resgates = GetValor(streamReader);
                    lcaMes.RendimentoBruto = GetValor(streamReader);
                    lcaMes.ImpostoRenda = GetValor(streamReader);
                    lcaMes.IOF = GetValor(streamReader);
                    lcaMes.RendimentoLiquido = GetValor(streamReader);
                    lcaMes.SaldoAtual = GetValor(streamReader);
                }
            }
        }

        private static string GetNextLine(TextReader stream) {
            string linha;
            while ((linha = stream.ReadLine().Trim()) == "") {
                ;
            }
            return linha;
        }

        private static string ReadUntil(TextReader stream, string text) {
            string linha;
            while (!(linha = stream.ReadLine().Trim()).Contains(text)) {
                ;
            }
            return linha;
        }

        private static decimal GetValor(TextReader stream) =>
            GetValor(GetNextLine(stream));

        private static decimal GetValor(string linha) {
            var valores = linha.Split(new[] { ' ' }).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return decimal.Parse(valores.Last());
        }

        private static LCAMovimento CreateLCAMovimento(string line) {
            return new LCAMovimento() {
                Data = DateTime.Parse(line.Substring(0, 10), ExtratoReader.FormatPT_BR, DateTimeStyles.AssumeLocal),
                Historico = line.Substring(11, 20).Trim().ToLower(),
                ValorCapital = ToDecimal(line, 38, 11),
                ImpostoRenda = ToDecimal(line, 48, 12),
                IOF = ToDecimal(line, 60, 12),
                Rendimentos = ToDecimal(line, 72, 15),
                ValorMovimento = ToDecimal(line, 88, 16),
                ValorAtual = int.Parse(line.Substring(103, 13)) / 100.0m
            };
        }

        private static decimal ToDecimal(string line, int start, int length) {
            return ToDecimalNull(line, start, length) ?? 0.0m;
        }

        private static decimal? ToDecimalNull(string line, int start, int length) {
            if (start > line.Length) {
                return null;
            }

            if (start + length > line.Length) {
                length = line.Length - start;
            }

            var text = line.Substring(start, length).Trim();
            return decimal.TryParse(text, out decimal valor) ? (decimal?)valor : null;
        }
    }
}