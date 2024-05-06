using ApiProject.Data;
using ApiProject.Interfaces;
using ApiProject.Models;
using System.Diagnostics.Metrics;
using System.Linq;

namespace ApiProject.Repository
{
    public class BookRepository : IBookInterface
    {
        private readonly DataContext _context;
        public BookRepository(DataContext dataContext)
        {
            this._context = dataContext;
        }

        public Book GetBook(int id)
        {
            return _context.Books.Where(b => b.Id == id).FirstOrDefault();
        }

        public Book GetBookByTitle(string title)
        {
            return _context.Books.Where(b => b.Title == title).FirstOrDefault();
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(b => b.Id).ToList();
        }

        public bool HasBook(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId);
        }
        public bool CreateBook(Book book)
        {
            _context.Add(book);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBook(Book book)
        {
            _context.Update(book);
            return Save();
        }

        public bool DeleteBook(Book book)
        {
            _context.Remove(book);
            return Save();
        }
    }
}
