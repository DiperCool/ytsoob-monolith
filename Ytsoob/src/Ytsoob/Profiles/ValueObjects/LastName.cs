namespace Ytsoob.Profiles.ValueObjects;

public class LastName
{
    protected LastName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static LastName Of(string value)
    {
        if (value.Length > 15)
        {
            throw new ArgumentException("Length of last name cant be exceeded 15");
        }

        return new LastName(value);
    }

    public static implicit operator string(LastName value) => value.Value;
}
