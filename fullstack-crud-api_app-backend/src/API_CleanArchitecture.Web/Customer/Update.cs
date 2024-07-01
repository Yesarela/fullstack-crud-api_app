using Ardalis.Result;
using API_CleanArchitecture.UseCases.Customers.Get;
using API_CleanArchitecture.UseCases.Customers.Update;
using FastEndpoints;
using MediatR;

namespace API_CleanArchitecture.Web.Customer;

/// <summary>
/// Update an existing Customer.
/// </summary>
/// <remarks>
/// Update an existing Customer by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateCustomerRequest, UpdateCustomerResponse>
{
  public override void Configure()
  {
    Put(UpdateCustomerRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateCustomerRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateCustomerCommand(request.Id, request.Name!, request.LastName!, request.Email!, request.Identification!, request.Phone!, request.Address!, request.Gender!, request.Birthday!), cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetCustomerQuery(request.CustomerId);

    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateCustomerResponse(new CustomerRecord(dto.Id, dto.Name, dto.LastName, dto.Email, dto.Identification, dto.Phone, dto.Address, dto.Gender, dto.Birthday, dto.CreatedDate, dto.LastModifiedDate));
      return;
    }
  }
}
