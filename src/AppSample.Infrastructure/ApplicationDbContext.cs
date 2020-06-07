using AppSample.Application.Common.Interfaces;
using AppSample.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSample.Infrastructure
{
    public partial class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.ClientAddress)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Company");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_PaymentType");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
