//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using System;
using System.Data;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Tarteeb.Models.Tasks;
using Tynamix.ObjectFiller;
using Xunit;

namespace Tarteeb.Tests.Services.Foundations
{
    public partial class TicketServiceTests
    {
        [Fact]
        public async Task ShouldAddAsync()
        {
            //given
            Ticket inputTicket = CreateRandomTicket();
            Ticket persistTicket = inputTicket;
            Ticket expectedTicket = persistTicket.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                 broker.InsertTicketAsync(inputTicket)).ReturnsAsync(persistTicket);
            //when
            Ticket resultTicket = await this.ticketService.AddTicketAsync(inputTicket);

            //then
            resultTicket.Should().BeEquivalentTo(expectedTicket);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertTicketAsync(inputTicket), Times.Once);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
