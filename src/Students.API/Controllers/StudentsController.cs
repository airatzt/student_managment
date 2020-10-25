using DataAccess.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.API.Infrastructure;
using Students.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsContext _context;
        private readonly IEfRepository<Student> _repository;

        public StudentsController(StudentsContext context, IEfRepository<Student> repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            //return await _repository.ListAsNoTracking();
            return null;
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            var student = _context.Students.Include(x => x.StudentGroups).ThenInclude(x => x.Group).FirstOrDefault(x => x.Id == id);
            return student;
        }

        // POST: api/Student
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            //var groups = _context.Groups.ToList();
            //if (groups.Count() > 0)
            //{
            //    var studentGroups = groups.Select(x => new StudentGroup { Group = x });
            //    student.StudentGroups = studentGroups.ToList();
            //}
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
