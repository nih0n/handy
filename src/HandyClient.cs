using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;
using Handy.Enums;
using Handy.Models;
using Handy.Responses;
using Handy.Routes;
using Information = Handy.Models.Information;

namespace Handy;

public class HandyClient
{
    readonly HttpClient _client;
    readonly JsonSerializerOptions _options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public HandyClient(HttpClient client) => _client = client;


    #region Base
    /// <summary>
    /// Get the current mode of the device.
    /// </summary>
    public async Task<Mode> GetModeAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetAsync<ModeResponse>(BaseRoutes.Mode, cancellationToken);

        return response.Mode;
    }

    /// <summary>
    /// Set the current mode of the device.
    /// </summary>
    public Task SetModeAsync(Mode mode, CancellationToken cancellationToken = default)
        => PutAsync(BaseRoutes.Mode, new { mode }, cancellationToken);

    /// <summary>
    /// Get extended device information.
    /// </summary>
    public Task<Information> GetInformationAsync(CancellationToken cancellationToken = default)
        => GetAsync<Information>(BaseRoutes.Info, cancellationToken);

    /// <summary>
    /// Get various device settings.
    /// </summary>
    public Task<Settings> GetSettingsAsync(CancellationToken cancellationToken = default)
        => GetAsync<Settings>(BaseRoutes.Settings, cancellationToken);

    /// <summary>
    /// Get the device status.
    /// </summary>
    public Task<Status> GetStatusAsync(CancellationToken cancellationToken = default)
        => GetAsync<Status>(BaseRoutes.Status, cancellationToken);

    /// <summary>
    /// Check device connectivity.
    /// </summary>
    public async Task<bool> IsConnectedAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetAsync<ConnectedResponse>(BaseRoutes.Connected, cancellationToken);

        return response.Connected;
    }
    #endregion

    #region Hamp
    /// <summary>
    /// Start alternating motion. No effect if the device is already moving.
    /// </summary>
    public Task StartMotionAsync(CancellationToken cancellationToken = default)
        => PutAsync(HampRoutes.Start, cancellationToken);

    /// <summary>
    /// Stop alternating motion. No effect if the device is already stopped.
    /// </summary>
    public Task StopMotionAsync(CancellationToken cancellationToken = default)
        => PutAsync(HampRoutes.Stop, cancellationToken);

    /// <summary>
    /// Get the HAMP velocity setting of the device in percent.
    /// </summary>
    public async Task<Velocity> GetVelocityAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetAsync<HampVelocityResponse>(HampRoutes.Velocity, cancellationToken);

        return new(response.Velocity);
    }

    /// <summary>
    /// Set the HAMP velocity setting of the alternating motion in percent.
    /// </summary>
    public Task SetVelocityAsync(Velocity velocity, CancellationToken cancellationToken = default)
        => PutAsync(HampRoutes.Velocity, velocity, cancellationToken);

    /// <summary>
    /// Get the HAMP state of the device.
    /// </summary>
    public async Task<HampState> GetHampStateAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetAsync<StateResponse<HampState>>(HampRoutes.State, cancellationToken);

        return response.State;
    }
    #endregion

    #region Hdsp
    /// <summary>
    /// Sets the next absolute position (xa) of the device, and the absolute velocity (va) the device should use to reach the position.
    /// </summary>
    public Task SetXAVAAsync(NextXAVA next, CancellationToken cancellationToken = default)
        => PutAsync(HdspRoutes.XaVa, next, cancellationToken);

    /// <summary>
    /// Sets the next percent position (xp) of the device, and the absolute velocity (va) the device should use to reach the position.
    /// </summary>
    public Task SetXPVAAsync(NextXPVA next, CancellationToken cancellationToken = default)
        => PutAsync(HdspRoutes.XpVa, next, cancellationToken);

    /// <summary>
    /// Sets the next percent position (xp) of the device, and the percent velocity (vp) the device should use to reach the position.
    /// </summary>
    public Task SetXPVPAsync(NextXPVP next, CancellationToken cancellationToken = default)
        => PutAsync(HdspRoutes.XpVp, next, cancellationToken);

    /// <summary>
    /// Sets the next absolute position (xa) of the device, and the time (t) the device should use to reach the position.
    /// </summary>
    public Task SetXATAsync(NextXAT next, CancellationToken cancellationToken = default)
        => PutAsync(HdspRoutes.Xat, next, cancellationToken);

    /// <summary>
    /// Sets the next percent position (xp) of the device, and the time (t) the device should use to reach the position.
    /// </summary>
    public Task SetXPTAsync(NextXPT next, CancellationToken cancellationToken = default)
        => PutAsync(HdspRoutes.Xpt, next, cancellationToken);
    #endregion

    #region Hssp
    /// <summary>
    /// Start script playing from a specified time index.
    /// For the script and a video to be correctly synchronized, the client must provide a client-side-estimated-server-time.
    /// </summary>
    /// <param name="startTime">The time index to start playing from in milliseconds.</param>
    /// <param name="estimatedServerTime">The client side estimated server time in milliseconds (Unix Epoch).</param>
    public Task StartScriptAsync(long startTime, long estimatedServerTime, CancellationToken cancellationToken = default)
        => PutAsync(HsspRoutes.Start, new { estimatedServerTime, startTime }, cancellationToken);

    /// <summary>
    /// Stop script playing.
    /// </summary>
    public Task StopScriptAsync(CancellationToken cancellationToken = default)
        => PutAsync(HsspRoutes.Stop, cancellationToken);

#nullable enable
    /// <summary>
    /// Setup script synchronization.
    /// </summary>
    public Task SetupScriptAsync(Uri url, string? sha256, CancellationToken cancellationToken = default)
        => PutAsync(HsspRoutes.Setup, new { url, sha256 }, cancellationToken);
#nullable disable

    /// <summary>
    /// Get the HSSP loop setting of the device.
    /// </summary>
    public async Task<bool> GetLoopSettingAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetAsync<LoopSettingResponse>(HsspRoutes.Loop, cancellationToken);

        return response.Activated;
    }

    /// <summary>
    /// Set the HSSP loop setting of the device.
    /// If looping is enabled, the device will start replaying the script from the beginning when the end of the script is reached.
    /// </summary>
    public Task SetLoopSettingAsync(bool activated, CancellationToken cancellationToken = default)
        => PutAsync(HsspRoutes.Loop, new { activated }, cancellationToken);

    /// <summary>
    /// Get the HSSP state of the device.
    /// </summary>
    public async Task<HsspState> GetHsspStateAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetAsync<StateResponse<HsspState>>(HsspRoutes.State, cancellationToken);

        return response.State;
    }
    #endregion

    #region Hstp
    /// <summary>
    /// Get the current time of the device.
    /// When the device and the server time is synchronized, this will be the server time estimated by the device.
    /// </summary>
    public async Task<DateTimeOffset> GetDeviceTimeAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetAsync<DeviceTimeResponse>(HstpRoutes.Time, cancellationToken);

        return DateTimeOffset.FromUnixTimeMilliseconds(response.Time);
    }

    /// <summary>
    /// Get the HSTP offset of the device.
    /// </summary>
    public async Task<Offset> GetOffsetAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetAsync<OffsetResponse>(HstpRoutes.Offset, cancellationToken);

        return new(response.Offset);
    }

    /// <summary>
    /// Set the HSTP offset of the device.
    /// </summary>
    public Task SetOffsetAsync(Offset offset, CancellationToken cancellationToken = default)
        => PutAsync(HstpRoutes.Offset, offset, cancellationToken);

    /// <summary>
    /// Get the round-trip-delay-time (rtd) between the device and the server.
    /// The rtd is calculated when the synchronization of the server and device time is triggered.
    /// </summary>
    public async Task<long> GetRoundTripDelayAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetAsync<RoundTripDelayResponse>(HstpRoutes.RoundTripDelay, cancellationToken);

        return response.Timestamp;
    }

    /// <summary>
    /// Syncronizes the device with the server clock.
    /// </summary>
    /// <param name="syncCount">The number of round-trip samples to use in synchronization.</param>
    /// <param name="outliers">The number of sample outliers to discard in synchronization.</param>
    public async Task SyncronizeWithServerTimeAsync(uint? syncCount, uint? outliers, CancellationToken cancellationToken = default)
    {
        var uri = new Uri(_client.BaseAddress, HstpRoutes.Sync);
        var builder = new UriBuilder(uri.AbsoluteUri);

        var query = HttpUtility.ParseQueryString(builder.Query);

        if (syncCount.HasValue)
            query.Add(nameof(syncCount), syncCount.ToString());

        if (outliers.HasValue)
            query.Add(nameof(outliers), outliers.ToString());

        builder.Query = query.ToString();

        await GetAsync(builder.Uri.ToString(), cancellationToken);
    }
    #endregion

    #region Slide
    /// <summary>
    /// Get the slide min and max position.
    /// </summary>
    public Task<SlideRange> GetSlideRangeAsync(CancellationToken cancellationToken = default)
        => GetAsync<SlideRange>(SlideRoutes.Slide, cancellationToken);

    /// <summary>
    /// Set the slide min and max position.
    /// The slide min and max position decides the range of the movement of the slide.
    /// </summary>
    public Task SetSlideRangeAsync(SlideRange range, CancellationToken cancellationToken = default)
        => PutAsync(SlideRoutes.Slide, range, cancellationToken);

    /// <summary>
    /// Get the current slide position in millimeters (mm).
    /// </summary>
    public async Task<int> GetSlidePositionAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetAsync<SlidePositionResponse>(SlideRoutes.SlideMillimeters, cancellationToken);

        return response.Position;
    }
    #endregion

    #region TimeSync
    /// <summary>
    /// Get current server time.
    /// </summary>
    public async Task<DateTime> GetServerTimeAsync(CancellationToken cancellationToken = default)
    {
        var response = await GetAsync<ServerTimeResponse>(TimeSyncRoutes.ServerTime, cancellationToken);

        return DateTimeOffset.FromUnixTimeMilliseconds(response.ServerTime).UtcDateTime;
    }
    #endregion

    private async Task GetAsync(string url, CancellationToken cancellationToken = default)
    {
        var json = await _client.GetStringAsync(url, cancellationToken: cancellationToken);

        ResponseHandler.EnsureSuccess(json);
    }

    private async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken = default)
    {
        var json = await _client.GetStringAsync(url, cancellationToken: cancellationToken);

        ResponseHandler.EnsureSuccess(json);

        return JsonSerializer.Deserialize<T>(json);
    }

    private async Task PutAsync(string url, CancellationToken cancellationToken = default)
    {
        var response = await _client.PutAsJsonAsync(url, _options, cancellationToken);

        var json = await response.Content.ReadAsStringAsync(cancellationToken);

        ResponseHandler.EnsureSuccess(json);
    }

    private async Task PutAsync(string url, object payload, CancellationToken cancellationToken = default)
    {
        var response = await _client.PutAsJsonAsync(url, payload, _options, cancellationToken);

        var json = await response.Content.ReadAsStringAsync(cancellationToken);

        ResponseHandler.EnsureSuccess(json);
    }
}
