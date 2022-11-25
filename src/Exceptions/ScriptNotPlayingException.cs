namespace Handy.Exceptions;

public class ScriptNotPlayingException : HandyException
{
    public ScriptNotPlayingException(bool connected)
        : base("The play command failed.", 4004, "PLAY_FAILED", connected) { }
}
