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
            Ticket randomTicket = CreateRandomTicket();
            Ticket inputTicket = randomTicket;
            Ticket persistedTicket = inputTicket;
            //Ticket expectedTicket = new Ticket()
            //{
            //    Id = persistedTicket.Id,
            //    Status = persistedTicket.Status,
            //    AssigneeId = persistedTicket.AssigneeId,
            //    CreatedDate = persistedTicket.CreatedDate,

            //};
            Ticket expectedTicket = persistedTicket.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.InsertTicketAsync(inputTicket))
                    .ReturnsAsync(persistedTicket);
            //when
            Ticket actualTicket = await this.ticketService.AddTicketAsync(inputTicket); //tasodifiy qiymat berib korish
            //then
            actualTicket.Should().BeEquivalentTo(expectedTicket);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertTicketAsync(inputTicket), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();


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
    }
}
