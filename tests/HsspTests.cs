using System;
using System.Threading.Tasks;
using FluentAssertions;
using Handy.Enums;
using Xunit;

namespace Handy.Tests;

public class HsspTests : IClassFixture<HandyClientFixture>
{
    readonly HandyClient _handy;

    public HsspTests(HandyClientFixture fixture)
        => _handy = fixture.Client;

    [Fact]
    public async Task Start_playing_script()
    {
        var estimatedServerTime = 1619080355381;
        var startTime = 0;

        Func<Task> func = () => _handy.StartScriptAsync(estimatedServerTime, startTime);

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Stop_playing_script()
    {
        Func<Task> func = () => _handy.StopScriptAsync();

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Setup_script_synchronization()
    {
        var url = new Uri("https://sweettecheu.s3.eu-central-1.amazonaws.com/scripts/admin/dataset.csv");
        var sha265 = "cc8c4129276cd80bb6cbfe7f968b22708240a8afcac9c7c0cbcce7f6c6064927";

        Func<Task> func = () => _handy.SetupScriptAsync(url, sha265);

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Get_loop_setting()
    {
        var loopSetting = await _handy.GetLoopSettingAsync();

        loopSetting.Should().BeFalse();
    }

    [Fact]
    public async Task Set_loop_setting()
    {
        Func<Task> func = () => _handy.SetLoopSettingAsync(true);

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Get_device_script_state()
    {
        var state = await _handy.GetHsspStateAsync();

        state.Should().Be(HsspState.Stopped);
    }
}
