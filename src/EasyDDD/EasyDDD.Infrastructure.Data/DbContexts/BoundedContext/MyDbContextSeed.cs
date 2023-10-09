using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;

namespace EasyDDD.Infrastructure.Data.DbContexts.BoundedContext
{
    public static class MyDbContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            Guard.Against.Null(builder, nameof(builder));
        }
    }
}
