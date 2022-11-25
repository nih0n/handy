using System;
using System.Threading.Tasks;
using FluentAssertions;
using Handy.Models;
using Xunit;

namespace Handy.Tests;

public class HstpTests : IClassFixture<HandyClientFixture>
{
    readonly HandyClient _handy;

    public HstpTests(HandyClientFixture fixture)
        => _handy = fixture.Client;

    [Fact]
    public async Task Get_device_time()
    {
        var time = await _handy.GetDeviceTimeAsync();

        time.Should().Be(new DateTimeOffset(2021, 4, 22, 8, 32, 35, 381, TimeSpan.Zero));
    }

    [Theory]
    [InlineData(101)]
    [InlineData(-101)]
    public void Give_error_when_offset_is_out_of_range(short value)
    {
#pragma warning disable CA1806
        Action act = () => new Offset(value);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public async Task Get_device_offset()
    {
        var offset = await _handy.GetOffsetAsync();

        offset.Value.Should().Be(-100);
    }

    [Fact]
    public async Task Get_round_trip_delay()
    {
        var roundTripDelay = await _handy.GetRoundTripDelayAsync();

        roundTripDelay.Should().Be(25);
    }
}
