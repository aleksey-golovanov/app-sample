using AppSample.Application.Companies.Queries.GetCompanies;
using AppSample.Infrastructure;
using AutoMapper;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AppSample.Application.UnitTests.Companies.Queries
{
    [Collection("QueryTests")]
    public class GetCompaniesQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCompaniesQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectDtoAndCount()
        {
            var query = new GetCompaniesQuery();

            var handler = new GetCompaniesQuery.GetCompaniesQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeAssignableTo<List<CompanyDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
