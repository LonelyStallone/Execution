namespace Execution.Suite.Attributes;

public class SuiteAttribute : Attribute
{
    public string Suite { get; }
    public SuiteAttribute() { }
    public SuiteAttribute(string suite) => Suite = suite;
}
