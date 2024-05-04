using ApiProject.Data;
using ApiProject.Interfaces;
using ApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookInterface bookInterface;
        private readonly DataContext context;

        public BookController(IBookInterface iFaces, DataContext context)
        {
            this.bookInterface = iFaces;
            this.context = context;
        }

        public IBookInterface BookInterface => bookInterface;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult getBooks()
        {
            var books = BookInterface.GetBooks();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);
        }

    }
}
