using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer {
    public partial class ContaMes {
        public decimal ImpostoRenda => Movimentos.Sum(m => m.ImpostoRenda);
        public decimal IOF => Movimentos.Sum(m => m.IOF);
        public decimal RendimentoLiquido => RendimentoBruto - ImpostoRenda;
        private Movimento MovSaldo => Movimentos.FirstOrDefault(m => m.Historico == "saldo atual");
        public decimal Saldo => MovSaldo?.Valor ?? CotaQtd * CotaValor;

        public DateTime Mes => FundoMes.Mes;
        public decimal CotaValor => FundoMes.CotaValor;
        public decimal RendimentoMes => FundoMes.RendimentoMes;
        public decimal RendimentoAno => FundoMes.RendimentoAno;
        public decimal Rendimento12Meses => FundoMes.Rendimento12Meses;

        public override string ToString() => $"ContaMesId: {ContaMesId}  Mês: {Mes:MMM/yyyy}";
    }

    public partial class FundoMes {
        public override string ToString() => $"FundoMesId: {this.FundoMesId}  Fundo: {FundoId}  Mês: {Mes:MMM/yyyy}";
    }
}
