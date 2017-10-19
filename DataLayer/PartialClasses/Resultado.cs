using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer {
    public partial class Resultado {
        public decimal ImpostoRenda => Movimentos.Sum(m => m.ImpostoRenda);
        public decimal RendimentoLiquido => RendimentoBruto - ImpostoRenda;
        private Movimento MovSaldo => Movimentos.FirstOrDefault(m => m.Historico == "SALDO ATUAL");
        public decimal SaldoAtual => MovSaldo?.Valor ?? 0;
        public decimal CotaQtd => MovSaldo?.CotaQtd ?? 0;
    }
}
