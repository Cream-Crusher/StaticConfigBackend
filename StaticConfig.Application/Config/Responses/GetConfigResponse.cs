namespace StaticConfig.Application.Config.Responses;

public class GetConfigResponse : ErrorResponse
{
    public string Key { get; set; }
    public string Value { get; set; }
}