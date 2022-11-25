namespace Handy.Exceptions;

public class HandyException : Exception
{
    public ushort Code { get; init; }
    public string Name { get; init; }
    public bool Connected { get; init; }

    public HandyException(string message, ushort code, string name, bool connected)
        : base(message) => (Code, Name, Connected) = (code, name, connected);
}
