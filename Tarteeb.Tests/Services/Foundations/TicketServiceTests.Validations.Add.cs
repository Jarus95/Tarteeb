//=================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free to use to bring order in your workplace
//===============================

using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Tarteeb.Models.Tasks;
using Tarteeb.Models.Tickets.Exceptions;
using Xunit;

namespace Tarteeb.Tests.Services.Foundations
{
    public partial class TicketServiceTests
    {
        [Fact]
        public async Task ShouldValidationExceptionOnAddIfInputNullAndLogItAsync()
        {
            //given
            Ticket NullTicket = null;
            NullTicketException nullTicketException = new NullTicketException();
            var expectedTicketValidationException = 
                new TicketValidationException(nullTicketException);
            


            //when
            ValueTask<Ticket> resultTicketTask = 
                this.ticketService.AddTicketAsync(NullTicket);

            TicketValidationException resultValidationException =
                await Assert.ThrowsAsync<TicketValidationException>(resultTicketTask.AsTask);

            //then
            resultValidationException.Should()
                .BeEquivalentTo(expectedTicketValidationException);

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(
                expectedTicketValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertTicketAsync(It.IsAny<Ticket>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
