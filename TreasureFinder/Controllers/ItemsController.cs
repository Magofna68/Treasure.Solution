using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TreasureFinder.Models;

namespace TreasureFinder.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class TreasureFinderController : ControllerBase
  {
    private readonly TreasureFinderContext _db;

    public TreasureFinderController(TreasureFinderContext db)
    {
      _db = db;
    }

    private bool ItemExists(int id) => _db.Items.Any(item => item.ItemId == id);

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> Get()
    {
      var items = await _db.Items.ToListAsync();
      return items;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
      var item = await _db.Items.FindAsync(id);
      if (item == null)
      {
        return NotFound();
      }
      return item;
    }

    [HttpPost]
    public async Task<ActionResult<Item>> Post(Item item)
    {
      _db.Items.Add(item);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetItem), new { id = item.ItemId }, item);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Item>> Put(int id, Item item)
    {
      if (id != item.ItemId) return BadRequest();

      _db.Entry(item).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ItemExists(id)) return NotFound();
        else throw;
      }
      return item;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteItem(int id)
    {
      Item item = await _db.Items.FindAsync(id);
      if (item == null) return NotFound();

      _db.Items.Remove(item);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}
