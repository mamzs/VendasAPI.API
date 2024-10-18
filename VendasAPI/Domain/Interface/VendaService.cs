using VendasAPI.Domain.Entities;
using VendasAPI.Domain.Events;
using VendasAPI.Infrastructure.Repositories;
using VendasAPI.Models;

namespace VendasAPI.Domain.Interface
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IEventPublisher _eventPublisher;

        public VendaService(IVendaRepository vendaRepository, IEventPublisher eventPublisher)
        {
            _vendaRepository = vendaRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<Guid> CreateVendaAsync(CreateVendaRequest request)
        {
            var venda = new Venda(
                request.NumeroVenda,
                request.ClienteId,
                request.FilialId,
                request.Itens.Select(i => new ItemVenda(i.ProdutoId, i.Quantidade, i.ValorUnitario, i.Desconto)).ToList()
            );

            await _vendaRepository.CreateVendaAsync(venda);
            _eventPublisher.PublishVendaCriada(venda);

            return venda.Id;
        }

        public async Task<Venda> GetVendaByIdAsync(Guid id)
        {
            return await _vendaRepository.GetVendaByIdAsync(id);
        }

        public async Task<bool> CancelVendaAsync(Guid id)
        {
            var venda = await _vendaRepository.GetVendaByIdAsync(id);
            if (venda == null || venda.Cancelado)
                return false;

            venda.CancelarVenda();
            await _vendaRepository.UpdateVendaAsync(venda);
            _eventPublisher.PublishVendaCancelada(venda);

            return true;
        }

        Task<Guid> IVendaService.CreateVendaAsync(CreateVendaRequest request)
        {
            throw new NotImplementedException();
        }

        Task<Venda> IVendaService.GetVendaByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Venda>> IVendaService.GetAllVendasAsync()
        {
            throw new NotImplementedException();
        }

        Task<bool> IVendaService.UpdateVendaAsync(Guid id, UpdateVendaRequest request)
        {
            throw new NotImplementedException();
        }

        Task<bool> IVendaService.CancelVendaAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
