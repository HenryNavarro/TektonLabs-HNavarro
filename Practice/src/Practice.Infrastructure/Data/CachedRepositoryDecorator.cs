using Ardalis.SharedKernel;
using Microsoft.Extensions.Caching.Memory;
using Practice.Core.ProductStatusAggregate;

namespace Practice.Infrastructure.Data;

public class CachedRepositoryDecorator : IReadOnlyRepository<ProductStatus>
{

  private readonly IReadRepository<ProductStatus> _repository;
  private readonly IMemoryCache _cache;
  private const string MyModelCacheKey = "ProductStatus";
  private MemoryCacheEntryOptions cacheOptions;

  // alternatively use IDistributedCache if you use redis and multiple services
  public CachedRepositoryDecorator(IReadRepository<ProductStatus> repository, IMemoryCache cache)
  {
    _repository = repository;
    _cache = cache;

    // 5 min cache
    cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(relative: TimeSpan.FromMinutes(5));
  }

  public Task<ProductStatus?> GetByIdAsync(int id)
  {
    string key = MyModelCacheKey + "-" + id;

    return _cache.GetOrCreateAsync(key, async entry =>
    {
      entry.SetOptions(cacheOptions);
      return await _repository.GetByIdAsync(id);

    });
  }

  public Task<List<ProductStatus>?> ListAsync()
  {
    return _cache.GetOrCreateAsync(MyModelCacheKey, async entry =>
    {
      entry.SetOptions(cacheOptions);
      return await _repository.ListAsync();
    });
  }

}
