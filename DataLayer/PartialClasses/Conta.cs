using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataLayer {
    [MetadataType(typeof(ContaMetadata))]
    [ValidateUniqueConta(ErrorMessage = "Conta já cadastrada!")]
    public partial class Conta {

        public decimal LucroTotal => Saidas.Sum(o => o.Lucro);

        public decimal LucroTotalReal => Saidas.Sum(o => o.LucroReal);

        public IEnumerable<AtivoDaConta> AtivosNaoZerados => AtivosDaConta.Where(a => a.QtdTotal > 0);

        public IEnumerable<Patrimonio> PatrimonioAtivosNaoZerados => AtivosNaoZerados
            .Select(a => new Patrimonio { Tipo = "Ações", Item = a.Codigo, Valor = a.Patrimonio })
            .OrderBy(p=>p.Item);

        public IEnumerable<Patrimonio> PatrimonioAtivosTotal {
            get {
                var total = new List<Patrimonio> {
                    new Patrimonio {
                        Tipo = "Total Ações",
                        Item = null,
                        Valor = AtivosNaoZerados.Sum(a => a.Patrimonio)
                    }
                };

                return total;
            }
        }

        public IEnumerable<ContaFundo> FundosNaoZerados => Fundos.Where(f => f.Saldo > 0);

        public IEnumerable<Patrimonio> PatrimonioFundosNaoZerados => FundosNaoZerados
            .Select(f => new Patrimonio { Tipo = "Fundos", Item = f.FundoNome.Substring(3), Valor = f.Saldo })
            .OrderBy(p => p.Item)
            .Concat(PatrimonioSaldoEmContaCorrente);

        public IEnumerable<Patrimonio> PatrimonioFundosTotal {
            get {
                var total = new List<Patrimonio> {
                    new Patrimonio {
                        Tipo = "Total Fundos",
                        Item = null,
                        Valor = FundosNaoZerados.Sum(f => f.Saldo)
                    }
                };

                return total;
            }
        }

        public IEnumerable<Patrimonio> PatrimonioSaldoEmContaCorrente =>
            SaldosEmConta.Select(s => new Patrimonio {
                Tipo = "Saldo em Conta",
                Item = s.Item,
                Valor = s.Valor
            });

        public IEnumerable<Patrimonio> PatrimonioTotal => PatrimonioAtivosNaoZerados.Concat(PatrimonioFundosNaoZerados).OrderByDescending(a => a.Valor);

        public IEnumerable<sp_SituacaoImpostoRenda_Result> ImpostoRenda(int Ano) {
            using (var ctx = new InvestimentosEntities()) {
                return ctx.sp_SituacaoImpostoRenda(ContaId, Ano).ToList();
            }
        }
    }

    public class ContaMetadata {
        public int ContaId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "{0} precisa ter entre {2} e {1} letras.")]
        public string Nome { get; set; }

        [Display(Name = "Banco")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "{0} precisa ter entre {2} e {1} letras.")]
        public string Banco { get; set; }

        [Display(Name = "Agência")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "{0} precisa ter entre {2} e {1} algarismos.")]
        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "{0} deve conter apenas algarismos.")]
        public string Agencia { get; set; }

        [Display(Name = "Conta Corrente")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "{0} precisa ter entre {2} e {1} algarismos.")]
        [RegularExpression(@"^[0-9]{1,15}$", ErrorMessage = "{0} deve conter apenas algarismos.")]
        public string ContaCorrente { get; set; }

        [Display(Name = "Operação")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "{0} precisa ter entre {2} e {1} algarismos.")]
        [RegularExpression(@"^[0-9]{0,3}$", ErrorMessage = "{0} deve conter apenas algarismos.")]
        public string Operacao { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "{0} precisa ter entre {2} e {1} letras.")]
        public string Senha { get; set; }

        [Display(Name = "Info")]
        [StringLength(50)]
        public string Info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AtivoDaConta> AtivosDaConta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Saida> Saidas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fundo> Fundos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LCA> LCAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaldoEmConta> SaldosEmConta { get; set; }

    }

    public class Patrimonio {
        public string Tipo { get; set; }
        public string Item { get; set; }
        public decimal Valor { get; set; }
    }

    public class IR {
        public string Codigo { get; set; }
        public int Qtd { get; set; }
        public decimal Preco { get; set; }
    }
}