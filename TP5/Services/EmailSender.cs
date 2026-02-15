using Microsoft.AspNetCore.Identity.UI.Services;

namespace TP5.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(ILogger<EmailSender> logger)
    {
        _logger = logger;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // In development, log the email to console
        _logger.LogInformation($"""
            
            ========== EMAIL SENT ==========
            To: {email}
            Subject: {subject}
            
            {htmlMessage}
            
            ================================
            
            """);

        return Task.CompletedTask;
    }
}
