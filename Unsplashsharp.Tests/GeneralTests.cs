using Unsplasharp;
using Unsplashsharp.Tests.Data;

namespace Unsplashsharp.Tests;

[TestClass]
public class GeneralTests {
    [TestMethod]
    public async Task RateLimitTest() {
        var client = new UnsplasharpClient(Credentials.ApplicationId);
        var photosFound = await client.GetRandomPhoto();

        Assert.IsTrue(client.RateLimitRemaining < client.MaxRateLimit);
    }

    [TestMethod]
    public async Task GetTotalStatsTest() {
        var client = new UnsplasharpClient(Credentials.ApplicationId);
        var totalStats = await client.GetTotalStats();

        Assert.IsNotNull(totalStats);
        Assert.IsTrue(totalStats.Photos > 0);
    }

    [TestMethod]
    public async Task GetMonthlyStatsTest() {
        var client = new UnsplasharpClient(Credentials.ApplicationId);
        var monthlyStats = await client.GetMonthlyStats();

        Assert.IsNotNull(monthlyStats);
        Assert.IsTrue(monthlyStats.Views > 0);
    }
}