using Execution.Detection;

namespace Execution.Suite;

internal interface ITestBuilderService
{
    ITestData GetTestInfoFromStack();
}
