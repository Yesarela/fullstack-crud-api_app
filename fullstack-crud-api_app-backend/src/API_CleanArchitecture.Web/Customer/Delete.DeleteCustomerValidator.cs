using FastEndpoints;
using FluentValidation;

namespace API_CleanArchitecture.Web.Customer;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeleteCustomerValidator : Validator<DeleteCustomerRequest>
{
  public DeleteCustomerValidator()
  {
    RuleFor(x => x.CustomerId)
      .GreaterThan(0);
  }
}
