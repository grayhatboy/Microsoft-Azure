using Microsoft_Azure.Data;
using Microsoft_Azure.Models;
using Microsoft.AspNetCore.Mvc; 

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly BattleGameContext _context;

    public PlayerController(BattleGameContext context)
    {
        _context = context;
    }

    // API: POST /api/player/registerplayer
    [HttpPost("registerplayer")]
    public async Task<IActionResult> RegisterPlayer([FromBody] Player player)
    {
        if (player == null)
        {
            return BadRequest(new { message = "Invalid player data" });
        }

        player.Playerid = Guid.NewGuid();
        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Register player successfully", player });
    }
}