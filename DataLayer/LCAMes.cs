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
    
    public partial class LCAMes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LCAMes()
        {
            this.LCAMovimentos = new HashSet<LCAMovimento>();
        }
    
        public int LCAMesId { get; set; }
        public int LCAId { get; set; }
        public System.DateTime Mes { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal Aplicacoes { get; set; }
        public decimal Resgates { get; set; }
        public decimal RendimentoBruto { get; set; }
        public decimal ImpostoRenda { get; set; }
        public decimal IOF { get; set; }
        public decimal RendimentoLiquido { get; set; }
        public decimal SaldoAtual { get; set; }
    
        public virtual LCA LCA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LCAMovimento> LCAMovimentos { get; set; }
    }
}