using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string FullName { get; set; }

        [Required , EmailAddress]
        public string Email { get; set; }

        [Phone , MaxLength(20) ]
        public string ? PhoneNumber { get; set; }


        public ICollection<BorrowRecord> BorrowRecords { get; set; }    


    }
}
