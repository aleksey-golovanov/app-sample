using AppSample.Application.Orders.Commands.CreateOrder;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AppSample.Application.UnitTests.Orders.Commands
{
    public class CreateOrderCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistOrder()
        {
            var command = new CreateOrderCommand
            {
                OrderDate = new DateTime(2020, 1, 1),
                ClientAddress = "Client address",
                CompanyId = 1,
                PaymentTypeId = 1,
                IsCompleted = false
            };

            var handler = new CreateOrderCommand.CreateOrderCommandHandler(Context);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.Order.Find(result);

            entity.ShouldNotBeNull();
            entity.OrderDate.ShouldBe(command.OrderDate);
            entity.ClientAddress.ShouldBe(command.ClientAddress);
            entity.CompanyId.ShouldBe(command.CompanyId);
            entity.PaymentTypeId.ShouldBe(command.PaymentTypeId);
            entity.IsCompleted.ShouldBe(command.IsCompleted);
        }
    }
}
