using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppSample.Application.Orders.Commands.CreateOrder;
using AppSample.Application.Orders.Queries.GetOrders;
using AppSample.WebUI.Common;
using Microsoft.AspNetCore.Mvc;

namespace AppSample.WebUI.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IList<OrderDto>> Get(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetOrdersQuery(), cancellationToken);
        }

        [HttpPost]
        public async Task<int> Create(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            return await Mediator.Send(command, cancellationToken);
        }
    }
}
