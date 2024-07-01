using API_CleanArchitecture.Core.ContributorAggregate;
using API_CleanArchitecture.Core.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API_CleanArchitecture.Infrastructure.Data;

public static class SeedData
{
  public static readonly Contributor Contributor1 = new("Argel Alfaro");

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      if (dbContext.Contributors.Any()) return;   // DB has been seeded
      if (dbContext.Customer.Any()) return;
      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var contributor in dbContext.Contributors)
    {
      dbContext.Remove(contributor);
    }
    dbContext.SaveChanges();

    dbContext.Contributors.Add(Contributor1);

    dbContext.SaveChanges();
  }
}
