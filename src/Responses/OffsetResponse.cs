using System.Text.Json.Serialization;
using Handy.Models;

namespace Handy.Responses;

internal class OffsetResponse
{
    [JsonPropertyName("offset")]
    public short Offset { get; init; }
}
