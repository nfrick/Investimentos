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
    
    public partial class Operacao
    {
        public int OperacaoId { get; set; }
        public int ContaId { get; set; }
        public string Codigo { get; set; }
        public int TipoId { get; set; }
        public System.DateTime Data { get; set; }
        public int QtdPrevista { get; set; }
        public int QtdReal { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorReal { get; set; }
    
        public virtual OperacaoTipo OperacaoTipo { get; set; }
        public virtual AtivoDaConta AtivoDaConta { get; set; }
    }
}
