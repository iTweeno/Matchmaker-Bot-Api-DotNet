using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MatchmakerBotAPI.Core.Services.Teams;
using MatchmakerBotAPI.Core.Models.Teams;

namespace MatchmakerBotAPI.Controllers.Teams
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsService _teamsService;
        public TeamsController(ITeamsService teamsService) {
            _teamsService = teamsService;
        }

        [HttpPost]
        [Route("[action]/")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> AddTeam([FromBody] TeamsModel team)
        {
            if (!ModelState.IsValid || team.name == null || team.captain == null || team.GuildId == null || team.players == null || team.channels == null || team._id != null)
            {
                return BadRequest();
            }

            var inserted = await _teamsService.AddTeam(team);

            if (!inserted)
            {
                return StatusCode(403);
            }

            return Created(nameof(AddTeam), team);
        }

        [HttpGet]
        [Route("[action]/{id}/{guildId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetTeamByPlayerId([FromRoute] string id,[FromRoute] string guildId)
        {
            var team = await _teamsService.GetTeamByPlayerId(id, guildId);

            if (team == null)
            {
                return NoContent();
            }

            return Ok(team);
        }
        
        [HttpGet]
        [Route("[action]/{guildId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetTeamsByGuildId([FromRoute] string guildId, [FromQuery] int page)
        {
            var teams = await _teamsService.GetTeamsByGuildId(guildId, page);

            if (teams.total == 0)
            {
                return NoContent();
            }

            return Ok(teams);
        }

        [HttpPut]
        [Route("[action]/{name}/{guildId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(304)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditTeam([FromRoute] string name, [FromRoute] string guildId, [FromBody] TeamsModel team)
        {
            if (!ModelState.IsValid || team.name == null || team.captain == null || team.GuildId == null || team.players == null || team.channels == null || team._id != null)
            {
                return BadRequest();
            }

            var edited = await _teamsService.EditTeam(name,guildId, team);

            if (!edited)
            {
                return StatusCode(304);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{name}/{guildId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTeam([FromRoute] string name,[FromRoute] string guildId)
        {
            if (name.Equals("") || guildId.Equals(""))
            {
                return BadRequest();
            }

            var deleted = await _teamsService.DeleteTeam(name, guildId);

            if (!deleted)
            {
                return NoContent();
            }

            return Ok();
        }
    }
}