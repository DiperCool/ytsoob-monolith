namespace Ytsoob.Ytsoobers.ValueObjects;

public class Username
{
    protected Username(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Username Of(string value)
    {
        int lengthExceed = 20;
        if (value.Length > lengthExceed)
        {
            throw new ArgumentException($"Length of value cant be exceeded {lengthExceed}");
        }

        return new Username(value);
    }

    public static implicit operator string(Username value) => value.Value;
}
