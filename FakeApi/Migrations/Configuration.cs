namespace FakeApi.Migrations
{
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FakeApi.Model.FakeApiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        internal static Action<SqlServerDbContextOptionsBuilder>? GetConnectionString(string v)
        {
            throw new NotImplementedException();
        }

        protected override void Seed(FakeApi.Model.FakeApiDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
