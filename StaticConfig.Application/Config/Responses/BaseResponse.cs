using System.Text.Json.Serialization;

namespace StaticConfig.Application.Config.Responses;


public class BaseResponse
{
    [JsonIgnore]
    public bool HasError { get; set; }
    [JsonIgnore]
    public int StatusCode { get; set; } = 200;
    [JsonIgnore]
    public string Message { get; set; } = null!;
}