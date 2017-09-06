//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class OperacaoDeSaida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OperacaoDeSaida()
        {
            this.Venda = new HashSet<Venda>();
        }
    
        public int OperacaoId { get; set; }
        public string Codigo { get; set; }
        public System.DateTime Data { get; set; }
        public int Qtd { get; set; }
        public int QtdAcumulada { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorReal { get; set; }
        public string Tipo { get; set; }
        public int ContaId { get; set; }
    
        public virtual AtivoCorrente AtivoCorrente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
