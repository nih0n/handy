using System.Text.Json.Serialization;

namespace Handy.Models;

public record struct Velocity
{
    [JsonPropertyName("velocity")]
    public ushort Value { get; init; }

    public Velocity(ushort value)
    {
        if (value > 100)
            throw new ArgumentOutOfRangeException(nameof(value), "velocity must be between 0 and 100.");

        Value = value;
    }

    public override string ToString() => Value.ToString();
}
