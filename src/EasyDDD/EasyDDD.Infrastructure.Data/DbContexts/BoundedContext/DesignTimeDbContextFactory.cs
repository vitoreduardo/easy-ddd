namespace EasyDDD.Infrastructure.Data.DbContexts.BoundedContext
{
    public class DesignTimeDbContextFactory : BaseDesignTimeDbContextFactory<MyDbContext>
    {
        public DesignTimeDbContextFactory()
            : base("MyDbContextConnection")
        {

        }

        public override MyDbContext CreateDbContext(string[] args)
        => new MyDbContext(Options, null);
    }
}
