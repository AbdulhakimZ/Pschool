using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pschool.Web.Models
{
    public class Parent
    {
        public Parent()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 30 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 30 characters.")]
        public string LastName { get; set; }

        [Display(Name = "Username")]
        [MaxLength(50, ErrorMessage = "Username cannot exceed 30 characters.")]
        public string? UserName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [MaxLength(100, ErrorMessage = "Email address cannot exceed 30 characters.")]
        public string? Email { get; set; }

        [MaxLength(200, ErrorMessage = "Home address cannot exceed 200 characters.")]
        public string? HomeAddress { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        [Display(Name = "Primary Phone")]
        public string? Phone1 { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        [Display(Name = "Work Phone")]
        public string? WorkPhone { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        [Display(Name = "Home Phone")]
        public string? HomePhone { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
