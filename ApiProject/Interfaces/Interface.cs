using ApiProject.Models;

namespace ApiProject.Interfaces
{
    public interface IBookInterface
    {
        ICollection<Book> GetBooks();

    }
}
