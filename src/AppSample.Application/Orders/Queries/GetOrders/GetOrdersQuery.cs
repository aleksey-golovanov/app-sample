using AppSample.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppSample.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<OrdersVm>
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string Filter { get; set; }

        public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, OrdersVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<OrdersVm> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
            {
                int totalCount = _context.Order.Count();

                var query = _context.Order.ProjectTo<OrderDto>(_mapper.ConfigurationProvider);

                if (!string.IsNullOrEmpty(request.Filter))
                {
                    string filterString = request.Filter.ToLower();
                    query = query.Where(i =>
                        (!string.IsNullOrEmpty(i.ClientAddress) && i.ClientAddress.ToLower().Contains(filterString)) ||
                        (!string.IsNullOrEmpty(i.CompanyTitle) && i.CompanyTitle.ToLower().Contains(filterString)));
                };

                if (request.Skip != null)
                {
                    query = query.Skip((int)request.Skip);
                }

                if (request.Take != null)
                {
                    query = query.Take((int)request.Take);
                }

                var entities = await query.OrderBy(t => t.OrderDate).ToListAsync(cancellationToken);

                return new OrdersVm { TotalCount = totalCount, Entities = entities };
            }
        }
    }
}
