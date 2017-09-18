using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DataLayer {
    public partial class CotacaoDiaria {
        /// <summary>
        /// Lê arquivo e retorna uma lista
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns>List<SerieHistorica></returns>
        /// <deprecated></deprecated>
        public static List<CotacaoDiaria> LerArquivo(string arquivo, InvestimentosEntities ctx) {
            //    var maxData = ctx.SeriesHistoricas.Max(c => c.Data).ToString("yyyyMMdd");
            var serie = from linha in File.ReadLines(arquivo)
                        join ativo in ctx.Ativos
                        on linha.Substring(12, 12).Trim() equals ativo.Codigo
                        where linha.StartsWith("01")
                              && linha.Substring(24, 3) == "010"
                        //&& string.Compare(linha.Substring(2, 8), maxData, StringComparison.Ordinal) > 0
                        select new CotacaoDiaria(linha);
            return serie.ToList();
        }

        /// <summary>
        /// Lê arquivo e grava no banco de dados
        /// </summary>
        /// <param name="arquivo"></param>
        /// <returns>Número de registros gravados</returns>
        public static long LerArquivoParaDatabase(string arquivo) {
            long recordsAdded;
            using (var ctx = new InvestimentosEntities()) {
                var serie = LerArquivo(arquivo, ctx);
                recordsAdded = serie.Count;
                ctx.CotacoesDiarias.AddRange(serie);
                ctx.SaveChanges();
            }
            return recordsAdded;
        }

        public CotacaoDiaria() {
        }
        public CotacaoDiaria(string linha) {
            Data = DateTime.ParseExact(linha.Substring(2, 8), "yyyyMMdd",
                CultureInfo.InvariantCulture, DateTimeStyles.None);
            Codigo = linha.Substring(12, 12).Trim();
            PrecoAbertura = Convert.ToDecimal(linha.Substring(56, 13)) / 100;
            PrecoMaximo = Convert.ToDecimal(linha.Substring(69, 13)) / 100;
            PrecoMinimo = Convert.ToDecimal(linha.Substring(82, 13)) / 100;
            PrecoMedio = Convert.ToDecimal(linha.Substring(95, 13)) / 100;
            PrecoUltimo = Convert.ToDecimal(linha.Substring(108, 13)) / 100;
            PrecoMelhorOfertaCompra = Convert.ToDecimal(linha.Substring(121, 13)) / 100;
            PrecoMelhorOfertaVenda = Convert.ToDecimal(linha.Substring(134, 13)) / 100;
        }
    }
}