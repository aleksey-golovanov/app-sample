using AppSample.Application.Common.Mappings;
using AppSample.Core.Entities;
using AppSample.Infrastructure;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace AppSample.Application.UnitTests
{
    public sealed class QueryTestFixture : IDisposable
    {
        public QueryTestFixture()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            Context = new ApplicationDbContext(options);

            SeedSampleData(Context);

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        private void SeedSampleData(ApplicationDbContext context)
        {
            var companies = new[]
            {
                new Company { CompanyId = 1, Title = "Company 1" },
                new Company { CompanyId = 2, Title = "Company 2" }
            };

            context.Company.AddRange(companies);

            var paymentTypes = new[]
            {
                new PaymentType { PaymentTypeId = 1, Title = "Payment type 1" },
                new PaymentType { PaymentTypeId = 2, Title = "Payment type 2" }
            };

            context.PaymentType.AddRange(paymentTypes);

            context.Order.AddRange(
                new Order
                {
                    OrderId = 1,
                    OrderDate = new DateTime(2020, 1, 2),
                    ClientAddress = "Client address 1",
                    Company = companies[0],
                    PaymentType = paymentTypes[0],
                    IsCompleted = true
                },
                new Order
                {
                    OrderId = 2,
                    OrderDate = new DateTime(2020, 1, 1),
                    ClientAddress = "Client address 2",
                    Company = companies[1],
                    PaymentType = paymentTypes[1],
                    IsCompleted = false
                }
            );

            context.SaveChanges();
        }

        public ApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        public void Dispose()
        {
            Context.Dispose();
        }

        [CollectionDefinition("QueryTests")]
        public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
    }
}
