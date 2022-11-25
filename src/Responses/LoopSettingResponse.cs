using System.Text.Json.Serialization;

namespace Handy.Responses;

internal class LoopSettingResponse
{
    [JsonPropertyName("activated")]
    public bool Activated { get; init; }
}
