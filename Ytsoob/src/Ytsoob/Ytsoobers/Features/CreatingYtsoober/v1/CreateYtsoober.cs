using Ytsoob.Shared.Abstractions.Core.CQRS;
using Ytsoob.Shared.Core.Exceptions;
using Ytsoob.Shared.Data;
using Ytsoob.Shared.ValueObjects;
using Ytsoob.Ytsoobers.Models;
using Ytsoob.Ytsoobers.ValueObjects;

namespace Ytsoob.Ytsoobers.Features.CreatingYtsoober.v1;

public record UserRequest(
    string? UserId,
    string? Username,
    string? Email,
    string? FamilyName,
    string? GivenName,
    string? Name,
    string? Picture
);

public record CreateYtsooberRequest(UserRequest User, string SecretKey);

public record CreateYtsoober(CreateYtsooberRequest Request) : ICommand;

public class CreateYtsooberHandler : ICommandHandler<CreateYtsoober>
{
    private YtsoobDbContext _ytsoobDbContext;

    public CreateYtsooberHandler(YtsoobDbContext ytsoobDbContext)
    {
        _ytsoobDbContext = ytsoobDbContext;
    }

    public async Task Handle(CreateYtsoober request, CancellationToken cancellationToken)
    {
        string secretKey = "gfgfgddgfgfd34dgfsspwppw";
        if (request.Request.SecretKey != secretKey)
        {
            throw new BadRequestException("");
        }

        UserRequest user = request.Request.User;
        Ytsoober ytsoober = Ytsoober.Create(user.UserId, Username.Of(user.Username), Email.Of(user.Email), user.UserId);
        await _ytsoobDbContext.Ytsoobers.AddAsync(ytsoober, cancellationToken);
        await _ytsoobDbContext.SaveChangesAsync(cancellationToken);
    }
}
