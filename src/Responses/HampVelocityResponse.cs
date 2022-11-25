using System.Text.Json.Serialization;

namespace Handy.Responses;

internal class HampVelocityResponse
{
    [JsonPropertyName("velocity")]
    public ushort Velocity { get; init; }
}
