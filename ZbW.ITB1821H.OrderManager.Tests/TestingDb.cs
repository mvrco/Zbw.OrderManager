using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using ZbW.ITB1821H.OrderManager.Model.Context;

namespace ZbW.ITB1821H.OrderManager.Tests
{
    public abstract class TestingDb : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly DatabaseContext DbContext;
        protected readonly DbContextOptionsBuilder OptionsBuilder;

        protected TestingDb()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>()
                    .UseSqlite(_connection);
            DbContext = new DatabaseContext(OptionsBuilder);
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
