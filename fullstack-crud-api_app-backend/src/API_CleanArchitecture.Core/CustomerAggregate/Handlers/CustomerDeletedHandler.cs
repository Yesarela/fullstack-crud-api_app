using API_CleanArchitecture.Core.CustomerAggregate.Events;
using API_CleanArchitecture.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace API_CleanArchitecture.Core.CustomerAggregate.Handlers;

/// <summary>
/// NOTE: Internal because CustomerDeleted is also marked as internal.
/// </summary>
internal class CustomerDeletedHandler(ILogger<CustomerDeletedHandler> logger,
  IEmailSender emailSender) : INotificationHandler<CustomerDeletedEvent>
{
  public async Task Handle(CustomerDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Customer Deleted event for {custgomerId}", domainEvent.CustomerId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Customer Deleted",
                                     $"Customer with id {domainEvent.CustomerId} was deleted.");
  }
}
