using Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParaskeuhCopy.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly ILogger<ContactController> _logger;
        private readonly IContactService contactService;

        public ContactController(ILogger<ContactController> logger, IContactService contactService)
        {
            _logger = logger;
            this.contactService = contactService;
        }

        //GET: api/<ContactController>
        [HttpGet]
        public async Task<IEnumerable<Contact>> Get()
        {
            var contacts = await contactService.GetAll();
            return contacts;
        }

        //GET api/<ContactController>/5
        [HttpGet("{id:int}")]
        public async Task<Contact> Get(int id)
        {
            var contact = await contactService.Get(id);
            return contact;
        }
    }
}
