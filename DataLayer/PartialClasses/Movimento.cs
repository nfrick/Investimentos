using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DataLayer {
    public partial class Movimento {
        private static readonly IFormatProvider FormatPT_BR = new CultureInfo("pt-BR");
        public override string ToString() => $"{Data:dd/MM/yyyy} {Historico} {Valor:C2} {ImpostoRenda:C2} {IOF:C2} {CotaQtd} {CotaValor}";
        public Movimento() {
            
        }

        #region BANCO DO BRASIL
        public Movimento(string line) {
            Data = DateTime.Parse(line.Substring(0, 10), FormatPT_BR, DateTimeStyles.AssumeLocal);
            Historico = line.Substring(11, 22).Trim().ToLower();
            Valor = ToDecimal(line, 38, 12);
            ImpostoRenda = ToDecimal(line, 50, 16);
            IOF = ToDecimal(line, 84, 9);
            CotaQtd = ToDecimal(line, 95, 19);
            CotaValor = ToDecimalNull(line, 117, 20);
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
        #endregion BANCO DO BRASIL

        #region CAIXA ECONOMICA
        public Movimento(string text, char[] seps, DateTime Mes) {
            var dados = text.Split(seps).Select(r => r.Trim())
                .Where(r => !string.IsNullOrEmpty(r)).ToArray();

            Data = Convert.ToDateTime($"{dados[0]}/{dados[2]}/{Mes.Year}");
            Historico = dados[3];
            Valor = ToValor(dados[4]);
            CotaQtd = Convert.ToDecimal(dados[5]);
            CotaValor = Valor / CotaQtd;
        }

        public void AddImposto(IEnumerable<string> linhas, char[] seps) {
            foreach (var linha in linhas) {
                var dados = linha.Split(seps).Select(r => r.Trim())
                    .Where(r => !string.IsNullOrEmpty(r)).ToArray();
                if (dados[0] == "IRRF") ImpostoRenda = ToValor(dados[1]);
                else IOF = ToValor(dados[1]);
            }
        }

        public bool IsResgate => Historico.Equals("resgate", StringComparison.CurrentCultureIgnoreCase);

        private static decimal ToValor(string text) {
            return Convert.ToDecimal(text.Substring(0, text.Length - 1));
        }
        #endregion CAIXA ECONOMICA
    }
}
