using DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Investimentos {

    public class ExtratoBBeader : ExtratoReader {

        public new string ContaCorrente => RemoveSeparators(TextAsArray.First(r => r.StartsWith("Agência:"))
            .Split(SeparatorBlank).Last());

        public IEnumerable<FundoNoExtrato> FundosNoExtrato { get; }

        public ExtratoBBeader(string filename) {
            TextAsArray = File.ReadAllText(filename, Encoding.Default)
                .Split(SeparatorNewline)
                .Select(r => r.Trim()).Where(r => !string.IsNullOrEmpty(r))
                .ToArray();

            var searchCNPJ = new Regex(@"((\d{2}.\d{3}.\d{3}\/\d{4}-\d{2})|(\d{14})$)");

            FundosNoExtrato = TextAsArray.Select((t, i) => i)
                .Where(i => searchCNPJ.IsMatch(TextAsArray[i]))
                .Select(i => new FundoNoExtrato(TextAsArray, i));

            //FundosNoExtrato = TextAsArray.Select((t, i) => i)
            //    .Where(i => TextAsArray[i].StartsWith("BB"))
            //    .Select(i => new FundoNoExtrato(TextAsArray, i));
        }
    }

    public class FundoNoExtrato {
        public string Nome { get; }
        public string CNPJ { get; }
        public DateTime Mes { get; }

        private readonly decimal _cotaValor;
        private readonly decimal _rendimentoBruto;
        private FundoMes _fundoMes;
        private readonly IEnumerable<string> _rendimentos;
        private readonly IEnumerable<Movimento> _movimentos;

        public FundoNoExtrato(IReadOnlyList<string> textoAsArray, int index) {
            Nome = textoAsArray[index].Substring(0, 40).Trim();
            CNPJ = ExtratoReader.GetCNPJ(textoAsArray[index], true);

            var extrato = textoAsArray.Skip(index + 1).TakeWhile(r => !r.StartsWith("BB"));
            var movs = extrato.Skip(3).TakeWhile(r => !r.StartsWith("---"));
            _cotaValor = ExtratoReader.GetMovimentoValor(extrato.Skip(movs.Count() + 7).Take(1).First());
            _rendimentoBruto = ExtratoReader.GetMovimentoValor(extrato.First(r => r.StartsWith("RENDIMENTO BRUTO")));
            _rendimentos = extrato.SkipWhile(r => !r.StartsWith("No mês:")).Take(3);
            _movimentos = movs.Where(m => ExtratoReader.GetDate(m.Substring(0, 10)) != null)
                .Select(m => new Movimento(m));

            var mes = _movimentos.Last().Data;
            Mes = mes.AddDays(1 - mes.Day);
        }

        public Fundo CreateFundo() => new Fundo() { Nome = Nome, CNPJ = CNPJ };

        public void UpdateFundoMes(Fundo fundo) {
            _fundoMes = fundo.Meses.FirstOrDefault(m => m.Mes == Mes) ?? new FundoMes() { Fundo = fundo };
            _fundoMes.Mes = Mes;
            _fundoMes.CotaValor = _cotaValor;
            _fundoMes.RendimentoMes = ExtratoReader.GetMovimentoValor(_rendimentos.ElementAt(0));
            _fundoMes.RendimentoAno = ExtratoReader.GetMovimentoValor(_rendimentos.ElementAt(1));
            _fundoMes.Rendimento12Meses = ExtratoReader.GetMovimentoValor(_rendimentos.ElementAt(2));
            if (_fundoMes.FundoMesId == 0) {
                fundo.Meses.Add(_fundoMes);
            }
        }

        public void UpdateContaMes(ContaFundo contaFundo) {
            var contaMes = contaFundo.ContasMeses
                               .FirstOrDefault(c => c.Mes == Mes) ?? new ContaMes();
            contaMes.FundoMes = _fundoMes;
            contaMes.CotaQtd = _movimentos.Last().CotaQtd;
            contaMes.RendimentoBruto = _rendimentoBruto;
            contaMes.Movimentos.Clear();
            contaMes.Movimentos = _movimentos.ToList();
            if (contaMes.ContaMesId == 0) {
                contaFundo.ContasMeses.Add(contaMes);
            }
        }

    }
}
