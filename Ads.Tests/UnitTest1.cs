namespace Ads.Tests;

public class UnitTest1
{
    [Fact]
    public void getAdsByLocation_ShouldReturnListOfMatchedSources()
    {
        var repository = new AdRepository();
        var testData = new Dictionary<string, List<string>>
        {
            { "Source1", new List<string> { "/loc1", "/loc2" } },
            { "Source2", new List<string> { "/loc2", "/loc3" } }
        };
        repository.InitializeData(testData);

        var result = repository.getAdsByLocation("/loc2");

        Assert.Equal(2, result.Count);
        Assert.Contains("Source1", result);
        Assert.Contains("Source2", result);
    }
}