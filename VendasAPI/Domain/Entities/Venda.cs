using Serilog;
using System.ComponentModel.DataAnnotations;

namespace VendasAPI.Domain.Entities
{
    public class Venda
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string NumeroVenda { get; set; }

        [Required]
        public Guid ClienteId { get; set; }

        [Required]
        public Guid FilialId { get; set; }

        public DateTime DataVenda { get; set; }
        public bool Cancelado { get; set; }

        public decimal ValorTotal { get; set; }

        // Relação com os itens de venda
        public ICollection<ItemVenda> Itens { get; set; }

        public Venda(string numeroVenda, Guid clienteId, Guid filialId, List<ItemVenda> itens)
        {
            if (string.IsNullOrWhiteSpace(numeroVenda)) throw new ArgumentException("Número da venda é obrigatório.");
            if (itens == null || !itens.Any()) throw new ArgumentException("A venda deve conter ao menos um item.");

            Id = Guid.NewGuid();
            NumeroVenda = numeroVenda;
            DataVenda = DateTime.Now;
            ClienteId = clienteId;
            FilialId = filialId;
            Itens = itens;

            CalcularValorTotal();
        }

        public void CancelarVenda()
        {
            var Cancelada = true;
            Log.Information("Venda {NumeroVenda} foi cancelada.", NumeroVenda);
        }

        private void CalcularValorTotal()
        {
            ValorTotal = Itens.Sum(item => item.CalcularValorTotal());
        }
    }
}
