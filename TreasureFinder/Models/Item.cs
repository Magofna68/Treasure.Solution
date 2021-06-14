using System;
using System.Collections.Generic;

namespace TreasureFinder.Models
{
  public class Item
  {

    public Item()
    {
      Images = new HashSet<Image>();
    }

    public int ItemId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Adress { get; set; }

    public string Condition { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Url { get; set; }

    public string Dimensions { get; set; }

    public string Weight { get; set; }

    public ICollection<Image> Images { get; set; }
    public int UserId { get; set; }
  }
}