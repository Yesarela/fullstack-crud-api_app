using Ardalis.Result;
using API_CleanArchitecture.UseCases.Customers.Delete;
using FastEndpoints;
using MediatR;

namespace API_CleanArchitecture.Web.Customer;

/// <summary>
/// Delete a Customer.
/// </summary>
/// <remarks>
/// Delete a Customer by providing a valid integer id.
/// </remarks>
public class Delete(IMediator _mediator)
  : Endpoint<DeleteCustomerRequest>
{
  public override void Configure()
  {
    Delete(DeleteCustomerRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteCustomerRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteCustomerCommand(request.CustomerId);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
  }
}
