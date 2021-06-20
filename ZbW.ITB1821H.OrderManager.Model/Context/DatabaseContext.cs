using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ZbW.ITB1821H.OrderManager.Model.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=UNKNOWN\SQLEXPRESS; Initial Catalog=OrderManager; Trusted_Connection=True;Integrated Security=SSPI;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}