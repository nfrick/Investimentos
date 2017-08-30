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
    
        public virtual DbSet<Operacao> Operacoes { get; set; }
        public virtual DbSet<OperacaoTipo> OperacoesTipos { get; set; }
        public virtual DbSet<AtivoCorrente> AtivosCorrentes { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<OperacaoComRunningSum> OperacoesComRunningSum { get; set; }
        public virtual DbSet<OperacaoDeSaida> OperacoesDeSaida { get; set; }
        public virtual DbSet<Ativo> Ativos { get; set; }
        public virtual DbSet<SerieHistorica> SeriesHistoricas { get; set; }
    
        public virtual ObjectResult<CompraDisponivelParaVenda> GetComprasDisponiveisParaVenda(Nullable<int> vendaId)
        {
            var vendaIdParameter = vendaId.HasValue ?
                new ObjectParameter("VendaId", vendaId) :
                new ObjectParameter("VendaId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CompraDisponivelParaVenda>("GetComprasDisponiveisParaVenda", vendaIdParameter);
        }
    }
}
