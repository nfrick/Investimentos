using System;
using DataLayer;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

    public enum Posicao {
        Papel, Nada1, Cotação, VarPercent, QtdComprada, Compra, Venda, QtdVendida, Max, Min, Fech,
        NumNeg, QtdNegDia, VolNegDia, QtdUltNeg, Nada2, DtUltNeg, HoraUltNeg
    }

    public static class FinanceData {
        private static List<AtivoCotacao> _ativos;

        /// <summary>
        /// Inicializa a string para o Web Service
        /// e a lista de ativos a serem controlados
        /// </summary>
        public static bool Initialize(int contaId) {
            using (var ctx = new AtivoCotacaoEntities()) {
                if (_ativos == null)
                    _ativos = ctx.Ativos.ToList();
                foreach (var ativo in _ativos)
                    ativo.SetarConta(contaId);
                return true;
            }
        }

        /// <summary>
        /// Filtra os ativos para exibição
        /// Ativos nao exibidos continuam a ser atualizados
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static List<AtivoCotacao> AtivosParaExibicao(AtivosTipos tipo) =>
            tipo == AtivosTipos.Correntes ?
                    _ativos.Where(a => a.Corrente).ToList() : (
                    tipo == AtivosTipos.JaNegociados ?
                    _ativos.Where(a => a.JaNegociado).ToList() :
                    _ativos);

        /// <summary>
        /// Retorna o ativo da lista pelo código
        /// </summary>
        /// <param name="codigo">Código do ativo a ser retornado</param>
        /// <returns></returns>
        public static AtivoCotacao AtivoPorCodigo(string codigo) => _ativos.Find(a => a.Codigo == codigo);

        public static void AtualizarPorExtrato(string fileName) {
            var seps = new[] { "\r\n" };
            var readText = File.ReadAllText(fileName);
            var lines = readText.Split(seps, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines) {
                var cotacao = line.Split(';');
                var papel = cotacao[(int)Posicao.Papel];
                var ativo = _ativos.FirstOrDefault(a => a.Codigo == papel);
                if (ativo == null) continue;
                var d = $"{cotacao[(int)Posicao.DtUltNeg]} {cotacao[(int)Posicao.HoraUltNeg]}";
                var dt = DateTime.Parse(d);
                if (ativo.Cotacoes.ContainsKey(dt)) continue;
                var si = new StockInfo {
                    close = decimal.Parse(cotacao[(int)Posicao.Cotação]),
                    high = decimal.Parse(cotacao[(int)Posicao.Max]),
                    low = decimal.Parse(cotacao[(int)Posicao.Min]),
                    open = decimal.Parse(cotacao[(int)Posicao.Fech]),
                    volume = ParseInt(cotacao[(int)Posicao.QtdNegDia])
                };
                ativo.Cotacoes.Add(dt, si);
            }
        }

        private static int ParseInt(string num) {
            var mult = num[num.Length - 1] == 'K' ? 1000 : 1000000;
            var num2 = num.Replace(",", ".").Substring(0, num.Length - 1);
            return (int)(mult * decimal.Parse(num2));
        }
    }
}