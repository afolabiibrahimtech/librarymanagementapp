using System.ComponentModel.DataAnnotations;

namespace librarymanagementapp.Models
{
    public class BorrowModel
    {
        public int Id { get; set; }

        [Display(Name = "Student")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a student.")]
        public int StudentId { get; set; }

        [Display(Name = "Book")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a book.")]
        public int BookId { get; set; }

        [Display(Name = "Borrow Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter the borrow date.")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        public StudentModel? Student { get; set; }

        public BookModel? Book { get; set; }
    }
}