//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using Tarteeb.Models.Tasks;

namespace Tarteeb.Services.Foundations
{
    public interface ITicketService
    {
       ValueTask<Ticket> AddTicketAsync(Ticket ticket);
    }
}