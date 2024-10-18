using Microsoft.AspNetCore.Mvc;
using VendasAPI.Domain.Entities;
using VendasAPI.Domain.Interface;
using VendasAPI.Infrastructure.Repositories;
using VendasAPI.Models;

namespace VendasAPI.Controllers
{
    [ApiController]
    [Route("api/vendas")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVenda([FromBody] CreateVendaRequest request)
        {
            var vendaId = await _vendaService.CreateVendaAsync(request);
            return CreatedAtAction(nameof(GetVendaById), new { id = vendaId }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendaById(Guid id)
        {
            var venda = await _vendaService.GetVendaByIdAsync(id);
            if (venda == null)
                return NotFound();

            return Ok(venda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenda(Guid id, [FromBody] UpdateVendaRequest request)
        {
            var result = await _vendaService.UpdateVendaAsync(id, request);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelVenda(Guid id)
        {
            var result = await _vendaService.CancelVendaAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
