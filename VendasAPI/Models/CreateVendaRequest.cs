using System.ComponentModel.DataAnnotations;

namespace VendasAPI.Models
{
    public class CreateVendaRequest
    {
        [Required(ErrorMessage = "O número da venda é obrigatório.")]
        [StringLength(20, ErrorMessage = "O número da venda deve ter no máximo 20 caracteres.")]
        public string NumeroVenda { get; set; }

        [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "O ID da filial é obrigatório.")]
        public Guid FilialId { get; set; }

        [Required(ErrorMessage = "A venda deve conter ao menos um item.")]
        [MinLength(1, ErrorMessage = "A venda deve conter ao menos um item.")]
        public List<CreateItemVendaRequest> Itens { get; set; }

        public DateTime? DataVenda { get; set; } = DateTime.Now;
    }

}
