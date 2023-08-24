
using FluentAssertions;
using Xunit;

namespace Tarteeb.Tests
{
    public class DeleteMe
    {
        bool value = true;

        [Fact]
        public void ShouldReturnTrue() => value.Should().BeTrue();
    }
}