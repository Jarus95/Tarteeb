//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using Moq;
using Tarteeb.Brokers.Storages;
using Tarteeb.Services.Foundations;

namespace Tarteeb.Tests.Services.Foundations
{
    public partial class TicketServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly ITicketService ticketService;
        public TicketServiceTests()
        {
            storageBrokerMock = new Mock<IStorageBroker>();

            this.ticketService = new TicketService(storageBrokerMock.Object);

        }
    }
}
