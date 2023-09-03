//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using Tarteeb.Brokers.Storages;
using Tarteeb.Models.Tasks;

namespace Tarteeb.Services.Foundations
{
    public class TicketService : ITicketService
    {
        private readonly IStorageBroker storageBroker;

        public TicketService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Ticket> AddTicketAsync(Ticket ticket) => 
            await this.storageBroker.InsertTicketAsync(ticket);
    }
}
