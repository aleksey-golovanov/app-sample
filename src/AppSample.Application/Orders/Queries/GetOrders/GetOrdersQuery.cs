using AppSample.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppSample.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<IList<OrderDto>>
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string Filter { get; set; }

        public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IList<OrderDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IList<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
            {
                return await _context.Order.ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.OrderDate)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
