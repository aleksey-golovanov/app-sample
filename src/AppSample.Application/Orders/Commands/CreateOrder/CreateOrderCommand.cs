using AppSample.Application.Common.Interfaces;
using AppSample.Core.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppSample.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<int>
    {
        public DateTime OrderDate { get; set; }
        public string ClientAddress { get; set; }
        public int CompanyId { get; set; }
        public int PaymentTypeId { get; set; }
        public bool IsCompleted { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateOrderCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var order = new Order
                {
                    OrderDate = request.OrderDate,
                    ClientAddress = request.ClientAddress,
                    CompanyId = request.CompanyId,
                    PaymentTypeId = request.PaymentTypeId,
                    IsCompleted = request.IsCompleted
                };

                _context.Order.Add(order);

                await _context.SaveChangesAsync(cancellationToken);

                return order.OrderId;
            }
        }
    }
}
