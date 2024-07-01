using Ardalis.Specification;

namespace API_CleanArchitecture.Core.CustomerAggregate.Specifications;

public class CustomerByIdSpec : Specification<Customer>
{
  public CustomerByIdSpec(int customerId)
  {
    Query
        .Where(customer => customer.Id == customerId);
  }
}
