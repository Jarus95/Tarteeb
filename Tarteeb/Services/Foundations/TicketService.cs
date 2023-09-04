//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using Tarteeb.Brokers.Loggings;
using Tarteeb.Brokers.Storages;
using Tarteeb.Models.Tasks;

namespace Tarteeb.Services.Foundations
{
    public class TicketService : ITicketService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public TicketService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Ticket> AddTicketAsync(Ticket ticket)
        {
           return await this.storageBroker.InsertTicketAsync(ticket);

        }
    }
}
