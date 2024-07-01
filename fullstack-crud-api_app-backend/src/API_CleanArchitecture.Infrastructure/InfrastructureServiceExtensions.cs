using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using API_CleanArchitecture.Core.Interfaces;
using API_CleanArchitecture.Core.Services;
using API_CleanArchitecture.Infrastructure.Data;
using API_CleanArchitecture.Infrastructure.Data.Queries;
using API_CleanArchitecture.Infrastructure.Email;
using API_CleanArchitecture.UseCases.Contributors.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using API_CleanArchitecture.UseCases.Customers.List;

namespace API_CleanArchitecture.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("DefaultConnection");
    Guard.Against.NullOrEmpty(connectionString, nameof(connectionString));
    //Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options =>
     options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));
    /*services.AddDbContext<AppDbContext>(options =>
     options.UseSqlite(connectionString));*/

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    services.AddScoped<IListContributorsQueryService, ListContributorsQueryService>();
    services.AddScoped<IListCustomerQueryService, ListCustomerQueryService>();
    services.AddScoped<IDeleteContributorService, DeleteContributorService>();
    services.AddScoped<IDeleteCustomerService, DeleteCustomerService>();

    services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));

    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
