using Insurance.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Infrastructure.Persistence
{
    public class InsuranceDbContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<InsuranceClaim> InsuranceClaims { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }

        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contract>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Contract>()
                .HasMany(c => c.Policies)
                .WithOne()
                .HasForeignKey(p => p.ContractId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Policy>()
                .HasKey(p => p.Id);


            modelBuilder.Entity<Policy>()
                .HasMany(p => p.Claims)
                .WithOne()
                .HasForeignKey(ic => ic.PolicyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InsuranceClaim>()
                .HasKey(ic => ic.Id);

            modelBuilder.Entity<InsuranceClaim>()
                .HasOne<Policy>()
                .WithMany(p => p.Claims)
                .HasForeignKey(ic => ic.PolicyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PolicyType>()
                .HasKey(pt => pt.Id);

            modelBuilder.Entity<Policy>()
                .HasOne(p => p.PolicyType)
                .WithOne()
                .HasForeignKey<Policy>(p => p.PolicyTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }

}
