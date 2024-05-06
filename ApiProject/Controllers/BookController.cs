using ApiProject.Data;
using ApiProject.Interfaces;
using ApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book bookCreate)
        {
            if (bookCreate == null)
                return BadRequest(ModelState);

            var book = bookInterface.GetBooks()
                .Where(c => c.Title.Trim().ToUpper() == bookCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (book != null)
            {
                ModelState.AddModelError("", "Book already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!bookInterface.CreateBook(bookCreate))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{bookId}")]
        public IActionResult UpdateBook(int bookId, [FromBody] Book bookUpadate)
        {
            if (bookUpadate == null)
                return BadRequest(ModelState);

            if (bookId != bookUpadate.Id)
                return BadRequest(ModelState);

            if (!bookInterface.HasBook(bookId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            if(!bookInterface.UpdateBook(bookUpadate))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}

