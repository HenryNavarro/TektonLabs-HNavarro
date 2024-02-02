using Ardalis.SharedKernel;

namespace Practice.Core.ProductStatusAggregate;


public interface IReadOnlyRepository<T> where T : class, IAggregateRoot
{
  Task<T?> GetByIdAsync(int id);
  Task<List<T>?> ListAsync();

}
