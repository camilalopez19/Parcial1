using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial1.Data;
using Parcial1.Models;

namespace Parcial1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly AppDbContext _db;

    public TicketController(AppDbContext db) => _db = db;

    // GET: api/event
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetAll()
        => Ok(await _db.Event.AsNoTracking().ToListAsync());

    // GET: api/event/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Event>> GetById(int id)
    {
        var e = await _db.Event.FindAsync(id);
        return e is null ? NotFound() : Ok(e);
    }

    // POST: api/event
    [HttpPost]
    public async Task<ActionResult<Event>> Create(Event dto)
    {
        _db.Event.Add(dto);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    // PUT: api/event/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Event dto)
    {
        var e = await _db.Event.FindAsync(id);
        if (e is null) return NotFound();

        e.Title    = dto.Title;
        e.Location = dto.Location;
        e.StartAt  = dto.StartAt;
        e.EndAt    = dto.EndAt;
        e.IsOnline = dto.IsOnline;
        e.Notes    = dto.Notes;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/event/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var e = await _db.Event.FindAsync(id);
        if (e is null) return NotFound();

        _db.Event.Remove(e);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}