using NUnit.Framework;
using Execution.Suite.Attributes;

namespace Excecution.Test;

[Area("Threats")]
public class ThreatsSuite
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CheckThreats()
    {
        Assert.Pass();
    }
}