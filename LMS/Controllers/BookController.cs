using LMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly AppDbContext _context;

        public BookController()
        {
            _context = new AppDbContext();
        }


        [HttpGet("All Books Greater Than a Book Price ")]

        public IActionResult GetAllBooks1 (int Price )
        {
            var a = _context.Books.Where(b => b.Price > Price).ToList();
            return Ok (a);
        }
        
        [HttpGet("All Books Between A Range")]

        public IActionResult GetAllBooks2 (int min , int max)
        {
            var a = _context.Books.Where(b => b.Price >min && b.Price < max).ToList();
            return Ok (a);
        }

        [HttpGet("All Books By Category Name")]

        public IActionResult GetAllBooks3(string Word )
        {
            var a = _context.Books.Where(a=>a.Title.Contains(Word)).ToList();
            return Ok(a);
        }


        [HttpGet("First")]

        public IActionResult GetAllBooks4()
        {
            var a = _context.Books.First();
            return Ok(a);
        }


        [HttpGet("First Avalible")]

        public IActionResult GetAllBooks5()
        {
            var a = _context.Books.FirstOrDefault(a => a.AvailableCopies>0);
            return Ok(a);
        }


        [HttpGet("Get By Id ")]

        public IActionResult GetAllBooks6(int id )
        {
            var a = _context.Books.Where(a=>a.Id==id);
            return Ok(a);
        }

        [HttpGet("Last ")]

        public IActionResult GetAllBooks7()
        {
            var a = _context.Books.Last();
            return Ok(a);
        }


        [HttpGet("Exist")]

        public IActionResult GetAllBooks8(int id)
        {
            var a = _context.Books.Where(a => a.Id == id).Select(a => new { a.Title, a.Author, a.PublishedYear, a.Price, a.AvailableCopies, a.CategoryId });
            return Ok(a);


        }

        [HttpGet("All ")]

        public IActionResult GetAllBooks9()
        {
            var a = _context.Books.All(a=>a.AvailableCopies > 0);
            return Ok(a);
        }

        [HttpGet("All Titles")]

        public IActionResult GetAllBooks10()
        {
            var a = _context.Books.Select(a=> new {a.Title});
            return Ok(a);
        }

        [HttpGet("Asencding Sort")]

        public IActionResult GetAllBooks11(int id)
        {
            var a = _context.Books.OrderBy(a => a.Title).ToList();
            return Ok(a);
        }
        
        [HttpGet("Lowest")]

        public IActionResult GetAllBooks12()
        {
            var a = _context.Books.Min(a => a.Price);
            return Ok(a);
        }
        
        [HttpGet("Pagination")]

        public IActionResult GetAllBooks13(int PageNumber = 1 , int PageSize = 5)
        {
            var a = _context.Books.Skip(PageNumber - 1 * PageSize).Take(PageSize);
            return Ok(a);
        }

























    }
}
