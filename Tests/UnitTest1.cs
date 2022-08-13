using MvcMovie.Utilities;

namespace Tests;

public class TestUtilities
{
    [Fact]
    public void TestCompatibility()
    {
        var compat = new CompatibilityAnalyzer();

        var result = compat.GetCompatibility("Joel", "Joel");

        Assert.Equal(100, result);
    }
}