using API_CleanArchitecture.UseCases.Customers.Create;
using FastEndpoints;
using MediatR;

namespace API_CleanArchitecture.Web.Customer;

/// <summary>
/// Create a new Customer
/// </summary>
/// <remarks>
/// Creates a new Customer given a name.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateCustomerRequest, CreateCustomerResponse>
{
  public override void Configure()
  {
    Post(CreateCustomerRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      // XML Docs are used by default but are overridden by these properties:
      //s.Summary = "Create a new Customer.";
      //s.Description = "Create a new Customer. A valid name is required.";
      s.ExampleRequest = new CreateCustomerRequest { Name = "Customer Name" };
    });
  }

  public override async Task HandleAsync(
    CreateCustomerRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateCustomerCommand(request.Name!, request.LastName!, request.Email!, request.Identification!,request.Phone!,request.Address!,request.Gender!, request.Birthday!,request.CreatedDate!,request.LastModifiedDate!), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CreateCustomerResponse(result.Value, request.Name!, request.LastName!, request.Email!, request.Identification!, request.Phone!, request.Address!, request.Gender!, request.Birthday!, request.CreatedDate!, request.LastModifiedDate!);
      return;
    }
  }
}
