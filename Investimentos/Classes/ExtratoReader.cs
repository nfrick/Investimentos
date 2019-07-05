using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Investimentos {

    public abstract class ExtratoReader {
        protected string[] TextAsArray;
        public string ContaCorrente => "Conta Corrente";

        static readonly Regex regexCNPJ = new Regex(@"[0-9]{2}[\.][0-9]{3}[\.][0-9]{3}[\/][0-9]{4}[\-][0-9]{2}");
        static readonly Regex regexCEFCNPJ = new Regex(@"[0-9]{2}[\.][0-9]{3}[\.][0-9]{3}[\/][0-9]{4}");

        public static readonly IFormatProvider FormatPT_BR = new CultureInfo("pt-BR");

        public static readonly char[] SeparatorBlank = new[] { ' ', ' ' }; // o 2º char não é espaço, é o sep no PDF da Caixa
        public static readonly char[] SeparatorNewline = new[] { '\n' };

        public static string GetCNPJ(string input, bool fullCNPJ = true, bool includeSeps = false) {
            var regex = fullCNPJ ? regexCNPJ : regexCEFCNPJ;
            return includeSeps ? regex.Match(input).Value : RemoveSeparators(regex.Match(input).Value);
        }

        public static decimal GetMovimentoValor(string input) {
            var valores = LinetoArray(input).Where(x => !string.IsNullOrEmpty(x));
            return decimal.Parse(valores.Last());
        }

        public static DateTime? GetDate(string input) {
            if (DateTime.TryParse(input, FormatPT_BR,
                DateTimeStyles.AssumeLocal, out DateTime data)) {
                return data;
            }

            return null;
        }

        public static string RemoveSeparators(string input) {
            return new string(input.Trim().Where(char.IsDigit).ToArray());
        }

        public static string[] LinetoArray(string input) {
            return input.Split(SeparatorBlank).Where(x => !string.IsNullOrEmpty(x)).ToArray();
        }

        public static bool GetLineStartsWithAsArray(IEnumerable<string> textAsArray, string text, char[] sep, out string[] retValue) {
            var row = textAsArray.FirstOrDefault(r => r.StartsWith(text, StringComparison.InvariantCultureIgnoreCase));
            if (row == null) {
                retValue = null;
                return false;
            }
            retValue = row.Split(sep).Select(r => r.Trim()).Where(r => !string.IsNullOrEmpty(r)).ToArray();
            return true;
        }
    }
}
