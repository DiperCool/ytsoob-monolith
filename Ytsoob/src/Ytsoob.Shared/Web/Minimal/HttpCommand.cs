using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Ytsoob.Shared.Abstractions.Web;

namespace Ytsoob.Shared.Web.Minimal;

public record HttpCommand<TRequest>(
    TRequest Request,
    HttpContext HttpContext,
    IMediator Mediator,
    IMapper Mapper,
    CancellationToken CancellationToken
) : IHttpCommand<TRequest>;
