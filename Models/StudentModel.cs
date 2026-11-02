using System.ComponentModel.DataAnnotations;

namespace librarymanagementapp.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [Phone]
        public string Phone { get; set; } = "";
    }
}