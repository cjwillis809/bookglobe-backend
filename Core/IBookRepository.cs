using System.Collections.Generic;
using System.Threading.Tasks;
using bookglobe_backend.Models;

namespace bookglobe_backend.Core
{
    public interface IBookRepository
    {
        Task<Book> GetBook(int id);
        void Add(Book book);
        void Remove(Book book);
        Task<List<Book>> GetBooks();
    }
}