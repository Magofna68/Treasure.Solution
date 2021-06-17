using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using TreasureFinder.Models;


namespace TreasureFinder.Controllers
{

  [ApiController]
  [Route("/api/[controller]/upload")]
  public class ImagesController : ControllerBase
  {
    private readonly TreasureFinderContext _db;

    public ImagesController(TreasureFinderContext db)
    {
      _db = db;
    }
    [HttpPost]
    public async Task<IActionResult> Post(Image image)
    {
      Console.WriteLine($"image: {image}");
        _db.Images.Add(image);
        await _db.SaveChangesAsync();
      
      return Ok();
    }
  }
}
