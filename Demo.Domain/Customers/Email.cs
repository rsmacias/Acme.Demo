using System.Net.Mail;

namespace Demo.Domain.Customers;

public record Email
{
    public string Value { get; }

    private Email()
    {
        
    }

    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ApplicationException("The value for the email is invalid");

        try
        {
            var value = new MailAddress(email);
        }
        catch (Exception)
        {
            throw new ApplicationException("The value for the email is invalid");
        }

        Value = email;
    }
}