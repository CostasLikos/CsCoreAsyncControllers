using Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParaskeuhCopy.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {

        private readonly ILogger<HealthCheckController> _logger;
        private readonly IContactService contactService;

        public HealthCheckController(ILogger<HealthCheckController> logger, IContactService contactService)
        {
            _logger = logger;
            this.contactService = contactService;
        }

        //GET: api/<HealthCheckController>
        [HttpHead]
        public IActionResult Head()
        {
            return Ok();
        }
    }
}
