using System.Data.Entity;

namespace EFCompositeKeyTest.DataModel
{
    public class TestContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public TestContext() : base("name=TestConnString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasKey(c => new { c.TenantId, c.Id })
                .HasOptional(x => x.Order)
                .WithMany()
                .HasForeignKey(x => new { x.TenantId, x.OrderId });
        }
    }
}
