using Ardalis.SharedKernel;
using LazyCache;
using Practice.Core.ProductStatusAggregate;

namespace Practice.Infrastructure.Data;

public class CachedRepositoryDecorator(IReadRepository<ProductStatus> repository, IAppCache cache) : IReadOnlyRepository<ProductStatus>
{
    private const string MyModelCacheKey = "ProductStatus";

  public Task<ProductStatus?> GetByIdAsync(int id)
  {
    string key = MyModelCacheKey + "-" + id;

    return cache.GetOrAddAsync(key
      , async () => await repository.GetByIdAsync(id)
      , DateTimeOffset.Now.AddMinutes(5));
  }

  public Task<List<ProductStatus>> ListAsync()
  {
    return cache.GetOrAddAsync(
        MyModelCacheKey
        , async () => await repository.ListAsync()
        , DateTimeOffset.Now.AddMinutes(5));
  }

}
