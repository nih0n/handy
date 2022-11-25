namespace Handy.Exceptions;

public class DeviceNotConnectedException : HandyException
{
    public DeviceNotConnectedException()
        : base("Device not connected.", 1001, "DeviceNotConnected", false) { }
}
