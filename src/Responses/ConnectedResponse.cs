using System.Text.Json.Serialization;

namespace Handy.Responses;

internal class ConnectedResponse
{
    [JsonPropertyName("connected")]
    public bool Connected { get; init; }
}
