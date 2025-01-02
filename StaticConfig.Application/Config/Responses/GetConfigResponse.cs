namespace StaticConfig.Application.Config.Responses;

public abstract class GetConfigResponse
{
    public Guid Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}