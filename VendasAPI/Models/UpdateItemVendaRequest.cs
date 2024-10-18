using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace VendasAPI.Models
{
    public class UpdateItemVendaRequest
    {
        /// <summary>
        /// O ID do item de venda que será atualizado.
        /// </summary>
        [Required(ErrorMessage = "O ID do item de venda é obrigatório.")]
        public Guid ItemVendaId { get; set; }

        /// <summary>
        /// A nova quantidade do produto (opcional).
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int? Quantidade { get; set; }

        /// <summary>
        /// O novo valor unitário do produto (opcional).
        /// </summary>
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor unitário deve ser maior que zero.")]
        public decimal? ValorUnitario { get; set; }

        /// <summary>
        /// O desconto atualizado do item (opcional).
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "O desconto não pode ser negativo.")]
        public decimal? Desconto { get; set; }
    }
}
