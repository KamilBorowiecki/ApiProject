using ApiProject.Data;
using ApiProject.Interfaces;
using ApiProject.Models;

namespace ApiProject.Repository
{
    public class BookRepository : IBookInterface
    {
        private readonly DataContext _context;
        public BookRepository(DataContext dataContext) 
        {
            this._context = dataContext;
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(b=>b.Id).ToList();
        }
    }
}
