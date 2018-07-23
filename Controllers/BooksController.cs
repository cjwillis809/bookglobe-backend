using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bookglobe_backend.Controllers.Dtos;
using bookglobe_backend.Models;
using bookglobe_backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookglobe_backend.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        private readonly GlobeDbContext context;
        private readonly IMapper mapper;

        public BooksController(GlobeDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetBooks()
        {
            var books = await context.Books.ToListAsync();
            return Ok(mapper.Map<List<Book>, List<BookDto>>(books));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await context.Books.SingleOrDefaultAsync(b => b.Id == id);

            if (book == null) {
                return NotFound();
            }

            var bookDto = mapper.Map<Book, BookDto>(book); 
            return Ok(book);
        }
    }
}