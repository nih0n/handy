using System.Text.Json.Serialization;

namespace Handy.Responses;

internal class RoundTripDelayResponse
{
    [JsonPropertyName("rtd")]
    public long Timestamp { get; init; }
}
