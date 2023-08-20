//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using Tarteeb.Models.Tasks;
using Task = Tarteeb.Models.Tasks.Ticket;

namespace Tarteeb.Brokers.Storages
{
    public interface IStorageBroker
    {
        ValueTask<T> InsertTicketAsync<T>(T @object);
    }
}
