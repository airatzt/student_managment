using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.API.Services;
using Students.API.ViewModels;

namespace Students.API.Controllers
{
    [Produces("application/json")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var group = await _groupService.GetGroupByIdAsync(id);
            if (group != null)
            {
                return Ok(group);
            }

            return NotFound();
        }

        //POST: api/Groups
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateGroupViewModel group)
        {
            if (ModelState.IsValid)
            {
                return Created(nameof(GetByIdAsync), await _groupService.CreateGroupAsync(group));
            }
            return BadRequest(ModelState);
        }



        //// PATCH: api/Groups/5
        //[HttpPatch("{id}")]
        //public async Task<IActionResult> EditGroupName(int id, [FromBody] EditGroupViewModel group)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return Ok(await _groupService.CreateGroupAsync(group));
        //    }
        //    return BadRequest(ModelState);
        //}


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var group = await _groupService.DeleteGroupAsync(id);
            if (group != null)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
