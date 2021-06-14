using System.ComponentModel.DataAnnotations.Schema;
namespace TreasureFinder.Models
{
  public class Image
  {
    public int ImageId { get; set; }
    public string ImageString { get; set; }
    [ForeignKey("Item")]
    public int ItemId { get; set; }
    public  Item Item { get; set; }
  }
}