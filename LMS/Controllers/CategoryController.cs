using LMS.Dtos;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly AppDbContext _context;
        public CategoryController()
        {
            _context = new AppDbContext();
        }

        [HttpGet(" Group By ")]

        public IActionResult GetAllBooks14(int id)
        {
            var a = _context.Books.GroupBy(a => a.CategoryId)
                .Select(a => new { CategoryId = a.Key, Count = a.Count() }).ToList();
            return Ok(a);
        }



        [HttpPost]
        public IActionResult CreateCategory(CategoryCreateDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);

        }

        
    }
}