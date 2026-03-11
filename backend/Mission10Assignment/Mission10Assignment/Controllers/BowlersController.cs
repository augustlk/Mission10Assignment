using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10Assignment.Data;

namespace Mission10Assignment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BowlersController : ControllerBase
{
    private readonly BowlingContext _context;

    public BowlersController(BowlingContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetBowlers()
    {
        var bowlers = await _context.Bowlers
            .Include(b => b.Team)
            .Where(b => b.Team!.TeamName == "Marlins" || b.Team!.TeamName == "Sharks")
            .Select(b => new
            {
                fullName = $"{b.BowlerFirstName} {b.BowlerMiddleInit}. {b.BowlerLastName}",
                teamName = b.Team!.TeamName,
                address = b.BowlerAddress,
                city = b.BowlerCity,
                state = b.BowlerState,
                zip = b.BowlerZip,
                phone = b.BowlerPhoneNumber
            })
            .ToListAsync();

        return Ok(bowlers);
    }
}