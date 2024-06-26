using FluentAssertions;
using NetArchTest.Rules;

namespace ArchitectureTests
{
    public class LayerTests : BaseTest
    {
        [Fact]
        public void Domain_Should_Not_Have_DependencyOnApplication()
        {
            TestResult result = Types.InAssembly(DomainAssembly)
                .Should()
                .NotHaveDependencyOn("Application")
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }
    }
}