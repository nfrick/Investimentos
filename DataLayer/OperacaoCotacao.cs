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
    
    public partial class OperacaoCotacao
    {
        public int OperacaoId { get; set; }
        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public System.DateTime Data { get; set; }
        public int Qtd { get; set; }
        public int QtdAcumulada { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorReal { get; set; }
        public int QtdVendida { get; set; }
    
        public virtual AtivoCotacao AtivoCotacao { get; set; }
    }
}
