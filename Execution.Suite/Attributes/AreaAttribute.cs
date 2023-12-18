namespace Execution.Suite.Attributes;

public class AreaAttribute : Attribute
{
    public string Area { get; }
    public AreaAttribute() { }
    public AreaAttribute(string area) => Area = area;
}
