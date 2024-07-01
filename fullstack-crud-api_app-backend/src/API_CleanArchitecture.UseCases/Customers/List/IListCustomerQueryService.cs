namespace API_CleanArchitecture.UseCases.Customers.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListCustomerQueryService
{
  Task<IEnumerable<CustomerDTO>> ListAsync();
}
