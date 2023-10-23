using EasyDDD.Infrastructure.Data.DbContexts.BoundedContext.Mappings;
using EasyDDD.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyDDD.Infrastructure.Data.DbContexts.BoundedContext
{
    public sealed class MyDbContext : BaseDbContext<MyDbContext>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options, dispatcher)
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
