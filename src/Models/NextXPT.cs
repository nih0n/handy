using System.Text.Json.Serialization;

namespace Handy.Models;

public class NextXPT : NextPosition
{
    [JsonPropertyName("duration")]
    public uint Duration { get; init; }

    /// <param name="position">Absolute position in percent.</param>
    /// <param name="duration">Duration in milliseconds (ms).</param>
    /// <param name="stopOnTarget">Flag to indicate whether or not the movement of the slide should stop when the specified target position have been reached. Setting this value to `false` should in most cases give a smoother movement when sending a stream HDSP commands continuously to the device.</param>
    /// <param name="immediateResponse">Flag to indicate if the server should return a response immediately upon receinving the command from the client or wait for a response from the device before returning a response to the client.</param>
    public NextXPT(PercentValue position, uint duration, bool stopOnTarget, bool immediateResponse)
        : base(position.Value, stopOnTarget, immediateResponse)
        => Duration = duration;
}
