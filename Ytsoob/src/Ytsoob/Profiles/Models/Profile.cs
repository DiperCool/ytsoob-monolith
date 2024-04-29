using Ytsoob.Profiles.ValueObjects;
using Ytsoob.Shared.Core.Domain;

namespace Ytsoob.Profiles.Models;

public class Profile : Entity<long>
{
    public FirstName? FirstName { get; private set; }
    public LastName? LastName { get; private set; }
    public string? Avatar { get; private set; }

    // ef core
    protected Profile() { }

    protected Profile(long profileId, FirstName firstName, LastName lastName)
    {
        Id = profileId;
        FirstName = firstName;
        LastName = lastName;
    }

    protected Profile(long profileId) => Id = profileId;

    public static Profile Of(long profileId, FirstName firstName, LastName lastName) =>
        new(profileId, firstName, lastName);

    public static Profile Of(long profileId) => new(profileId);

    public void Update(FirstName firstName, LastName lastName, string? avatar)
    {
        FirstName = firstName;
        LastName = lastName;
        Avatar = avatar;
    }
}
