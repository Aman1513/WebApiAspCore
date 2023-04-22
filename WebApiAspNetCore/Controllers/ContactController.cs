using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAspNetCore.Models;

namespace WebApiAspNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactDbContext _context;

        public ContactController(ContactDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContact([FromRoute] int id)
        {
            var cObj = await _context.Contacts.FindAsync(id);
            if (cObj != null)
            {
                return Ok(cObj);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(Contact contact)
        {
           await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateContact([FromRoute] int id, Contact contact)
        {
            var cObj = await _context.Contacts.FindAsync(id);
            if (cObj != null)
            {
                cObj.Id = contact.Id;
                cObj.Name = contact.Name;
                cObj.Email = contact.Email;
                cObj.PhoneNumber = contact.PhoneNumber;
                await _context.SaveChangesAsync();
                return Ok(cObj);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            var cObj = await _context.Contacts.FindAsync(id);
            if (cObj != null)
            {
                _context.Remove(cObj);
                await _context.SaveChangesAsync();
                return Ok(cObj);
            }
            return NotFound();
        }
    }
}
