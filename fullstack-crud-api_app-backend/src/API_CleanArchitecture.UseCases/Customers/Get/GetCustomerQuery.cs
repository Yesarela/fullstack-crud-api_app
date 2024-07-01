using Ardalis.Result;
using Ardalis.SharedKernel;

namespace API_CleanArchitecture.UseCases.Customers.Get;

public record GetCustomerQuery(int CustomerId) : IQuery<Result<CustomerDTO>>;
