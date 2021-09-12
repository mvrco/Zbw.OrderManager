using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZbW.ITB1821H.OrderManager.Model.Entities;

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

        public virtual DbSet<QuartalsReporting> QuartalsReportings { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public IQueryable<QuartalsReporting> GetQuartalsReportings()
        {
            return QuartalsReportings.FromSqlRaw("Exec dbo.GetQuartalsReports");
        }

        public IQueryable<Invoice> GetInvoices()
        {
            return Invoices.FromSqlRaw("Exec dbo.GetInvoices");
        }

        public IQueryable<ArticleGroup> GetAllArticleGroups() =>
            ArticleGroups.FromSqlRaw("Select * from dbo.GetAllArticleGroupsTVF()").Include(x => x.Articles);

        public IQueryable<ArticleGroup> GetArticleGroupsWithParents(int id) =>
            ArticleGroups.FromSqlRaw("Select * from dbo.GetAllArticleGroupsTVF({0})", id).Include(x => x.Articles);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Settings.Default.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}