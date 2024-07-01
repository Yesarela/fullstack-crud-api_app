using Ardalis.Result;
using Ardalis.SharedKernel;

namespace API_CleanArchitecture.UseCases.Customers.List;

public record ListCustomerQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<CustomerDTO>>>;
