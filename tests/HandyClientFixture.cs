using System;
using System.Net.Http;
using Handy.Enums;
using Handy.Models;
using Moq;
using Moq.Contrib.HttpClient;

namespace Handy.Tests;

public class HandyClientFixture
{
    public HandyClient Client { get; private set; }

    const string BaseUrl = "https://www.handyfeeling.com/api/handy/v2/";
    readonly Mock<HttpMessageHandler> _handler = new(MockBehavior.Strict);

    public HandyClientFixture()
    {
        SetupBase();
        SetupHamp();
        SetupHdsp();
        SetupHstp();
        SetupHssp();
        SetupSlide();

        var client = _handler.CreateClient();

        client.BaseAddress = new Uri(BaseUrl);

        Client = new HandyClient(client);
    }

    private void SetupBase()
    {
        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}mode")
            .ReturnsJsonResponse(new { mode = Mode.Hamp });

        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}mode")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}connected")
            .ReturnsJsonResponse(new { connected = true });

        var settingsFake = new Settings
        {
            Offset = -120,
            Velocity = 50,
            SlideMin = 20,
            SlideMax = 100
        };

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}settings")
            .ReturnsJsonResponse(settingsFake);

        var informationFake = new Information
        {
            Branch = "master",
            Model = "H01",
            FirmwareStatus = FirmwareStatus.UpToDate,
            FirmwareVersion = "3.2.3+c1ddbc7e",
            HardwareVersion = 0,
            SessionId = "01GHT7S65BFDT42V69CY3ZXR73"
        };

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}info")
            .ReturnsJsonResponse(informationFake);

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}status")
            .ReturnsJsonResponse(new Status(Mode.Hamp, HsspState.Playing));

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}servertime")
            .ReturnsJsonResponse(new { serverTime = 1619080355381 });
    }

    private void SetupHamp()
    {
        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hamp/start")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hamp/stop")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}hamp/velocity")
            .ReturnsJsonResponse(new { velocity = 50 });

        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hamp/velocity")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}hamp/state")
            .ReturnsJsonResponse(new { state = HampState.Moving });
    }

    private void SetupHdsp()
    {
        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hdsp/xava")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hdsp/xpva")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hdsp/xpvp")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hdsp/xat")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hdsp/xpt")
            .ReturnsJsonResponse(new { });
    }

    private void SetupHstp()
    {
        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}hstp/time")
            .ReturnsJsonResponse(new { time = 1619080355381 });

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}hstp/offset")
            .ReturnsJsonResponse(new { offset = -100 });

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}hstp/rtd")
            .ReturnsJsonResponse(new { rtd = 25 });
    }

    public void SetupHssp()
    {
        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hssp/start")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hssp/stop")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hssp/setup")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}hssp/loop")
            .ReturnsJsonResponse(new { activated = false });

        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}hssp/loop")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}hssp/state")
            .ReturnsJsonResponse(new { state = 3 });
    }

    private void SetupSlide()
    {
        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}slide")
            .ReturnsJsonResponse(new SlideRange(20, 50));

        _handler
            .SetupRequest(HttpMethod.Put, $"{BaseUrl}slide")
            .ReturnsJsonResponse(new { });

        _handler
            .SetupRequest(HttpMethod.Get, $"{BaseUrl}slide/position/absolute")
            .ReturnsJsonResponse(new { position = 107 });
    }
}
