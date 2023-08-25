//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using Microsoft.EntityFrameworkCore;
using Tarteeb.Models.Tasks;

namespace Tarteeb.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Ticket> Tickets { get; set; }

        public async ValueTask<Ticket> InsertTicketAsync(Ticket ticket) =>
            await InsertAsync(ticket);

        public IQueryable<Ticket> SelectAllTicket() =>
            SelectAllAsync<Ticket>();


        public async ValueTask<Ticket> DeleteTicketAsync(Ticket ticket) =>
            await DeleteAsync(ticket);

        public async ValueTask<Ticket> SelectByIdTicket(Guid id) =>
            await SelectByIdAsync<Ticket>();

    }
}
