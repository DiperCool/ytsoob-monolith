using Ardalis.Specification;

namespace Ytsoob.Shared.Abstractions.Ef.Repository;

// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T>
    where T : class
{
}
