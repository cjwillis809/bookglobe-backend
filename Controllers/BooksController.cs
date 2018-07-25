using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bookglobe_backend.Controllers.Dtos;
using bookglobe_backend.Core;
using bookglobe_backend.Models;
using bookglobe_backend.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookglobe_backend.Controllers
{
    [Route("api/books")]
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBookRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public BooksController(IMapper mapper, IBookRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<IActionResult> GetBooks()
        {
            var books = await repository.GetBooks();
            return Ok(mapper.Map<List<Book>, List<BookDto>>(books));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await repository.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = mapper.Map<Book, BookDto>(book);
            return Ok(book);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateBook([FromBody] BookDto newBook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = mapper.Map<BookDto, Book>(newBook);
            repository.Add(book);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Book, BookDto>(book);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditBook(int id, [FromBody] BookDto modifiedBook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var book = await repository.GetBook(id);

            if (book == null)
                return NotFound();

            mapper.Map<BookDto, Book>(modifiedBook, book);

            await unitOfWork.CompleteAsync();

            book = await repository.GetBook(book.Id);
            var result = mapper.Map<Book, BookDto>(book);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await repository.GetBook(id);

            if (book == null)
                return NotFound();

            repository.Remove(book);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}