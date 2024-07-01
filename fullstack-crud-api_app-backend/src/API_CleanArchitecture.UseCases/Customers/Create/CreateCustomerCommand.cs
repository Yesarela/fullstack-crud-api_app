using System;
using Ardalis.Result;

namespace API_CleanArchitecture.UseCases.Customers.Create;

public record CreateCustomerCommand(string Name, string LastName, string Email, string Identification, string Phone, string Address, string Gender, DateOnly? Birthday, DateTime? CreatedDate, DateTime? LastModifiedDate) : Ardalis.SharedKernel.ICommand<Result<int>>;
