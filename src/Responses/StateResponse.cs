using System.Text.Json.Serialization;

internal class StateResponse<T> where T : Enum
{
    [JsonPropertyName("state")]
    public T State { get; init; }
}
