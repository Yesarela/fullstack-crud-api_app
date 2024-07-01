using Ardalis.Result;
using Ardalis.SharedKernel;

namespace API_CleanArchitecture.UseCases.Customers.Delete;

public record DeleteCustomerCommand(int CustomerId) : ICommand<Result>;
