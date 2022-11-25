using System.Text.Json.Serialization;
using Handy.Enums;

namespace Handy.Models;

public class Information
{
    [JsonPropertyName("fwVersion")]
    public string FirmwareVersion { get; init; }

    [JsonPropertyName("fwStatus")]
    public FirmwareStatus FirmwareStatus { get; init; }

    [JsonPropertyName("hwVersion")]
    public int HardwareVersion { get; init; }

    [JsonPropertyName("model")]
    public string Model { get; init; }

    [JsonPropertyName("branch")]
    public string Branch { get; init; }

    [JsonPropertyName("sessionId")]
    public string SessionId { get; init; }
}
