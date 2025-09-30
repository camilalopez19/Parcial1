using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial1.Data;
using Parcial1.Models;

namespace Parcial1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupportTicketsController : ControllerBase
{
    private readonly AppDbContext _db;
    public SupportTicketsController(AppDbContext db) => _db = db;

    // GET: api/supporttickets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupportTicket>>> GetAll()
        => Ok(await _db.SupportTickets.AsNoTracking().ToListAsync());

    // GET: api/supporttickets/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<SupportTicket>> GetById(int id)
    {
        var t = await _db.SupportTickets.FindAsync(id);
        return t is null ? NotFound() : Ok(t);
    }

    // POST: api/supporttickets
    [HttpPost]
    public async Task<ActionResult<SupportTicket>> Create(SupportTicket dto)
    {
        _db.SupportTickets.Add(dto);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    // PUT: api/supporttickets/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, SupportTicket dto)
    {
        var t = await _db.SupportTickets.FindAsync(id);
        if (t is null) return NotFound();

        t.Subject        = dto.Subject;
        t.RequesterEmail = dto.RequesterEmail;
        t.Description    = dto.Description;
        t.Severity       = dto.Severity;
        t.Status         = dto.Status;
        t.OpenedAt       = dto.OpenedAt;
        t.ClosedAt       = dto.ClosedAt;
        t.AssignedTo     = dto.AssignedTo;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/supporttickets/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var t = await _db.SupportTickets.FindAsync(id);
        if (t is null) return NotFound();

        _db.SupportTickets.Remove(t);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
