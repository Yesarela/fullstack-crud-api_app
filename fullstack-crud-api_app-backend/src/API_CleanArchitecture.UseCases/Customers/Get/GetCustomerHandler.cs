using Ardalis.Result;
using Ardalis.SharedKernel;
using API_CleanArchitecture.Core.CustomerAggregate;
using API_CleanArchitecture.Core.CustomerAggregate.Specifications;

namespace API_CleanArchitecture.UseCases.Customers.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetCustomerHandler(IReadRepository<Customer> _repository)
  : IQueryHandler<GetCustomerQuery, Result<CustomerDTO>>
{
  public async Task<Result<CustomerDTO>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
  {
    var spec = new CustomerByIdSpec(request.CustomerId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new CustomerDTO(entity.Id, entity.Name, entity.LastName, entity.Email, entity.Identification, entity.Phone, entity.Address, entity.Gender, entity.Birthday, entity.CreatedDate, entity.LastModifiedDate);
  }
}
