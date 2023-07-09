using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnockoutPrastice.Data;
using KnockoutPrastice.Models;
using KnockoutPrastice.Utility;

namespace KnockoutPrastice.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentModelsController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentModelsController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/StudentModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudentModels(int skip=0, int take=0, string search="")
        {
          if (_context.StudentModels == null)
          {
              return NotFound();
          }
            var studentData =  _context.StudentModels.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                studentData = studentData.Where(x =>
              x.Address.Contains(search) ||
              x.Name.Contains(search)
           );
            }
            var data = studentData
                .Skip(skip)
                .Take(take)
                .ToList();
            if (data == null)
            {
                return null;
            }
            return data;
        }

        // GET: api/StudentModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudentModel(int id)
        {
          if (_context.StudentModels == null)
          {
              return NotFound();
          }
            var studentModel = await _context.StudentModels.FindAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return studentModel;
        }

        // PUT: api/StudentModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentModel(int id, StudentModel studentModel)
        {
            if (id != studentModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(id))
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

        // POST: api/StudentModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudentModel(StudentModel studentModel)
        {
          if (_context.StudentModels == null)
          {
              return Problem("Entity set 'StudentContext.StudentModels'  is null.");
          }
            _context.StudentModels.Add(studentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentModel", new { id = studentModel.Id }, studentModel);
        }

        // DELETE: api/StudentModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentModel(int id)
        {
            if (_context.StudentModels == null)
            {
                return NotFound();
            }
            var studentModel = await _context.StudentModels.FindAsync(id);
            if (studentModel == null)
            {
                return NotFound();
            }

            _context.StudentModels.Remove(studentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentModelExists(int id)
        {
            return (_context.StudentModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
