using System;
using EFCompositeKeyTest.DataModel;
using System.Linq;
using System.Net;

namespace EFCompositeKeyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestContext())
            {
                SeedData(db);

                var customer = db.Customers.First();
                customer.Order = new Order { TenantId = 1 };

                db.ChangeTracker.DetectChanges();

                Console.WriteLine("When reaching this point, everythign worked fine!");
                Console.ReadLine();
            }
        }

        private static void SeedData(TestContext db)
        {
            var tenant = new Tenant {Name = "First Tenant"};
            db.Tenants.Add(tenant);

            db.Customers.Add(new Customer
            {
                Name = "First customer",
                TenantId = 1
            });

            db.SaveChanges();
        }
    }
}
