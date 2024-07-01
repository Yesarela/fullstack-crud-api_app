using Microsoft.EntityFrameworkCore;
using API_CleanArchitecture.UseCases.Customers;
using API_CleanArchitecture.UseCases.Customers.List;

namespace API_CleanArchitecture.Infrastructure.Data.Queries;

public class ListCustomerQueryService(AppDbContext _db) : IListCustomerQueryService
{
  public async Task<IEnumerable<CustomerDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    var result = await _db.Database.SqlQuery<CustomerDTO>(
      $"SELECT Id, Name, LastName, Email, Identification, Phone, Address, Gender, Birthday, CreatedDate, LastModifiedDate FROM Customer")
      .ToListAsync();

    return result;
  }
}
