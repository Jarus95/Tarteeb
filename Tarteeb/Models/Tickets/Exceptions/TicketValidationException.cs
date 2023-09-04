//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using Xeptions;

namespace Tarteeb.Models.Tickets.Exceptions
{
    public class TicketValidationException : Xeption
    {
        public TicketValidationException(Xeption innerExeption)
            :base(message: "Ticket Validation error occured, fix the errors and try again.",
                  innerExeption)
        { }
    }
}
