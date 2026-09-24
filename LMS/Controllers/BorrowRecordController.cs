using LMS.Dtos;
using LMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRecordController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BorrowRecordController()
        {
            _context = new AppDbContext();
        }
        [HttpPost]
        public IActionResult Borrow(CreateBorrowRecordDTo dto )
        {
            var Mem = _context.Members.FirstOrDefault(a => a.Id == dto.MemberId);
            var Book = _context.Books.FirstOrDefault(a => a.Id == dto.BookId);
            if(Book.AvailableCopies < 0)
            {
                return BadRequest();
            }

            var BorrowRecord = new BorrowRecord
            {
                MemberId = dto.MemberId,
                BookId = dto.BookId,
                BorrowDate = DateTime.Now,
            };

            Book.AvailableCopies -= 1;
            _context.BorrowRecords.Add(BorrowRecord);
            _context.SaveChanges();

            return Ok(BorrowRecord.Id);

        }

        [HttpPut]
        public IActionResult Update(int id )
        {
            var borrowRecord = _context.BorrowRecords.FirstOrDefault(a => a.Id == id);

            if(borrowRecord == null)
            {
                return NotFound();
            }

            if(borrowRecord.ReturnDate != null)
            {
                return BadRequest("This book has already been returned.");
            }

            var book = _context.Books.FirstOrDefault(a => a.Id == borrowRecord.BookId);
             
            borrowRecord.ReturnDate = DateTime.Now;

            book.AvailableCopies += 1;
            _context.SaveChanges();
            return Ok();
        }    
        [HttpDelete]
        public IActionResult Delete(int id )
        {
            var borrowRecord = _context.BorrowRecords.FirstOrDefault(a => a.Id == id);

            if(borrowRecord == null)
            {
                return NotFound();
            }

            if(borrowRecord.ReturnDate != null)
            {
                return BadRequest("This book has already been returned.");
            }

            var book = _context.Books.FirstOrDefault(a => a.Id == borrowRecord.BookId);

            _context.BorrowRecords.Remove(borrowRecord);

            
            _context.SaveChanges();
            return NoContent();
        }
    }
}
