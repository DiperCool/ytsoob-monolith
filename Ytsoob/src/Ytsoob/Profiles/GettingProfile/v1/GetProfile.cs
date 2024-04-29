using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Ytsoob.Profiles.Dtos;
using Ytsoob.Shared.Abstractions.Core.CQRS;
using Ytsoob.Shared.Abstractions.Web;
using Ytsoob.Shared.Core.Exceptions;
using Ytsoob.Shared.Data;
using Ytsoob.Shared.Securiry;
using Ytsoob.Ytsoobers.Models;

namespace Ytsoob.Profiles.GettingProfile.v1;

public record GetProfile() : ICommand<ProfileDto>;

public class GetProfileEndpoint : IMinimalEndpoint
{
    public string GroupName => ProfilesConfig.Tag;
    public string PrefixRoute => ProfilesConfig.ProfilesPrefixUri;
    public double Version => 1.0;

    public RouteHandlerBuilder MapEndpoint(IEndpointRouteBuilder builder)
    {
        return builder
            .MapGet("/", HandleAsync)
            .RequireAuthorization()
            .Produces<ProfileDto>()
            .WithName("GetProfile")
            .WithDisplayName("Get profile.");
    }

    public async Task<IResult> HandleAsync(
        HttpContext context,
        IMediator commandProcessor,
        IMapper mapper,
        CancellationToken cancellationToken
    )
    {
        return Results.Ok(await commandProcessor.Send(new GetProfile(), cancellationToken));
    }
}

public class GetProfileHandler : ICommandHandler<GetProfile, ProfileDto>
{
    private ICurrentUserService _currentUserService;
    private YtsoobDbContext _ytsoobersDbContext;
    private IMapper _mapper;

    public GetProfileHandler(ICurrentUserService currentUserService, YtsoobDbContext ytsoobersDbContext, IMapper mapper)
    {
        _currentUserService = currentUserService;
        _ytsoobersDbContext = ytsoobersDbContext;
        _mapper = mapper;
    }

    public async Task<ProfileDto> Handle(GetProfile request, CancellationToken cancellationToken)
    {
        Ytsoober? ytsoober = await _ytsoobersDbContext.Ytsoobers
            .Include(x => x.Profile)
            .FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken: cancellationToken);
        if (ytsoober == null)
        {
            throw new BadRequestException("Ytsoober not found");
        }
        return _mapper.Map<ProfileDto>(ytsoober.Profile);
    }
}
