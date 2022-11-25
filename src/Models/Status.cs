using System.Text.Json.Serialization;
using Handy.Enums;

namespace Handy.Models;

public record struct Status
{
    [JsonConstructor]
    public Status(Mode mode, HsspState state)
        => (Mode, State) = (mode, state);

    public Mode Mode { get; init; }
    public HsspState State { get; init; }
}
