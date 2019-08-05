using System;
using DataLayer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace InvWeb.DTOs {
    [Serializable]
    public class ContaDto {
        public int ContaId { get; }
        public string Nome { get; }
        public string Banco { get; }
        public string Agencia { get; }
        public string ContaCorrente { get; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Total { get; }
        public List<PatrimonioDto> Patrimonio { get; }


        public ContaDto(Conta conta) {
            ContaId = conta.ContaId;
            Nome = conta.Nome;
            Banco = conta.Banco;
            Agencia = conta.Agencia;
            ContaCorrente = conta.ContaCorrente;
            Patrimonio = conta.PatrimonioTotal.GroupBy(c => c.Tipo).Select(g => new PatrimonioDto(g)).OrderBy(p => p.Tipo).ToList();
            Total = Patrimonio.Sum(p => p.Total);
        }
    }

    [Serializable]
    public class PatrimonioDto {
        public string Tipo { get; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Total { get; }
        public List<PatrimonioItemDto> Itens { get; }

        public PatrimonioDto(IGrouping<string, Patrimonio> g) {
            Tipo = g.Key;
            Itens = g.Select(i => new PatrimonioItemDto(i)).OrderBy(i => i.Item).ToList();
            Total = Itens.Sum(i => i.Valor);
        }
    }

    [Serializable]
    public class PatrimonioItemDto {
        public string Item { get; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; }

        public PatrimonioItemDto(Patrimonio p) {
            Item = p.Item;
            Valor = p.Valor;
        }
    }
}