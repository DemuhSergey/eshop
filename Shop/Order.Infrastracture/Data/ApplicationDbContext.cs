using Microsoft.EntityFrameworkCore;
using Order.Application.DbContext;
using Order.Domain.Models;
using System.Reflection;

namespace Order.Infrastracture.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Domain.Models.Order> Orders => Set<Domain.Models.Order>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
