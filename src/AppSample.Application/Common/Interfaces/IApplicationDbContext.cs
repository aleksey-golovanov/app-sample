using AppSample.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AppSample.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Company> Company { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<PaymentType> PaymentType { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
