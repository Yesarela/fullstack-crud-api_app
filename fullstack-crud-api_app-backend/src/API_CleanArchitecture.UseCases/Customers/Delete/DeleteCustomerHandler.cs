using Ardalis.Result;
using Ardalis.SharedKernel;
using API_CleanArchitecture.Core.Interfaces;

namespace API_CleanArchitecture.UseCases.Customers.Delete;

public class DeleteCustomerHandler(IDeleteCustomerService _deleteCustomerService)
  : ICommandHandler<DeleteCustomerCommand, Result>
{
  public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
  {
    // This Approach: Keep Domain Events in the Domain Model / Core project; this becomes a pass-through
    // This is @ardalis's preferred approach
    return await _deleteCustomerService.DeleteCustomer(request.CustomerId);

    // Another Approach: Do the real work here including dispatching domain events - change the event from internal to public
    // @ardalis prefers using the service above so that **domain** event behavior remains in the **domain model** (core project)
    // var aggregateToDelete = await _repository.GetByIdAsync(request.CustomerId);
    // if (aggregateToDelete == null) return Result.NotFound();

    // await _repository.DeleteAsync(aggregateToDelete);
    // var domainEvent = new CustomerDeletedEvent(request.CustomerId);
    // await _mediator.Publish(domainEvent);
    // return Result.Success();
  }
}
