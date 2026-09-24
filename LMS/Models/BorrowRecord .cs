using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    public class BorrowRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }


        public int MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }


        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

    }
}
