using VendasAPI.Domain.Entities;
using VendasAPI.Models;

namespace VendasAPI.Domain.Interface
{
    public interface IVendaService
    {
        Task<Guid> CreateVendaAsync(CreateVendaRequest request);
        Task<Venda> GetVendaByIdAsync(Guid id);
        Task<IEnumerable<Venda>> GetAllVendasAsync();
        Task<bool> UpdateVendaAsync(Guid id, UpdateVendaRequest request);
        Task<bool> CancelVendaAsync(Guid id);
    }
}
