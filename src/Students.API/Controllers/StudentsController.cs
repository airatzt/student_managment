namespace Students.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Students.API.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        [HttpGet("{id}")]

        public ActionResult<Student> StudentById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            return new Student
            {
                Id = 1,
                Sex = 1,
                Surname = "Paul",
                Name = "Phil",
                Patronymic = "Alex",
                Slug = "sniper"
            };
        }
    }
}