using EasyDDD.Infrastructure.Data.DbContexts.BoundedContext.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EasyDDD.Infrastructure.Data.DbContexts.BoundedContext
{
    public sealed class MyDbContext : BaseDbContext<MyDbContext>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI")
                .ApplyConfiguration(new SystemVersionMap())
                .Seed();
        }
    }
}
