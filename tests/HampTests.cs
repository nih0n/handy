using System;
using System.Threading.Tasks;
using FluentAssertions;
using Handy.Enums;
using Handy.Models;
using Xunit;

namespace Handy.Tests;

public class HampTests : IClassFixture<HandyClientFixture>
{
    readonly HandyClient _handy;

    public HampTests(HandyClientFixture fixture)
        => _handy = fixture.Client;

    [Fact]
    public async Task Start_device_motion()
    {
        Func<Task> func = () => _handy.StartMotionAsync();

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Stop_device_motion()
    {
        Func<Task> func = () => _handy.StopMotionAsync();

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public void Give_error_when_velocity_is_out_of_range()
    {
#pragma warning disable CA1806
        Action act = () => new Velocity(101);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }


    [Fact]
    public async Task Get_device_motion_velocity()
    {
        var velocity = await _handy.GetVelocityAsync();

        velocity.Value.Should().Be(50);
    }

    [Fact]
    public async Task Set_device_motion_velocity()
    {
        var velocity = new Velocity(100);

        Func<Task> func = () => _handy.SetVelocityAsync(velocity);

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Get_device_motion_state()
    {
        var state = await _handy.GetHampStateAsync();

        state.Should().Be(HampState.Moving);
    }
}
