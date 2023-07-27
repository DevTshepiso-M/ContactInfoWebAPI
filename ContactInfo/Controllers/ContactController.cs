using ContactInfo.Model;
using ContactInfo.Services;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactInfo.Controllers
{
	[Route("api/Contact")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
			_contactService = contactService;
        }
    

		// GET: api/Contact
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var contacts = await _contactService.GetAllAsync();
			return Ok(contacts);
		}

		// GET api/<ValuesController>/5
		[HttpGet("{id}")]
		
		public async Task<IActionResult> GetByIdAsync(string id)
		{

			var contacts = await _contactService.GetByIdAsync(string id)
			return Ok(contacts);
		}
			
		

		// POST api/<ValuesController>
		[HttpPost]
		public async Task<IActionResult> Post(Contact contact)
		{
			await _contactService.CreateAsync(contact);
			return Ok();
		}

		// PUT api/<ValuesController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ValuesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
