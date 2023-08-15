using System.ComponentModel.DataAnnotations;

namespace Pschool.API.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? HomeAddress { get; set; }
        public string? Phone1 { get; set; }
        public string? WorkPhone { get; set; }
        public string? HomePhone { get; set; }
        public DateTime? BirthDate { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
