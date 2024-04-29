using Ytsoob.Profiles.ValueObjects;
using Ytsoob.Shared.Abstractions.Core;
using Ytsoob.Shared.Core.Domain;
using Ytsoob.Shared.ValueObjects;
using Ytsoob.Ytsoobers.ValueObjects;

namespace Ytsoob.Ytsoobers.Models;

public class Ytsoober : Aggregate<string>
{
    public Email Email { get; private set; } = default!;
    public Username Username { get; private set; }
    public Profiles.Models.Profile Profile { get; private set; }
    public bool CreatingCompleted { get; private set; } = default!;
    public string IdentityId { get; set; }

    protected Ytsoober() { }

    protected Ytsoober(string id, Username username, Email email, string identityId)
    {
        Id = id;
        Email = email;
        IdentityId = identityId;
        Username = username;
        Profile = Profiles.Models.Profile.Of(SnowFlakIdGenerator.NewId());
    }

    public static Ytsoober Create(string id, Username username, Email email, string identityId)
    {
        Ytsoober ytsoober = new Ytsoober(id, username, email, identityId);
        return ytsoober;
    }

    public void UpdateProfile(FirstName firstName, LastName lastName, string? avatar)
    {
        Profile.Update(firstName, lastName, avatar);
    }
}
