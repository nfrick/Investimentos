using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataLayer;

namespace Cotacoes {

    /// <summary>
    /// Posição da informação dentro do
    /// array criado pelo split da linha
    /// </summary>
    public enum AtivosTipos {
        Todos,
        JaNegociados,
        Correntes
    }
    public static class YahooFinance {
        //private static string _yahooString;
        private static List<AtivoCotacao> _ativos;
        //private static readonly Dictionary<string, CotacaoYahoo> Cotacoes = new Dictionary<string, CotacaoYahoo>();

        /// <summary>
        /// Inicializa a string para o Web Service
        /// e a lista de ativos a serem controlados
        /// </summary>
        public static bool Initialize(int contaId) {
            //var sucessoNoYahoo = true;
            using (var ctx = new AtivoCotacaoEntities()) {
                if (_ativos == null) {

                    //_yahooString = @"http://finance.yahoo.com/d/quotes.csv?s=" +
                    //               string.Join("+", ctx.Ativos
                    //                   .Select(x => x.Codigo + ".SA").OrderBy(x => x).ToArray()) +
                    //               @"&f=snbb3ab2opl1d1t1ghc1c6p2k2jk";

                    _ativos = ctx.Ativos.ToList();
                    try {
                        //ObterCotacoes();
                    }
                    catch (WebException) {
                        //sucessoNoYahoo = false;
                    }
                    foreach (var ativo in _ativos)
                        ativo.Initialize(contaId);  //Cotacoes, contaId);
                    //Parallel.ForEach(_ativos, (ativo) => {
                    //    Initialize(contaId);
                    //});
                }
                else {
                    foreach (var ativo in _ativos)
                        ativo.SetarConta(contaId);
                }
            }
            return true;  //sucessoNoYahoo;
        }

        /// <summary>
        /// Filtra os ativos para exibição
        /// Ativos nao exibidos continuam a ser atualizados
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static List<AtivoCotacao> AtivosParaExibicao(AtivosTipos tipo) {
            return tipo == AtivosTipos.Correntes ?
                    _ativos.Where(a => a.Corrente).ToList() : (
                    tipo == AtivosTipos.JaNegociados ?
                    _ativos.Where(a => a.JaNegociado).ToList() :
                    _ativos);
        }

        /// <summary>
        /// Retorna o ativo da lista pelo código
        /// </summary>
        /// <param name="codigo">Código do ativo a ser retornado</param>
        /// <returns></returns>
        public static AtivoCotacao AtivoPorCodigo(string codigo) => _ativos.Find(a => a.Codigo == codigo);

        /// <summary>
        /// Atualiza as cotações e a lista de trades
        /// </summary>
        public static void AtualizarCotacoes() {
            //ObterCotacoes();
            //foreach (var ativo in _ativos)
            //    ativo.AtualizarCotacao(Cotacoes);
        }

        /// <summary>
        /// Acessa o serviço Yahoo de cotações
        /// </summary>
        internal static void ObterCotacoes() {
            //string csvData;
            //using (var web = new WebClient()) {
            //    csvData = web.DownloadString(_yahooString);
            //}
            //Cotacoes.Clear();
            //var rows = csvData.Replace("\r", "").Split('\n');
            //foreach (var row in rows) {
            //    if (CotacaoYahoo.CotacaoValida(row))
            //        Cotacoes.Add(CotacaoYahoo.Codigo, new CotacaoYahoo());
            //}
        }
    }
}



