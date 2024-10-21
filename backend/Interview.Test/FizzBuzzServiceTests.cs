using Interview.App.Exceptions;
using Interview.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

// using Moq;

namespace FizzBuzz.Test;

public class FizzBuzzServiceTests
{
    private IHost _host;

    private IMultiplesService _fizzBuzzService;

    // in case i had something to mock...
    // private Mock<IFizzBuzzService> _fizzBuzzService;

    [SetUp]
    public void Setup()
    {
        // _fizzBuzzService = new Mock<IFizzBuzzService>();
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // services.AddSingleton(_fizzBuzzService.Object);
                services.AddSingleton<IMultiplesService, FizzBuzzService>();
                services.AddLogging(x => x.AddConsole());
            })
            .Build();
        _fizzBuzzService = _host.Services.GetRequiredService<IMultiplesService>();
    }

    [Test]
    public void MultipleOfThreeReturnsFizz()
    {
        var expected = "Fizz";
        var result = _fizzBuzzService.MultipleOfThree();

        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void MultipleOfFiveReturnsBuzz()
    {
        var expected = "Buzz";
        var result = _fizzBuzzService.MultipleOfFive();

        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void MultipleOfBothReturnsFizzBuzz()
    {
        var expected = "FizzBuzz";
        var result = _fizzBuzzService.MultipleOfThreeAndFive();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public async Task Execute100ReturnsExpectedResult()
    {
        // i googled the expected results of 100 iterations
        var expected = new List<string>()
            { "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz",
                "11", "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz",
                "Fizz", "22", "23", "Fizz", "Buzz", "26", "Fizz", "28", "29", "FizzBuzz",
                "31", "32", "Fizz", "34", "Buzz", "Fizz", "37", "38", "Fizz", "Buzz",
                "41", "Fizz", "43", "44", "FizzBuzz", "46", "47", "Fizz", "49", "Buzz",
                "Fizz", "52", "53", "Fizz", "Buzz", "56", "Fizz", "58", "59", "FizzBuzz",
                "61", "62", "Fizz", "64", "Buzz", "Fizz", "67", "68", "Fizz", "Buzz",
                "71", "Fizz", "73", "74", "FizzBuzz", "76", "77", "Fizz", "79", "Buzz",
                "Fizz", "82", "83", "Fizz", "Buzz", "86", "Fizz", "88", "89", "FizzBuzz",
                "91", "92", "Fizz", "94", "Buzz", "Fizz", "97", "98", "Fizz", "Buzz" };

        var result = await _fizzBuzzService.Execute(100).ConfigureAwait(false);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void ExecuteThrowsWithRangeOfZero()
    {
        Assert.Throws<InvalidFizzBuzzRangeException>(() => _fizzBuzzService.Execute(0));
    }

    [TearDown]
    public void TearDown()
    {
        _host.Dispose();
    }
}