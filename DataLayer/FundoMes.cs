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
    
    public partial class FundoMes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FundoMes()
        {
            this.ContasMeses = new HashSet<ContaMes>();
        }
    
        public int FundoMesId { get; set; }
        public int FundoId { get; set; }
        public System.DateTime Mes { get; set; }
        public decimal CotaValor { get; set; }
        public decimal RendimentoMes { get; set; }
        public decimal RendimentoAno { get; set; }
        public decimal Rendimento12Meses { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContaMes> ContasMeses { get; set; }
        public virtual Fundo Fundo { get; set; }
    }
}
