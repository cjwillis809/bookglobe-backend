using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bookglobe_backend.Controllers.Dtos;
using bookglobe_backend.Core;
using bookglobe_backend.Models;
using bookglobe_backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookglobe_backend.Controllers
{
    [Route("api/books")]
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
        public async Task<IActionResult> GetBooks()
        {
            var books = await repository.GetBooks();
            return Ok(mapper.Map<List<Book>, List<BookDto>>(books));
        }

        [HttpGet("{id}")]
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
            //TODO: Add Unauthorized validation
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = mapper.Map<BookDto, Book>(newBook);
            repository.Add(book);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Book, BookDto>(book);
            return Ok(result);
        }
    }
}