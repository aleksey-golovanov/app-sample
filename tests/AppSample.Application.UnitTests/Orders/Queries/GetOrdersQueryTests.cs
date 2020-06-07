using AppSample.Application.Orders.Queries.GetOrders;
using AppSample.Infrastructure;
using AutoMapper;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AppSample.Application.UnitTests.Orders.Queries
{
    [Collection("QueryTests")]
    public class GetOrdersQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectDtoAndCount()
        {
            var query = new GetOrdersQuery();

            var handler = new GetOrdersQuery.GetOrdersQueryHandler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeAssignableTo<OrdersVm>();
            result.Entities.Count.ShouldBe(2);
        }
    }
}
