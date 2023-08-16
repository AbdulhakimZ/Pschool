using System;
using System.ComponentModel.DataAnnotations;

namespace Pschool.Web.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 30 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 30 characters.")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(100, ErrorMessage = "Email address cannot exceed 30 characters.")]
        public string? Email { get; set; }

        [MaxLength(50, ErrorMessage = "Username cannot exceed 10 characters.")]
        public string? UserName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? Phone { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Parent is required.")]
        public int? ParentId { get; set; }

        public virtual Parent? Parent { get; set; }
    }
}
