using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft_Azure.Data;
using Microsoft_Azure.Models;

[Route("api/[controller]")]
[ApiController]
public class AssetController : ControllerBase
{
    private readonly BattleGameContext _context;

    public AssetController(BattleGameContext context)
    {
        _context = context;
    }

    // API: POST /api/asset/createasset
    [HttpPost("createasset")]
    public async Task<IActionResult> CreateAsset([FromBody] Asset asset)
    {
        if (asset == null)
        {
            return BadRequest(new { message = "Invalid asset data" });
        }

        asset.Assetid = Guid.NewGuid();
        _context.Assets.Add(asset);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Create asset successfully", asset });
    }

    // API: GET /api/asset/getassetsbyplayer
    [HttpGet("getassetsbyplayer")]
    public async Task<IActionResult> GetAssetsByPlayer()
    {
        var query = from p in _context.Players
                    join pa in _context.PlayerAssets on p.Playerid equals pa.Playerid
                    join a in _context.Assets on pa.Assetid equals a.Assetid
                    select new
                    {
                        PlayerName = p.PlayerName,
                        Level = p.Level,
                        Age = p.Age,
                        AssetName = a.AssetName
                    };

        var result = await query.ToListAsync();
        return Ok(result);
    }
}