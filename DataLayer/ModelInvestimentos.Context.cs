﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class InvestimentosEntities : DbContext
    {
        public InvestimentosEntities()
            : base("name=InvestimentosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OperacaoTipo> OperacoesTipos { get; set; }
        public virtual DbSet<Conta> Contas { get; set; }
        public virtual DbSet<Associacao> Associacaos { get; set; }
        public virtual DbSet<Entrada> Entradas { get; set; }
        public virtual DbSet<Saida> Saidas { get; set; }
        public virtual DbSet<AtivoDaConta> AtivosDaConta { get; set; }
    
        public virtual ObjectResult<CompraDisponivelParaVenda> GetComprasDisponiveisParaVenda(Nullable<int> saidaId, Nullable<int> contaId)
        {
            var saidaIdParameter = saidaId.HasValue ?
                new ObjectParameter("SaidaId", saidaId) :
                new ObjectParameter("SaidaId", typeof(int));
    
            var contaIdParameter = contaId.HasValue ?
                new ObjectParameter("ContaId", contaId) :
                new ObjectParameter("ContaId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CompraDisponivelParaVenda>("GetComprasDisponiveisParaVenda", saidaIdParameter, contaIdParameter);
        }
    }
}
