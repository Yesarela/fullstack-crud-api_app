using Ardalis.Result;
using API_CleanArchitecture.UseCases.Customers;
using API_CleanArchitecture.UseCases.Customers.List;
using FastEndpoints;
using MediatR;

namespace API_CleanArchitecture.Web.Customer;

/// <summary>
/// List all Customers
/// </summary>
/// <remarks>
/// List all Customers - returns a CustomerListResponse containing the Customers.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<CustomerListResponse>
{
  public override void Configure()
  {
    Get("/Customer");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<CustomerDTO>> result = await _mediator.Send(new ListCustomerQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CustomerListResponse
      {
        Customer = result.Value.Select(c => new CustomerRecord(c.Id, c.Name, c.LastName, c.Email, c.Identification, c.Phone, c.Address, c.Gender, c.Birthday, c.CreatedDate, c.LastModifiedDate)).ToList()
      };
    }
  }
}
