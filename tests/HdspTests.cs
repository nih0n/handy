using System;
using System.Threading.Tasks;
using FluentAssertions;
using Handy.Models;
using Xunit;

namespace Handy.Tests;

public class HdspTests : IClassFixture<HandyClientFixture>
{
    readonly HandyClient _handy;

    public HdspTests(HandyClientFixture fixture)
        => _handy = fixture.Client;

    [Fact]
    public async Task Sets_the_next_absolute_position_and_absolute_velocity_of_the_device()
    {
        var next = new NextXAVA(0, 200, false, false);

        Func<Task> func = () => _handy.SetXAVAAsync(next);

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Sets_the_next_percent_position_and_absolute_velocity_of_the_device()
    {
        var next = new NextXPVA(new(10.5), 200, false, false);

        Func<Task> func = () => _handy.SetXPVAAsync(next);

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Sets_the_next_percent_position_and_percent_velocity_of_the_device()
    {
        var next = new NextXPVP(new(10.5), new(10.5), false, false);

        Func<Task> func = () => _handy.SetXPVPAsync(next);

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Sets_the_next_absolute_position_and_time_of_the_device()
    {
        var next = new NextXAT(0, 0, false, false);

        Func<Task> func = () => _handy.SetXATAsync(next);

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Sets_the_next_percent_position_and_time_of_the_device()
    {
        var next = new NextXPT(new(10.5), 0, false, false);

        Func<Task> func = () => _handy.SetXPTAsync(next);

        await func.Should().NotThrowAsync();
    }
}
