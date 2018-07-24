using bookglobe_backend.Core;
using System.Threading.Tasks;
using bookglobe_backend.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bookglobe_backend.Persistence
{
    public class BookRepository : IBookRepository
    {
        private readonly GlobeDbContext context;
        public BookRepository(GlobeDbContext context)
        {
            this.context = context;
        }

        public async Task<Book> GetBook(int id)
        {
            return await context.Books.SingleOrDefaultAsync(b => b.Id == id);
        }
        
        public async Task<List<Book>> GetBooks()
        {
            return await context.Books.ToListAsync();
        }

        public void Add(Book book)
        {
            context.Books.Add(book);
        }
        
        public void Remove(Book book)
        {
            context.Books.Remove(book);
        }
    }
}