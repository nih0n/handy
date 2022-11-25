using System.Text.Json.Serialization;
using Handy.Models;

namespace Handy.Responses;

internal class ErrorResponse
{
    [JsonPropertyName("error")]
    public GenericError Error { get; init; }
}
