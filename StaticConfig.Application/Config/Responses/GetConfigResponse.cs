namespace StaticConfig.Application.Config.Responses;

public class GetConfigResponse : BaseResponse
{
    public string Key { get; set; }
    public string Value { get; set; }
}