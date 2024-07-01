using Ardalis.SharedKernel;

namespace API_CleanArchitecture.Core.CustomerAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a contributor is deleted.
/// The DeleteContributorService is used to dispatch this event.
/// </summary>
internal sealed class CustomerDeletedEvent(int customerId) : DomainEventBase
{
  public int CustomerId { get; init; } = customerId;
}
