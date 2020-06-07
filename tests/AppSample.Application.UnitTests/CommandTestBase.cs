using AppSample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppSample.Application.UnitTests
{
    public class CommandTestBase : IDisposable
    {
        public CommandTestBase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            Context = new ApplicationDbContext(options);
        }

        public ApplicationDbContext Context { get; }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
