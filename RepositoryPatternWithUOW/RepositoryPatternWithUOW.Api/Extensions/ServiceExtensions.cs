using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.EF;
using RepositoryPatternWithUOW.EF.Repositories;

namespace RepositoryPatternWithUOW.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
    });
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
    services.Configure<IISOptions>(options =>
    {
    });

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
    services.AddDbContext<ApplicationDbContext>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("DefulteConncation"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        //public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        //    services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddTransient<IUnitOfWork,UnitOfWork>();
    }
}
