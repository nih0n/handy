using System.Text.Json.Serialization;

namespace Handy.Responses;

internal class ServerTimeResponse
{
    [JsonPropertyName("serverTime")]
    public long ServerTime { get; init; }
}
