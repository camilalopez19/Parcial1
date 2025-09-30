using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial1.Data;
using Parcial1.Models;

namespace Parcial1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProductController(AppDbContext db) => _db = db;

    // GET: api/product
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        => Ok(await _db.Product.AsNoTracking().ToListAsync());

    // GET: api/product/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var p = await _db.Product.FindAsync(id);
        return p is null ? NotFound() : Ok(p);
    }

    // POST: api/product
    [HttpPost]
    public async Task<ActionResult<Product>> Create(Product dto)
    {
        _db.Product.Add(dto);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    // PUT: api/product/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Product dto)
    {
        var p = await _db.Product.FindAsync(id);
        if (p is null) return NotFound();

        p.Name        = dto.Name;
        p.Description = dto.Description;
        p.Price       = dto.Price;
        p.Stock       = dto.Stock;
        p.IsActive    = dto.IsActive;
        p.UpdatedAt   = DateTime.UtcNow;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/product/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var p = await _db.Product.FindAsync(id);
        if (p is null) return NotFound();

        _db.Product.Remove(p);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}