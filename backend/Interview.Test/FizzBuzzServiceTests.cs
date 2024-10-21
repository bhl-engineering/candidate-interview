using Interview.App.Exceptions;
using Interview.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

// using Moq;

namespace Interview.Test;

public class UserServiceTests
{
    private IHost _host;

    private IUserService _userService;

    [SetUp]
    public void Setup()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IUserService, UserService>();
                services.AddSingleton<IDataService, SQLService>();
                services.AddLogging(x => x.AddConsole());
            })
            .Build();
        _userService = _host.Services.GetRequiredService<IUserService>();
    }

    [Test]
    public async Task MultipleOfThreeReturnsFizz()
    {
        var expected = "John";
        var result = await _userService.GetUserByIdAsync(Guid.Parse("28af44d0-cbfd-49b5-963c-1d3fe88f5d9d"));

        Assert.That(result.FirstName, Is.EqualTo(expected));
    }

    [TearDown]
    public void TearDown()
    {
        _host.Dispose();
    }
}