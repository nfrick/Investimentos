using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataLayer {
    public class ValidateUniqueContaAttribute : ValidationAttribute {
        public override bool IsValid(object value) {
            if (value == null)
                return true;
            var conta = value as Conta;
            using (var db = new InvestimentosEntities()) {
                return !db.Contas.Any(c => c.ContaId != conta.ContaId && c.Nome == conta.Nome);
            }
        }
    }
}