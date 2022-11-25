using System.Text.Json.Serialization;
using Handy.Enums;

namespace Handy.Responses;

internal class ModeResponse
{
    [JsonPropertyName("mode")]
    public Mode Mode { get; init; }
}
