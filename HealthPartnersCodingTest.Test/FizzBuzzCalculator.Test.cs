using System;
using System.Collections.Generic;
using System.IO;
using HealthPartnersCodingTest.Interfaces;
using Moq;
using Xunit;

namespace HealthPartnersCodingTest.Test
{
    public class FizzBuzzCalculatorTest
    {
        [Fact]
        public void ProcessCorrectly()
        {
            // Arrange
            var outputString = "Testing!";
            var services = new List<IFizzBuzzService>();
            var fizzServiceMock = new Mock<IFizzBuzzService>();

            fizzServiceMock.Setup(x => x.IsValid(1)).Returns(true);
            fizzServiceMock.Setup(x => x.GetStringValue()).Returns(outputString);
            services.Add(fizzServiceMock.Object);

            var calculator = new FizzBuzzCalculator(1, services);

            var originalConsoleOut = Console.Out;
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act 
            calculator.ProcessValue(1);

            // Assert 
            string consoleOutput = sw.ToString();
            Assert.Contains(outputString, consoleOutput);

            // Cleanup
            Console.SetOut(originalConsoleOut);
            sw.Dispose();
        }

        [Fact]
        public void PrintsNumber()
        {
            // Arrange
            var outputString = "Testing!";
            var services = new List<IFizzBuzzService>();
            var fizzServiceMock = new Mock<IFizzBuzzService>();

            fizzServiceMock.Setup(x => x.IsValid(1)).Returns(false);
            fizzServiceMock.Setup(x => x.GetStringValue()).Returns(outputString);
            services.Add(fizzServiceMock.Object);

            var calculator = new FizzBuzzCalculator(1, services);

            var originalConsoleOut = Console.Out;
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act 
            calculator.ProcessValue(1);

            // Assert 
            string consoleOutput = sw.ToString();
            Assert.Contains("1", consoleOutput);

            // Cleanup
            Console.SetOut(originalConsoleOut);
            sw.Dispose();
        }

        [Fact]
        public void LoopsCorrectly()
        {
            // Arrange
            var count = 50;
            var outputString = "Testing!";
            var services = new List<IFizzBuzzService>();
            var fizzServiceMock = new Mock<IFizzBuzzService>();

            fizzServiceMock.Setup(x => x.IsValid(It.IsAny<int>())).Returns(true);
            fizzServiceMock.Setup(x => x.GetStringValue()).Returns(outputString);
            services.Add(fizzServiceMock.Object);

            var calculator = new FizzBuzzCalculator(count, services);

            // Act 
            calculator.Calculate();

            // Assert 
            fizzServiceMock.Verify(x => x.IsValid(It.IsAny<int>()), Times.Exactly(count));

        }
    }
}
