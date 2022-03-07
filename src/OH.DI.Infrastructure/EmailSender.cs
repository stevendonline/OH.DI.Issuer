using System.Net.Mail;
using OH.DI.Core.Interfaces;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using IdentityUI = Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace OH.DI.Infrastructure;

public class EmailSender : IEmailSender, IdentityUI.IEmailSender 
{
  private readonly ILogger<EmailSender> _logger;
  private readonly IConfiguration _config;

  public EmailSender(ILogger<EmailSender> logger, IConfiguration config)
  {
    _logger = logger;
    _config = config;
  }

  public async Task SendEmailAsync(string to, string from, string subject, string body)
  {
    /*var emailClient = new SmtpClient("localhost");
    var message = new MailMessage
    {
      From = new MailAddress(from),
      Subject = subject,
      Body = body
    };
    message.To.Add(new MailAddress(to));
    await emailClient.SendMailAsync(message); */
    var apiKey = _config["SENDGRID_API_KEY"];
    await Execute(to, subject, body, apiKey);
    _logger.LogWarning($"Sending email to {to} from {from} with subject {subject}.");    
  }

  static async Task Execute(string toEmail, string sub, string htmlMessage, string apiKey)
  {
    //var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");    
    var client = new SendGridClient(apiKey);
    var from = new EmailAddress("stevend_online@hotmail.com", "Example User");
    var subject = sub;
    var to = new EmailAddress(toEmail, "Example User");
    var plainTextContent = "and easy to do anywhere, even with C#";
    var htmlContent = htmlMessage;
    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
    var response = await client.SendEmailAsync(msg);
  }

  async Task IdentityUI.IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
  {
    var apiKey = _config["SENDGRID_API_KEY"];
    await Execute(email, subject, htmlMessage, apiKey);
  }
}
