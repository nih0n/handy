using System.Text.Json.Serialization;

namespace Handy.Models;

internal class GenericError
{
    [JsonPropertyName("connected")]
    public bool Connected { get; init; }

#nullable enable
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }
#nullable disable

    [JsonPropertyName("code")]
    public ushort Code { get; init; }

    [JsonPropertyName("data")]
#nullable enable
    public object? Data { get; init; }
}
