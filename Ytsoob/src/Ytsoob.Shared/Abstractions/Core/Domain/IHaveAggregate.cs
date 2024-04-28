using Ytsoob.Shared.Abstractions.Core.Domain.Events;

namespace Ytsoob.Shared.Abstractions.Core.Domain;

public interface IHaveAggregate : IHaveDomainEvents, IHaveAggregateVersion
{
}
