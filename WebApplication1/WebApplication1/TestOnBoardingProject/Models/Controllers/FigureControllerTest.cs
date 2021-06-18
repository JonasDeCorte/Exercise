using Microsoft.AspNetCore.Mvc.Testing;
using WebApplication1;
using Xunit;

namespace TestOnBoardingProject.Models.Controllers
{
    public class FigureControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public FigureControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
    }
}