using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RepositoryPatternWithUOW.EF;

namespace RepositoryPatternWithUOW.Api.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(configuration.GetConnectionString("DefulteConncation"),
                    b => b.MigrationsAssembly("RepositoryPatternWithUOW.EF"));

                return new ApplicationDbContext(builder.Options);
            }
        }
    }
}
