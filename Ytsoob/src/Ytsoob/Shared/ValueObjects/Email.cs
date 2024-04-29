using FluentValidation;

namespace Ytsoob.Shared.ValueObjects;

public record Email
{
    // EF
    private Email(string value)
    {
        Value = value;
    }
    public string Value { get; private set; }

    public static Email Of(string value)
    {
        // validations should be placed here instead of constructor
        new EmailValidator().ValidateAndThrow(value);
        return new Email(value);
    }

    public static implicit operator string(Email value) => value.Value;

    private sealed class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(email => email).NotEmpty();
            RuleFor(email => email).EmailAddress();
        }
    }
}
