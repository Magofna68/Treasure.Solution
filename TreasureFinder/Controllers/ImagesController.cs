using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreasureFinder.Models;
using System;



namespace TreasureFinder.Controllers
{

  [ApiController]
  [Route("api/[controller]/{itemId}")]
  public class ImagesController : ControllerBase
  {
    private readonly TreasureFinderContext _db;

    public ImagesController(TreasureFinderContext db)
    {
      _db = db;
    }
    [HttpPost]
    public IActionResult Post(Image image)
    {
      Console.WriteLine($"image {image}");
      _db.Images.Add(image);
      _db.SaveChanges();

      return Ok();
    }
  }
}
