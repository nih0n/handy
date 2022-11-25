using System.Text.Json.Serialization;

namespace Handy.Models;

public abstract class NextPosition
{
    [JsonPropertyName("position")]
    public double Position { get; init; }

    [JsonPropertyName("stopOnTarget")]
    public bool StopOnTarget { get; init; }

    [JsonPropertyName("immediateResponse")]
    public bool ImmediateResponse { get; init; }

    public NextPosition(double position, bool stopOnTarget, bool immediateResponse)
    {
        if (position < 0)
            throw new ArgumentOutOfRangeException(nameof(position), "position cannot be less than zero.");

        Position = position;
        StopOnTarget = stopOnTarget;
        ImmediateResponse = immediateResponse;
    }
}
