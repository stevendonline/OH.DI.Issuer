﻿using OH.DI.Core.Interfaces;
using OH.DI.Core.DigitalCredentialAggregate;
using OH.DI.Core.DigitalCredentialAggregate.Events;
using OH.DI.Core.DigitalCredentialAggregate.Handlers;
using Moq;
using Xunit;

namespace OH.DI.UnitTests.Core.Handlers;

public class ItemCompletedEmailNotificationHandlerHandle
{
  private ClaimCompletedEmailNotificationHandler _handler;
  private Mock<IEmailSender> _emailSenderMock;

  public ItemCompletedEmailNotificationHandlerHandle()
  {
    _emailSenderMock = new Mock<IEmailSender>();
    _handler = new ClaimCompletedEmailNotificationHandler(_emailSenderMock.Object);
  }

  [Fact]
  public async Task ThrowsExceptionGivenNullEventArgument()
  {
#nullable disable
    Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
#nullable enable
  }

  [Fact]
  public async Task SendsEmailGivenEventInstance()
  {
    await _handler.Handle(new AssuredClaimCompletedEvent(new AssuredClaim()), CancellationToken.None);

    _emailSenderMock.Verify(sender => sender.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
  }
}
