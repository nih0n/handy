using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Handy.Tests;

public class TimeSyncTests : IClassFixture<HandyClientFixture>
{
    readonly HandyClient _handy;

    public TimeSyncTests(HandyClientFixture fixture)
        => _handy = fixture.Client;

    public async Task Get_current_server_time()
    {
        var time = await _handy.GetServerTimeAsync();

        time.Should().Be(new DateTime(2021, 4, 22, 8, 32, 35, 381));
    }
}
