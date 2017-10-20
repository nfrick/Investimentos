using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer {
    public partial class ContaMes {
        public decimal ImpostoRenda => Movimentos.Sum(m => m.ImpostoRenda);
        public decimal RendimentoLiquido => RendimentoBruto - ImpostoRenda;
        private Movimento MovSaldo => Movimentos.FirstOrDefault(m => m.Historico == "saldo atual");
        public decimal Saldo => MovSaldo?.Valor ?? 0;
        public decimal CotaQtd => MovSaldo?.CotaQtd ?? 0;

        public DateTime Mes => FundoMes.Mes;
        public decimal CotaValor => FundoMes.CotaValor;
        public decimal RendimentoMes => FundoMes.RendimentoMes;
        public decimal RendimentoAno => FundoMes.RendimentoAno;
        public decimal Rendimento12Meses => FundoMes.Rendimento12Meses;

    }
}
