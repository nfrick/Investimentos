using DataLayer;
using System.Collections.Generic;
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

    }
}



