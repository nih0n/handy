namespace Handy.Enums;

public enum HsspState
{
    /// <summary>
    /// The device need to synchronize with the server.
    /// </summary>
    NeedSync = 1,

    /// <summary>
    /// No script have yet been setup on the device.
    /// </summary>
    NeedSetup,

    /// <summary>
    /// The script execution is stopped.
    /// </summary>
    Stopped,

    /// <summary>
    /// The device is executing the script.
    /// </summary>
    Playing
}
