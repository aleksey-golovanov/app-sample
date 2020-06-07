using System.Collections.Generic;

namespace AppSample.Application.Orders.Queries.GetOrders
{
    public class OrdersVm
    {
        public int TotalCount { get; set; }
        public IList<OrderDto> Entities { get; set; }
    }
}
