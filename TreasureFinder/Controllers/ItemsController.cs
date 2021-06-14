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
    public async Task<ActionResult<IEnumerable<Item>>> Get(string title, string description, string adress, string startdate, string enddate, string condition, bool images)
    {

      var query =  _db.Items.AsQueryable();
      if (title != null) query = query.Where(i => i.Title.Contains(title));
      if (description != null) query = query.Where(i => i.Description.Contains(description));
      if (adress != null) query = query.Where(i => i.Adress.Contains(adress));
  
      if (startdate != null && enddate != null) 
      {
        var startDate = DateTime.Parse(startdate);
        var endDate = DateTime.Parse(enddate);
        query = query.Where(i => i.CreatedAt >= startDate && i.CreatedAt <= endDate);
      }
      else if (startdate != null && enddate == null)
      {
        var startDate = DateTime.Parse(startdate);
        query = query.Where(i => i.CreatedAt >= startDate);
      } else if (startdate == null && enddate != null)
      {
        var endDate = DateTime.Parse(enddate);
        query = query.Where(i => i.CreatedAt <= endDate);
      } else 
      {
        Console.WriteLine("both start date and end date are null");
      }

      if (condition != null) query = query.Where(i => i.Condition == condition);

      if (images == true) query = query.Where(i => i.Images.Count > 0);
      // want to turn string to date & then pull out the month/day/year and compare with Item.CreatedAt
      return await query.ToListAsync();
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
