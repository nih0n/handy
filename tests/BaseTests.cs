using System;
using System.Threading.Tasks;
using FluentAssertions;
using Handy.Enums;
using Handy.Models;
using Xunit;

namespace Handy.Tests;

public class BaseTests : IClassFixture<HandyClientFixture>
{
    readonly HandyClient _handy;

    public BaseTests(HandyClientFixture fixture)
        => _handy = fixture.Client;

    [Fact]
    public async Task Get_device_mode()
    {
        var mode = await _handy.GetModeAsync();

        mode.Should().Be(Mode.Hamp);
    }

    [Fact]
    public async Task Set_device_mode()
    {
        Func<Task> func = () => _handy.SetModeAsync(Mode.Hbsp);

        await func.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Check_device_connectivity()
    {
        var isConnected = await _handy.IsConnectedAsync();

        isConnected.Should().BeTrue();
    }

    [Fact]
    public async Task Get_device_information()
    {
        var information = await _handy.GetInformationAsync();

        information.Should().BeEquivalentTo(new Information
        {
            Branch = "master",
            Model = "H01",
            FirmwareStatus = FirmwareStatus.UpToDate,
            FirmwareVersion = "3.2.3+c1ddbc7e",
            HardwareVersion = 0,
            SessionId = "01GHT7S65BFDT42V69CY3ZXR73"
        });
    }

    [Fact]
    public async Task Get_device_settings()
    {
        var settings = await _handy.GetSettingsAsync();

        settings.Should().BeEquivalentTo(new Settings
        {
            Offset = -120,
            Velocity = 50,
            SlideMin = 20,
            SlideMax = 100
        });
    }

    [Fact]
    public async Task Get_device_status()
    {
        var status = await _handy.GetStatusAsync();

        status.Mode.Should().Be(Mode.Hamp);
    }
}
