using System;
using HealthPartnersCodingTest.Services;
using Xunit;

namespace HealthPartnersCodingTest.Test.Services
{
    public class FizzServiceTest
    {
        [Fact]
        public void IsFizz()
        {
            // arrange
            var fizzService = new FizzService();
            // act
            var fizz = fizzService.GetStringValue();
            //assert
            Assert.Equal("Fizz", fizz);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(20)]
        public void IsValidFizz(int n)
        {
            // arrange
            var fizzService = new FizzService();
            // act
            var isValid = fizzService.IsValid(n);
            //assert
            Assert.True(isValid);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        public void IsInvalidFizz(int n)
        {
            // arrange
            var fizzService = new FizzService();
            // act
            var isValid = fizzService.IsValid(n);
            //assert
            Assert.False(isValid);
        }
    }
}
