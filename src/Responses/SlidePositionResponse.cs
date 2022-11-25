using System.Text.Json.Serialization;

namespace Handy.Responses;

internal class SlidePositionResponse
{
    [JsonPropertyName("position")]
    public int Position { get; init; }
}
