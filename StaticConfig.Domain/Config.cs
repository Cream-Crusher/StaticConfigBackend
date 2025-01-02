namespace StaticConfig.Domain;

public class Config : BaseEntity
{
    public string Key { get; set; }
    public string Value { get; set; }
}