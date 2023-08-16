using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pschool.API.Data;
using Pschool.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pschool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly PschoolDbContext _context;

        public ParentController(PschoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Parent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parent>>> GetParents()
        {
            var parents = await _context.Parents.Include(i => i.Students).ToListAsync();
            //I used  this DTO to serialize Cycles 
            var parentsDTO = parents.Select(parent => new Parent
                        {
                            Id = parent.Id,
                            FirstName = parent.FirstName,
                            LastName = parent.LastName,
                            UserName = parent.UserName,
                            Email = parent.Email,
                            HomeAddress = parent.HomeAddress,
                            Phone1 = parent.Phone1,
                            WorkPhone = parent.WorkPhone,
                            HomePhone = parent.HomePhone,
                            BirthDate = parent.BirthDate,
                            Students = parent.Students.Select(student => new Student
                            {
                                Id=student.Id,
                                FirstName = student.FirstName,
                                LastName = student.LastName,
                            }).ToList()
                        }).ToList();
            return parentsDTO;
        }

        // GET: api/Parent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parent>> GetParent(int id)
        {
            var parent = await _context.Parents.FindAsync(id);

            if (parent == null)
            {
                return NotFound();
            }

            return parent;
        }

        // POST: api/Parent
        [HttpPost]
        public async Task<ActionResult<Parent>> PostParent(Parent parent)
        {
            _context.Parents.Add(parent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParent), new { id = parent.Id }, parent);
        }

        // PUT: api/Parent/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParent(int id, Parent parent)
        {
            if (id != parent.Id)
            {
                return BadRequest();
            }

            _context.Entry(parent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentExists(id))
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

        // DELETE: api/Parent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var parent = await _context.Parents.FindAsync(id);
            if (parent == null)
            {
                return NotFound();
            }

            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParentExists(int id)
        {
            return _context.Parents.Any(e => e.Id == id);
        }
    }
}
