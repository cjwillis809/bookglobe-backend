using bookglobe_backend.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace bookglobe_backend.Controllers
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        private readonly GlobeDbContext context;

        public BooksController(GlobeDbContext context)
        {
            this.context = context;
        }

        [HttpGet()]
        public IActionResult GetBooks() 
        {
            return new JsonResult(context.Books);
        }
    }
}