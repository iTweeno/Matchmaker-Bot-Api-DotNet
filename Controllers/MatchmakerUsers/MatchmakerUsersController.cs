using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MatchmakerBotAPI.Core.Services.MatchmakerUsers;
using MatchmakerBotAPI.Core.Models.MatchmakerUsersModel;

namespace MatchmakerBotAPI.Core.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class MatchmakerUsersController : ControllerBase
    {
        private IMatchmakerUsersService _matchmakerUsersService;

        public MatchmakerUsersController(IMatchmakerUsersService matchmakerUsersService)
        {
            _matchmakerUsersService = matchmakerUsersService;
        }
        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var user = await _matchmakerUsersService.GetUserById(id);

            if (user == null)
            {
                return NoContent();
            }

            return Ok(user);
        }
        [HttpPost]
        [Route("[action]/")]
        [ProducesResponseType(403)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> AddUser([FromBody] MatchmakerUsersModel user)
        {
            if (!ModelState.IsValid || user.id == null || user.name == null || user.servers == null)
            {
                return BadRequest();
            }

            var inserted = await _matchmakerUsersService.AddUser(user);

            if (!inserted)
            {
                return StatusCode(403);
            }

            return Created(nameof(AddUser), user);
        }
        [HttpPut]
        [Route("[action]/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(304)]
        public async Task<IActionResult> EditUser([FromRoute] string id, [FromBody] MatchmakerUsersModel user)
        {
            if (!ModelState.IsValid || user.id == null || user.name == null || user.servers == null)
            {
                return BadRequest();
            }

            var edited = await _matchmakerUsersService.EditUser(id, user);

            if(!edited) {
                return StatusCode(304);
            }

            return Ok();
        }
        [HttpDelete]
        [Route("[action]/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            if(id.Equals("")) {
                return BadRequest();
            }

            var deleted = await _matchmakerUsersService.DeleteUser(id);

            if(!deleted) {
                return NoContent();
            }

            return Ok();
        }
    }
}
