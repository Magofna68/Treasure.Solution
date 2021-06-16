using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Http;
using TreasureFinder.Models;


namespace TreasureFinder.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class ItemsController : ControllerBase
  {
    private readonly TreasureFinderContext _db;

    public ItemsController(TreasureFinderContext db)
    {
      _db = db;
    }

    private bool ItemExists(int id) => _db.Items.Any(item => item.ItemId == id);

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> Get(string title, string description, string address, string startdate, string enddate, string condition, bool images)
    {
      // url?startdate=2021/12/05&enddate=2021/06/06
      var query = _db.Items.AsQueryable();
      if (title != null) query = query.Where(i => i.Title.Contains(title.Trim()));
      if (description != null) query = query.Where(i => i.Description.Contains(description.Trim()));
      if (address != null) query = query.Where(i => i.Address.Contains(address.Trim()));

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
      }
      else if (startdate == null && enddate != null)
      {
        var endDate = DateTime.Parse(enddate);
        query = query.Where(i => i.CreatedAt <= endDate);
      }
      else
      {
        Console.WriteLine("both start date and end date are null");
      }

      if (condition != null) query = query.Where(i => i.Condition == condition.Trim());

      if (images == true) query = query.Where(i => i.Images.Count > 0);
      query.Include(entity => entity.Images);
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
      var item = await _db.Items.Include(i => i.Images)
      .FirstOrDefaultAsync(i => i.ItemId == id);
      if (item == null)
      {
        return NotFound();
      }
      return item;
    }

    [HttpPost("create/")]
    public async Task<ActionResult<Item>> Post(Item item)
    {

      _db.Items.Add(item);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetItem), new { id = item.ItemId }, item);
    }

    [HttpPut("edit/{id}")]
    public async Task<ActionResult<Item>> Put(int id, Item item)
    {
      Console.WriteLine($"id: {id}, item: {item}");
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
