namespace Execution.Detection;

public interface ITestData
{
    string Suite { get; }

    string Area { get; }

    int TfsId { get; }

    string Name { get; }
}
