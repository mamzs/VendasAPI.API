using System.ComponentModel.DataAnnotations;

namespace VendasAPI.Models
{
    public class UpdateVendaRequest
    {
        /// <summary>
        /// O ID da venda a ser atualizada.
        /// </summary>
        [Required(ErrorMessage = "O ID da venda é obrigatório.")]
        public Guid VendaId { get; set; }

        /// <summary>
        /// O novo número da venda (opcional).
        /// </summary>
        [StringLength(20, ErrorMessage = "O número da venda deve ter no máximo 20 caracteres.")]
        public string NumeroVenda { get; set; }

        /// <summary>
        /// O ID atualizado do cliente (opcional).
        /// </summary>
        public Guid? ClienteId { get; set; }

        /// <summary>
        /// O ID atualizado da filial (opcional).
        /// </summary>
        public Guid? FilialId { get; set; }

        /// <summary>
        /// A lista de itens a serem atualizados na venda.
        /// </summary>
        public List<UpdateItemVendaRequest> Itens { get; set; }

        /// <summary>
        /// Data atualizada da venda (opcional).
        /// </summary>
        public DateTime? DataVenda { get; set; }

        /// <summary>
        /// Status de cancelamento da venda (opcional).
        /// </summary>
        public bool? Cancelado { get; set; }
    }
}
