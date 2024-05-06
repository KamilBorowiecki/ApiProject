using ApiProject.Models;

namespace ApiProject.Interfaces
{
    public interface IBookInterface
    {
        ICollection<Book> GetBooks();
        Book GetBook(int id);
        Book GetBookByTitle(string title);
        bool HasBook(int bookId);
        bool CreateBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(Book book);
        bool Save();
    }
}
