using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        [Required, StringLength(100)]
        public string Author { get; set; }

        [Range(1900,2026)]
        public int PublishedYear { get; set; }

        [Required , Range(1,int.MaxValue)]
        public decimal Price { get; set; }

        [Range(0,int.MaxValue)]
        public int AvailableCopies { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }


        public ICollection<BorrowRecord> BorrowRecords { get; set; }

    }
}
