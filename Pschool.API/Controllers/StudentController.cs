using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pschool.API.Data;
using Pschool.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pschool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly PschoolDbContext _context;

        public StudentController(PschoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _context.Students.Include(i => i.Parent).ToListAsync();
            //I used  this DTO to serialize Cycles 
            var studentsDTO = students.Select(student => new Student
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                UserName = student.UserName,
                Email = student.Email,
                Phone = student.Phone,
                BirthDate = student.BirthDate,
                ParentId = student.ParentId,
                Parent = new Parent() { Id=student.Parent.Id, FirstName = student.Parent?.FirstName, LastName = student.Parent?.LastName },
            }).ToList();
            return studentsDTO;
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
