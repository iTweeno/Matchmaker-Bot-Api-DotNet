using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MatchmakerBotAPI.Core.Services.Guilds;
using MatchmakerBotAPI.Core.Models.Guilds;

namespace MatchmakerBotAPI.Controllers.Guilds
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuildsController : ControllerBase
    {
        private readonly IGuildsService _guildsService;
        public GuildsController(IGuildsService guildsService) {
            _guildsService = guildsService;
        }

        [HttpPost]
        [Route("[action]/")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> AddGuild([FromBody] GuildsModel guild)
        {
            if (!ModelState.IsValid || guild.id == null || guild.channels == null || guild._id != null)
            {
                return BadRequest();
            }

            var inserted = await _guildsService.AddGuild(guild);

            if (!inserted)
            {
                return StatusCode(403);
            }

            return Created(nameof(AddGuild), guild);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetGuildById([FromRoute] string id)
        {
            var guild = await _guildsService.GetGuildById(id);

            if (guild == null)
            {
                return NoContent();
            }

            return Ok(guild);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(304)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditGuild([FromRoute] string id, [FromBody] GuildsModel guild)
        {
            if (!ModelState.IsValid || guild.id == null || guild.channels == null || guild._id != null)
            {
                return BadRequest();
            }

            var edited = await _guildsService.EditGuild(id, guild);

            if (!edited)
            {
                return StatusCode(304);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteGuild([FromRoute] string id)
        {
            if (id.Equals(""))
            {
                return BadRequest();
            }

            var deleted = await _guildsService.DeleteGuild(id);

            if (!deleted)
            {
                return NoContent();
            }

            return Ok();
        }
    }
}