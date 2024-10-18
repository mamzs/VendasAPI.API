using Bogus;
using FluentAssertions.Equivalency;
using Microsoft.Win32;
using NSubstitute;
using Serilog;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System;
using VendasAPI.Domain.Interface;
using Xunit;
using System.ComponentModel.DataAnnotations;

namespace VendasAPI.Domain.Entities
{
    public class ItemVenda
    {
        public Guid Id { get; set; }

        [Required]
        public Guid ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public decimal ValorUnitario { get; set; }

        public decimal Desconto { get; set; }

        public decimal ValorTotal => Quantidade * ValorUnitario - Desconto;

        // Relação com a venda
        public Guid VendaId { get; set; }
        public Venda Venda { get; set; }

        public ItemVenda(Guid produtoId, int quantidade, decimal valorUnitario, decimal desconto)
        {
            if (quantidade <= 0) throw new ArgumentException("A quantidade deve ser maior que zero.");
            if (valorUnitario <= 0) throw new ArgumentException("O valor unitário deve ser maior que zero.");

            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Desconto = desconto;

            CalcularValorTotal();
        }

        public decimal CalcularValorTotal()
        {
            var ValorTotal = (ValorUnitario * Quantidade) - Desconto;
            return ValorTotal;
        }
    }
}
