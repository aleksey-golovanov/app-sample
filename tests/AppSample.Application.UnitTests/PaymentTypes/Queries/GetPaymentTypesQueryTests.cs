using AppSample.Application.PaymentTypes.Queries.GetPaymentTypes;
using AppSample.Infrastructure;
using AutoMapper;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AppSample.Application.UnitTests.PaymentTypes.Queries
{
    [Collection("QueryTests")]
    public class GetPaymentTypesQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPaymentTypesQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectDtoAndCount()
        {
            var query = new GetPaymentTypesQuery();

            var handler = new GetPaymentTypesQuery.GetPaymentTypesQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeAssignableTo<List<PaymentTypeDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
