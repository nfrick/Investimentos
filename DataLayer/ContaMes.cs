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
    
    public partial class ContaMes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContaMes()
        {
            this.Movimentos = new HashSet<Movimento>();
        }
    
        public int ContaMesId { get; set; }
        public int ContaFundoId { get; set; }
        public int FundoMesId { get; set; }
        public decimal RendimentoBruto { get; set; }
        public decimal CotaQtd { get; set; }
    
        public virtual ContaFundo ContaFundo { get; set; }
        public virtual FundoMes FundoMes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movimento> Movimentos { get; set; }
    }
}
