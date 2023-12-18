namespace Execution.Detection;

public interface ITestSuite
{
    IEnumerable<ITest> GetTests(string path);
}
