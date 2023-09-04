//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using System;
using System.Linq.Expressions;
using Moq;
using Tarteeb.Brokers.Loggings;
using Tarteeb.Brokers.Storages;
using Tarteeb.Models.Tasks;
using Tarteeb.Models.Tickets.Exceptions;
using Tarteeb.Services.Foundations;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Tarteeb.Tests.Services.Foundations
{
    public partial class TicketServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ITicketService ticketService;
        public TicketServiceTests()
        {
            storageBrokerMock = new Mock<IStorageBroker>();
            loggingBrokerMock = new Mock<ILoggingBroker>();

            this.ticketService = new TicketService(
                storageBroker: storageBrokerMock.Object,
                loggingBroker: loggingBrokerMock.Object);

        }

        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();
        private static Filler<Ticket> CreateTicketFiller()
        {
            var filler = new Filler<Ticket>();
            DateTimeOffset dates = GetRandomDateTime();
            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);

            return filler;
        }

        private static Ticket CreateRandomTicket() =>
             CreateTicketFiller().Create();

        private Expression<Func<Exception, bool>> SameExceptionAs(Xeption expectedExeption) =>
            actualException => actualException.SameExceptionAs(expectedExeption);
    }
}
