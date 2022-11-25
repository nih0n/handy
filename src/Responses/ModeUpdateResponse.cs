using System.Text.Json.Serialization;

namespace Handy.Responses;

internal class ModeUpdateResponse
{
    [JsonPropertyName("result")]
    public int Result { get; init; }
}
