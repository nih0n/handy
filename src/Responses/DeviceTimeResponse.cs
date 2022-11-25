using System.Text.Json.Serialization;

namespace Handy.Responses;

internal class DeviceTimeResponse
{
    [JsonPropertyName("time")]
    public long Time { get; init; }
}
