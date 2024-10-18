using VendasAPI.Domain.Entities;
using VendasAPI.Domain.Interface;
using VendasAPI.Models;

namespace VendasAPI.Infrastructure.Repositories
{
    public interface IVendaRepository
    {
        Task<Venda> GetVendaByIdAsync(Guid id);
        Task<bool> CancelVendaAsync(Guid id);
        Task<Guid> CreateVendaAsync(Venda venda);
        Task<IEnumerable<Venda>> GetAllVendasAsync();
        Task<bool> UpdateVendaAsync(Venda venda);
  


    }
}