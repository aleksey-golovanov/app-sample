using AppSample.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppSample.Application.PaymentTypes.Queries.GetPaymentTypes
{
    public class GetPaymentTypesQuery : IRequest<IList<PaymentTypeDto>>
    {
        public class GetPaymentTypesQueryHandler : IRequestHandler<GetPaymentTypesQuery, IList<PaymentTypeDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetPaymentTypesQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IList<PaymentTypeDto>> Handle(GetPaymentTypesQuery request, CancellationToken cancellationToken)
            {
                return await _context.PaymentType.ProjectTo<PaymentTypeDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
