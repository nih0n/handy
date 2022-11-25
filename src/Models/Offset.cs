using System.Text.Json.Serialization;

namespace Handy.Models;

public record struct Offset
{
    [JsonPropertyName("offset")]
    public short Value { get; init; }

    [JsonConstructor]
    public Offset(short value)
    {
        if (value < -100 || value > 100)
            throw new ArgumentOutOfRangeException(nameof(value), "offset must be between 0 and 100.");

        Value = value;
    }

    public override string ToString() => Value.ToString();
}
