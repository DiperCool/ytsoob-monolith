namespace Ytsoob.Profiles.ValueObjects;

public class FirstName
{
    protected FirstName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static FirstName Of(string value)
    {
        if (value.Length > 15)
        {
            throw new ArgumentException("Length of last name cant be exceeded 15");
        }

        return new FirstName(value);
    }

    public static implicit operator string(FirstName value) => value.Value;
}
