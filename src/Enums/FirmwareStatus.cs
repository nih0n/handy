namespace Handy.Enums;

public enum FirmwareStatus
{
    /// <summary>
    /// The firmware is up-tp-date.
    /// </summary>
    UpToDate,

    /// <summary>
    /// A critical update is available.
    /// </summary>
    UpdateRequired,

    /// <summary>
    /// An non critical update to the firmware is available.
    /// </summary>
    UpdateAvailable
}
