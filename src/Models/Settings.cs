using System.Text.Json.Serialization;

namespace Handy.Models;

public class Settings
{
    [JsonPropertyName("offset")]
    public int Offset { get; init; }

    [JsonPropertyName("velocity")]
    public int Velocity { get; init; }

    [JsonPropertyName("slideMin")]
    public int SlideMin { get; init; }

    [JsonPropertyName("slideMax")]
    public int SlideMax { get; init; }
}
