using System.Text.Json;
using Handy.Exceptions;
using Handy.Responses;

namespace Handy;

internal static class ResponseHandler
{
    public static void EnsureSuccess(string json)
    {
        var jsonDocument = JsonDocument.Parse(json);

        if (jsonDocument.RootElement.TryGetProperty("error", out _))
        {
            var error = jsonDocument.Deserialize<ErrorResponse>().Error;

            throw error.Code switch
            {
                1001 => new DeviceNotConnectedException(),
                1002 => new DeviceTimeoutException(error.Connected),
                4004 => new ScriptNotPlayingException(error.Connected),
                _ => new HandyException(error.Message, error.Code, error.Name, error.Connected)
            };
        }
    }
}
