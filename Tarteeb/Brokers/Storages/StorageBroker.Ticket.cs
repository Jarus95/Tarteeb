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

        public async ValueTask<T> InsertTicketAsync<T>(T @object)
        {
            var broker = new StorageBroker(this.configuration);
            broker.Entry(@object).State = EntityState.Added;
            await broker.SaveChangesAsync();
            return @object;

        }
    }
}
