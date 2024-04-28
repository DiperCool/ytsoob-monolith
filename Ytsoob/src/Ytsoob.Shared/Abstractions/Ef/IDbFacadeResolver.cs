using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ytsoob.Shared.Abstractions.Ef;

public interface IDbFacadeResolver
{
    DatabaseFacade Database { get; }
}
