using ApiProject.Data;
using ApiProject.Interfaces;
using ApiProject.Models;
using ApiProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerInterfaces ownerInterface;
        private readonly DataContext context;

        public OwnerController(IOwnerInterfaces iFaces, DataContext context)
        {
            this.ownerInterface = iFaces;
            this.context = context;
        }

        public IOwnerInterfaces OwnerInterface => ownerInterface;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult getBooks()
        {
            var owners = OwnerInterface.GetOwners();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owners);
        }

        [HttpGet("OwnerId/books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<string>))]
        [ProducesResponseType(400)]
        public IActionResult getBooksByOwner(int id)
        {
            if (!ownerInterface.HasOwner(id))
            {
                return NotFound();
            }

            var books = new List<string>(
                ownerInterface.getBooksByOwner(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }
    }
}
