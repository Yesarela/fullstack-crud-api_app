using API_CleanArchitecture.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace API_CleanArchitecture.Web.Customer;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class UpdateCustomerValidator : Validator<UpdateCustomerRequest>
{
  public UpdateCustomerValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.LastName)
      .NotEmpty()
      .WithMessage("Lastname is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.Email)
      .NotEmpty()
      .WithMessage("Email is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.Address)
      .NotEmpty()
      .WithMessage("Address is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.Gender)
      .NotEmpty()
      .WithMessage("Gender is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.Phone)
      .NotEmpty()
      .WithMessage("Phone is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.Birthday)
      .NotEmpty()
      .WithMessage("Birthday is required.");
    RuleFor(x => x.CustomerId)
      .Must((args, customerId) => args.Id == customerId)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
  }
}
