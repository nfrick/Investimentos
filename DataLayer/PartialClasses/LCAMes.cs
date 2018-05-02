using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer {
    public partial class LCAMes {
        public decimal RendimentoMes => RendimentoBruto / (SaldoAtual - RendimentoBruto);

        private decimal Saldo => SaldoAtual == 0 ? Resgates : SaldoAtual;
    }
}
