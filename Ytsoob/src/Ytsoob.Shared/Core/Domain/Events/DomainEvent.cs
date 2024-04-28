using Ytsoob.Shared.Abstractions.Core.Domain.Events;

namespace Ytsoob.Shared.Core.Domain.Events;

public record DomainEvent : Event, IDomainEvent
{
    public dynamic AggregateId { get; private set; } = default!;
    public long AggregateSequenceNumber { get; private set; }

    public virtual IDomainEvent WithAggregate(dynamic aggregateId, long version)
    {
        AggregateId = aggregateId;
        AggregateSequenceNumber = version;

        return this;
    }
}
