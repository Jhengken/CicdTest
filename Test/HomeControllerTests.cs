using System.Net;
using CicdTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Test;

public class HomeControllerTests
{
    [Fact]
    public void Counter_Returns_ViewResult()
    {
        var controller = new HomeController();

        var result = controller.Counter();

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Null(viewResult.ViewName);
    }
}

public class CounterPageTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CounterPageTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Counter_Page_Is_Accessible_And_Renders_Content()
    {
        var response = await _client.GetAsync("/Home/Counter");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Counter", content);
        Assert.Contains("counter-value", content);
    }
}