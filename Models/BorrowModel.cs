using System.ComponentModel.DataAnnotations;

namespace librarymanagementapp.Models
{
    public class BorrowModel
    {
        public int Id { get; set; }

        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [Display(Name = "Book")]
        public int BookId { get; set; }

        [Display(Name = "Borrow Date")]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        public StudentModel? Student { get; set; }

        public BookModel? Book { get; set; }
    }
}