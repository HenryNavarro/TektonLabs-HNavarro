using Ardalis.SharedKernel;
using FluentAssertions;
using NSubstitute;
using Practice.Core.ContributorAggregate;
using Practice.UseCases.Contributors.Create;
using Xunit;

namespace Practice.UnitTests.UseCases.Products;
public class CreateProductHandlerHandle
{
  private readonly IRepository<Product> _repository = Substitute.For<IRepository<Product>>();
  private CreateProductHandler _handler;

  public CreateProductHandlerHandle()
  {
    _handler = new CreateContributorHandler(_repository);
  }

  private Contributor CreateContributor()
  {
    return new Contributor(_testName);
  }

  [Fact]
  public async Task ReturnsSuccessGivenValidName()
  {
    _repository.AddAsync(Arg.Any<Contributor>(), Arg.Any<CancellationToken>())
      .Returns(Task.FromResult(CreateContributor()));
    var result = await _handler.Handle(new CreateContributorCommand(_testName), CancellationToken.None);

    result.IsSuccess.Should().BeTrue();
  }
}
