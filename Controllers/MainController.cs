using Microsoft.AspNetCore.Mvc;

namespace Kovan.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
     
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTestData")]
        public string Get()
        {
            return "TES DATA..";
        }
    }
}