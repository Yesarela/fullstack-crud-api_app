using Ardalis.Result;
using Ardalis.SharedKernel;
using API_CleanArchitecture.Core.CustomerAggregate;

namespace API_CleanArchitecture.UseCases.Customers.Create;

public class CreateCustomerHandler(IRepository<Customer> _repository)
  : ICommandHandler<CreateCustomerCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateCustomerCommand request,
    CancellationToken cancellationToken)
  {
    var newCustomer = new Customer(request.Name, request.LastName, request.Email, request.Identification, request.Phone, request.Address, request.Gender, request.Birthday);

    var createdItem = await _repository.AddAsync(newCustomer, cancellationToken);

    return createdItem.Id;
  }
}
