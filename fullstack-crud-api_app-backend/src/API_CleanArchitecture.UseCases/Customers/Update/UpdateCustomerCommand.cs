using Ardalis.Result;
using Ardalis.SharedKernel;

namespace API_CleanArchitecture.UseCases.Customers.Update;

public record UpdateCustomerCommand(int CustomerId, string NewName, string NewLastName, string NewEmail, string NewIdentification, string NewPhone, string NewAdress, string NewGender, DateOnly NewBirthday) : ICommand<Result<CustomerDTO>>;
