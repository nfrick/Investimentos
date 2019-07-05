using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Toxy;
using Toxy.Parsers;

namespace Investimentos {


    public class ExtratoCEFReader : ExtratoReader {
        static readonly Regex regexCEFConta = new Regex(@"[0-9]{3}[\.][0-9]{8}[\-][0-9]");
        static readonly Regex regexCEFMes = new Regex(@"[0-9]{2}[\/][0-9]{4}");
        static readonly Regex regexCEFPagina = new Regex(@"[1-9][\/][1-9]");
        static readonly Regex regexCEFHeader = new Regex(@"[0-9]{1,2}[\/][0-9]{1,2}[\/][0-9]{4}");

        private readonly int _linhaRentabilidade;
        private readonly int _linhaIdConta;
        private string linhaIdConta => TextAsArray[_linhaIdConta];
        private string linhaIdFundo => TextAsArray[6];

        private FundoMes _fundoMes;
        private List<Movimento> Movimentos { get; } = new List<Movimento>();

        public static string GetCEFConta(string input, bool includeSeps = false) =>
            includeSeps ? regexCEFConta.Match(input).Value :
                          RemoveSeparators(regexCEFConta.Match(input).Value);

        public static DateTime GetCEFMes(string input) =>
            Convert.ToDateTime($"01/{regexCEFMes.Match(input).Value}");

        public static bool NotPaginaOrHeader(string input) =>
            !regexCEFPagina.IsMatch(input) && !regexCEFHeader.IsMatch(input);

        public string CNPJ => GetCNPJ(linhaIdFundo, false);

        public string Nome => new string(linhaIdFundo.TakeWhile(c => !char.IsDigit(c)).ToArray()).Trim();

        public new string ContaCorrente => GetCEFConta(linhaIdConta);

        public DateTime Mes => Convert.ToDateTime($"01/{regexCEFMes.Match(linhaIdConta).Value}");

        #region MÉTODOS NÃO UTILIZADOS -------------------------------------
        //public decimal SaldoAnteriorValor => GetValue("Saldo Anterior", 1);

        //public decimal SaldoAnteriorCotas => GetValue("Saldo Anterior", 2);

        //public decimal AplicacoesValor => GetValue("Aplicações", 1);

        //public decimal AplicacoesCotas => GetValue("Aplicações", 2);

        //public decimal ResgatesValor => GetValue("Resgates", 1);

        //public decimal ResgatesCotas => GetValue("Resgates", 2);

        //public decimal IRRFValor => GetValue("IRRF", 1);

        //public decimal SaldoBrutoValor => GetValue("Saldo Bruto", 1);

        //public decimal SaldoBrutoCotas => GetValue("Saldo Bruto", 2);

        //public decimal IRRFProvisionadoValor => GetValue("IRRF Provisionado", 1);

        //public decimal SaldoLiquido => GetValue("Saldo Líquido", 1);
        #endregion MÉTODOS NÃO UTILIZADOS -------------------------------------

        public ExtratoCEFReader(string filename) {
            try {
                var parser = new PDFTextParser(new ParserContext(filename));
                TextAsArray = parser.Parse().Split(SeparatorNewline)
                    .Select(r => r.Trim()).Where(r => !string.IsNullOrEmpty(r))
                    .ToArray();

                var linhasIndexadas = TextAsArray.Select((v, i) => new {Index = i, Value = v});

                _linhaIdConta = 2 + linhasIndexadas
                                    .First(p => p.Value.StartsWith("Cliente")).Index;
                _linhaRentabilidade = linhasIndexadas
                    .First(p => p.Value.StartsWith("Administradora")).Index - 1;

                var linhas = TextAsArray.SkipWhile(r => !r.StartsWith("Movimentação Detalhada"))
                    .Skip(2).TakeWhile(r => !r.StartsWith("Dados de Tributação"))
                    .Where(NotPaginaOrHeader).ToArray();

                for (var i = 0; i < linhas.Length; i++) {
                    var mov = new Movimento(linhas[i], SeparatorBlank, Mes);
                    if (mov.IsResgate) {
                        mov.AddImposto(linhas.Skip(i + 1).Take(2), SeparatorBlank);
                        i += 2;
                    }
                    Movimentos.Add(mov);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally {

            }
        }

        public Fundo CreateFundo() => new Fundo() { Nome = Nome, CNPJ = CNPJ };

        private decimal GetValue(string text, int pos) {
            pos += text.Count(c => SeparatorBlank.Contains(c));
            return GetLineStartsWithAsArray(TextAsArray, text, SeparatorBlank, out string[] values) ? ToDecimal(values[pos]) : 0.0m;
        }

        private static decimal ToDecimal(string input) {
            var valor = char.IsLetter(input.Last())
                ? input.Substring(0, input.Length - 1)
                : input;
            return Convert.ToDecimal(valor, FormatPT_BR);
        }

        public void UpdateFundoMes(FundoMes fundoMes) {
            _fundoMes = fundoMes ?? new FundoMes();
            var rendimentos = LinetoArray(TextAsArray[_linhaRentabilidade]);
            _fundoMes.Mes = Mes;
            _fundoMes.RendimentoMes = ToDecimal(rendimentos.ElementAt(0));
            _fundoMes.RendimentoAno = ToDecimal(rendimentos.ElementAt(1));
            _fundoMes.Rendimento12Meses = ToDecimal(rendimentos.ElementAt(2));
            _fundoMes.CotaValor = ToDecimal(rendimentos.ElementAt(4));
        }

        public ContaMes UpdateContaMes(ContaMes contaMes) {
            var saldoBruto = LinetoArray(TextAsArray.First(r => r.StartsWith("Saldo Bruto")));
            contaMes = contaMes ?? new ContaMes();
            contaMes.FundoMes = _fundoMes;
            contaMes.CotaQtd = ToDecimal(saldoBruto[3]);
            contaMes.RendimentoBruto = GetValue("Rendimento Bruto no Mês", 1);
            contaMes.Movimentos.Clear();
            contaMes.Movimentos = Movimentos.ToList();

            return contaMes;
        }
    }
}
