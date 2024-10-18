using Bogus;
using FluentAssertions.Equivalency;
using NSubstitute;
using Serilog;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System;
using VendasAPI.Domain.Entities;
using VendasAPI.Domain.Interface;
using VendasAPI.Infrastructure.Repositories;
using Xunit;

namespace VendasAPI.Domain.Events
{
    public interface IEventPublisher
    {
        void PublishVendaCriada(Venda venda);
        void PublishVendaCancelada(Venda venda);
    }

    public class EventPublisher : IEventPublisher
    {
        public void PublishVendaCriada(Venda venda)
        {
            Log.Information("Venda criada: {VendaId}, Número: {NumeroVenda}", venda.Id, venda.NumeroVenda);
        }

        public void PublishVendaCancelada(Venda venda)
        {
            Log.Information("Venda cancelada: {VendaId}, Número: {NumeroVenda}", venda.Id, venda.NumeroVenda);
        }
    }
}