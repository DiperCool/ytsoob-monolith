using Ardalis.Specification;

namespace Ytsoob.Shared.Abstractions.Ef.Repository;

public interface IReadRepository<T> : IReadRepositoryBase<T>
    where T : class
{
}
