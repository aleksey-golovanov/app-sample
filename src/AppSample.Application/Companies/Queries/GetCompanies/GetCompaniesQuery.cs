using AppSample.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppSample.Application.Companies.Queries.GetCompanies
{
    public class GetCompaniesQuery : IRequest<IList<CompanyDto>>
    {
        public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, IList<CompanyDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetCompaniesQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<IList<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
            {
                return await _context.Company.ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Title)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
