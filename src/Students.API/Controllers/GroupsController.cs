using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Students.API.Services;

namespace Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string name, int? skipCount, int? takeCount, bool isOrderByDescending)
        {
            return Ok(await _groupService.GetGroupsByFilterAsync(name, skipCount, takeCount, isOrderByDescending));
        }

        // GET: api/Groups/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Groups
        //[HttpPost]
        //public void Post([FromBody] Group group)
        //{
        //    _context.Groups.Add(group);
        //    _context.SaveChanges();
        //}

        // PUT: api/Groups/5
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
