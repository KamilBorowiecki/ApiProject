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
