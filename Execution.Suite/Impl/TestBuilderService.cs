using Execution.Detection;
using Execution.Suite.Attributes;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Execution.Suite.Impl;

public class TestBuilderService : ITestBuilderService
{
    private int _maxDeep { get; }

    public TestBuilderService(int mexDeep)
    {
        _maxDeep = mexDeep;
    }

    public ITestData GetTestInfoFromStack()
    {
        var testMethod = DetectTestMethod();
        var testType = testMethod?.DeclaringType;
        if (testType == null)
            throw new Exception("Invalid test type");

        if (!AttributeHelper.TryGetMethodAttributeValue<TfsIdAttribute, int>(testMethod, (item) => item.Id, out int id))
        {
            throw new Exception($"Test method dont contains {nameof(TfsIdAttribute)}  Attribute");
        }

        if (!AttributeHelper.TryGetTypeAttributeValue<AreaAttribute, string>(testType, (item) => item.Area, out string area))
        {
            throw new Exception($"Test class dont contains {nameof(AreaAttribute)}  Attribute");
        }

        if (!AttributeHelper.TryGetTypeAttributeValue<SuiteAttribute, string>(testType, (item) => item.Area, out string suite))
        {
            throw new Exception($"Test class dont contains {nameof(SuiteAttribute)}  Attribute");
        }

        return new TestData(suite, area, id, testMethod.Name);
    }

    MethodBase DetectTestMethod()
    {
        StackTrace stackTrace = new StackTrace();
        StackFrame[] stackFrames = stackTrace.GetFrames();
        int counter = 0;

        foreach (StackFrame stackFrame in stackFrames)
        {
            counter++;
            if (counter >= _maxDeep)
                throw new Exception("The maximum depth has been reached, the stack does not contain test method");

            var method = stackFrame.GetMethod();

            if (method == null)
                continue;

            if (AttributeHelper.IsMethodContainsAttribute<TestAttribute>(method))
            {
                return method;
            }
        }

        throw new Exception("Stack does not contain test method");
    }
}
