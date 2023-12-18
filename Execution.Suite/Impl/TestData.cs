using Execution.Detection;

namespace Execution.Suite.Impl;

internal class TestData : ITestData
{
    public TestData(string suite, string area, int tfsIs, string name)
    {
        Suite = suite;
        Area = area;
        TfsId = tfsIs;
        Name = name;
    }

    public string Suite { get; }

    public string Area { get; }

    public int TfsId { get; }

    public string Name { get; }
}
