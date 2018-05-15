using System.Collections.Generic;
using System.Linq;

namespace DataLayer {
    public class AtivoCotacaoTotal {
        public string Col0 { get; set; }
        public decimal? Col1 { get; set; }
        public decimal? Col2 { get; set; }
        public decimal? Col3 { get; set; }
        public decimal? Col4 { get; set; }
        public decimal? Col5 { get; set; }
        public decimal? Col6 { get; set; }
        public decimal? Col7 { get; set; }
        public decimal? Col8 { get; set; }
        public decimal? Col9 { get; set; }
        public decimal? Col10 { get; set; }
        public decimal? Col11 { get; set; }
        public decimal? Col12 { get; set; }
        public decimal? Col13 { get; set; }
        public decimal? Col14 { get; set; }
        public decimal? Col15 { get; set; }
        public decimal? Col16 { get; set; }
        public decimal? Col17 { get; set; }
        public decimal? Col18 { get; set; }

        public static List<AtivoCotacaoTotal> New(IReadOnlyCollection<AtivoCotacao> cotacoes) {
            var lista = new List<AtivoCotacaoTotal> {new AtivoCotacaoTotal(cotacoes)};
            return lista;

        }
        public AtivoCotacaoTotal(IReadOnlyCollection<AtivoCotacao> cotacoes) {
            Col0 = "TOTAL";
            Col10 = cotacoes.Sum(c => c.Patrimonio);
            Col12 = cotacoes.Sum(c => c.LucroReal);
            Col14 = cotacoes.Sum(c => c.LucroImediato);

            Col1 = null;
            Col2 = null;
            Col3 = null;
            Col4 = null;
            Col5 = null;
            Col6 = null;
            Col7 = null;
            Col8 = null;
            Col9 = null;
            Col11 = null;
            Col13 = null;

        }
    }
}