using Microsoft.EntityFrameworkCore;
using VendasAPI.Data;
using VendasAPI.Domain.Entities;

namespace VendasAPI.Infrastructure.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly VendasDbContext _context;

        public VendaRepository(VendasDbContext context)
        {
            _context = context;
        }

        public Task<bool> CancelVendaAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateVendaAsync(Venda venda)
        {
            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Venda>> GetAllVendasAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Venda> GetVendaByIdAsync(Guid id)
        {
            return await _context.Vendas.Include(v => v.Itens).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task UpdateVendaAsync(Venda venda)
        {
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();
        }

        Task<Guid> IVendaRepository.CreateVendaAsync(Venda venda)
        {
            throw new NotImplementedException();
        }

        Task<bool> IVendaRepository.UpdateVendaAsync(Venda venda)
        {
            throw new NotImplementedException();
        }
    }
}
