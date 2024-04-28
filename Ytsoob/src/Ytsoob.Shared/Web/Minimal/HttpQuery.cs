using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Ytsoob.Shared.Abstractions.Web;

namespace Ytsoob.Shared.Web.Minimal;

public record HttpQuery(
    HttpContext HttpContext,
    IMediator Mediator,
    IMapper Mapper,
    CancellationToken CancellationToken
) : IHttpQuery;
