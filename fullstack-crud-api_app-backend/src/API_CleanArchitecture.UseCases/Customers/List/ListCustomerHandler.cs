using Ardalis.Result;
using Ardalis.SharedKernel;

namespace API_CleanArchitecture.UseCases.Customers.List;

public class ListCustomerHandler(IListCustomerQueryService _query)
  : IQueryHandler<ListCustomerQuery, Result<IEnumerable<CustomerDTO>>>
{
  public async Task<Result<IEnumerable<CustomerDTO>>> Handle(ListCustomerQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
