using Ardalis.Result;
using Ardalis.SharedKernel;
using API_CleanArchitecture.Core.CustomerAggregate;
using API_CleanArchitecture.Core.CustomerAggregate.Events;
using API_CleanArchitecture.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API_CleanArchitecture.Core.Services;

/// <summary>
/// This is here mainly so there's an example of a domain service
/// and also to demostrate how to fire domain events from a service.
/// </summary>
/// <param name="_repository"></param>
/// <param name="_mediator"></param>
/// <param name="_logger"></param>
public class DeleteCustomerService(IRepository<Customer> _repository,
  //IMediator _mediator,
  ILogger<DeleteCustomerService> _logger) : IDeleteCustomerService
{
  public async Task<Result> DeleteCustomer(int customerId)
  {
    _logger.LogInformation("Deleting Customer {customerId}", customerId);
    Customer? aggregateToDelete = await _repository.GetByIdAsync(customerId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new CustomerDeletedEvent(customerId);
    //await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
