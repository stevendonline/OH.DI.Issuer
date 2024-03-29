﻿using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using OH.DI.Core.Interfaces;
using OH.DI.Core.DigitalCredentialAggregate.Events;
using MediatR;

namespace OH.DI.Core.DigitalCredentialAggregate.Handlers;

public class ClaimCompletedEmailNotificationHandler : INotificationHandler<AssuredClaimCompletedEvent>
{
  private readonly IEmailSender _emailSender;

  // In a REAL app you might want to use the Outbox pattern and a command/queue here...
  public ClaimCompletedEmailNotificationHandler(IEmailSender emailSender)
  {
    _emailSender = emailSender;
  }

  // configure a test email server to demo this works
  // https://ardalis.com/configuring-a-local-test-email-server
  public Task Handle(AssuredClaimCompletedEvent domainEvent, CancellationToken cancellationToken)
  {
    Guard.Against.Null(domainEvent, nameof(domainEvent));

    return _emailSender.SendEmailAsync("test@test.com", "test@test.com", $"{domainEvent.CompletedClaim.Name} was completed.", domainEvent.CompletedClaim.ToString());
  }
}
