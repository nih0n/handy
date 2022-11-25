using System;
using System.Threading.Tasks;
using FluentAssertions;
using Handy.Models;
using Xunit;

namespace Handy.Tests;

public class SlideTests : IClassFixture<HandyClientFixture>
{
    readonly HandyClient _handy;

    public SlideTests(HandyClientFixture fixture)
        => _handy = fixture.Client;

    [Fact]
    public void Give_error_when_slide_is_out_of_range()
    {
#pragma warning disable CA1806
        Action act = () => new SlideRange(0, 101);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public async Task Get_slide_settings()
    {
        var slide = await _handy.GetSlideRangeAsync();

        slide.Should().Be(new SlideRange(20, 50));
    }

    [Fact]
    public async Task Set_slide_settings()
    {
        Func<Task> func = () => _handy.SetSlideRangeAsync(new SlideRange(20, 50));

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Get_slide_position_in_millimeters()
    {
        var position = await _handy.GetSlidePositionAsync();

        position.Should().Be(107);
    }
}
