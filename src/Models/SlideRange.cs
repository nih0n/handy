using System.Text.Json.Serialization;

namespace Handy.Models;

public record struct SlideRange
{
    [JsonPropertyName("min")]
    public ushort? Min { get; init; }

    [JsonPropertyName("max")]
    public ushort? Max { get; init; }

    [JsonPropertyName("fixed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Fixed { get; init; }

    [JsonConstructor]
    public SlideRange(ushort? min, ushort? max, bool @fixed = false)
    {
        if (max > 100)
            throw new ArgumentOutOfRangeException(nameof(max), "slide must be between 0 and 100.");

        Min = min;
        Max = max;
        Fixed = @fixed;
    }
}
