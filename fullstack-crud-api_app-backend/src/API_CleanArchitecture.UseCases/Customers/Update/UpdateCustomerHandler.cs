using Ardalis.Result;
using Ardalis.SharedKernel;
using API_CleanArchitecture.Core.CustomerAggregate;

namespace API_CleanArchitecture.UseCases.Customers.Update;

public class UpdateCustomerHandler(IRepository<Customer> _repository)
  : ICommandHandler<UpdateCustomerCommand, Result<CustomerDTO>>
{
  public async Task<Result<CustomerDTO>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
  {
    var existingCustomer = await _repository.GetByIdAsync(request.CustomerId, cancellationToken);
    if (existingCustomer == null)
    {
      return Result.NotFound();
    }

    existingCustomer.UpdateCustomer(request.NewName!, request.NewLastName!, request.NewEmail!, request.NewIdentification!, request.NewPhone!, request.NewAdress!, request.NewGender!, request.NewBirthday!);

    await _repository.UpdateAsync(existingCustomer, cancellationToken);

    return Result.Success(new CustomerDTO(existingCustomer.Id,
      existingCustomer.Name, existingCustomer.LastName, existingCustomer.Email, existingCustomer.Identification, existingCustomer.Phone, existingCustomer.Address, existingCustomer.Gender, existingCustomer.Birthday, existingCustomer.CreatedDate, existingCustomer.LastModifiedDate));
  }
}
