﻿using System.Linq;
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

        public DatabaseContext(DbContextOptions options) : base(options) { }

        public IQueryable<ArticleGroup> GetAllArticleGroups() =>
            ArticleGroups.FromSqlRaw("Exec dbo.GetAllArticleGroups");

        public IQueryable<ArticleGroup> GetArticleGroupsWithParents(int id) =>
            ArticleGroups.FromSqlRaw("Exec dbo.GetArticleGroupsWithParents {0}", id);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Properties.Settings.Default.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}