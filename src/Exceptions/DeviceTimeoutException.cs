namespace Handy.Exceptions;

public class DeviceTimeoutException : HandyException
{
    public DeviceTimeoutException(bool connected)
        : base("No response from machine.", 1002, "DeviceTimeout", connected) { }
}
