using AppSample.Application.Common.Interfaces;
using AppSample.Core.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppSample.Infrastructure
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(IApplicationDbContext context)
        {
            if (context.PaymentType.Count() == 0)
            {
                context.PaymentType.AddRange(
                    new PaymentType { Title = "Credit card" },
                    new PaymentType { Title = "Cash" }
               );
            }

            if (context.Company.Count() == 0)
            {
                context.Company.AddRange(
                    new Company { Title = "Company 1" },
                    new Company { Title = "Company 2" }
                );
            }

            await context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
