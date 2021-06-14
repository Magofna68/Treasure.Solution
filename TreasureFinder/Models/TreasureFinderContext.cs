using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace TreasureFinder.Models
{
  public class TreasureFinderContext : DbContext
  {
    public TreasureFinderContext(DbContextOptions<TreasureFinderContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Item>()
      .HasMany(i => i.Images)
      .WithOne(im => im.Item)
      .IsRequired();

      builder.Entity<Item>(i =>
      {
        i.HasData(
          new
          {
            ItemId = 1,
            Title = "Free Couch",
            Description = "Free floral sectional",
            Condition = "Like New",
            Address = "123 Main Street",
            CreatedAt = DateTime.Now,
            Url = "http://www.google.com",
            Dimensions = "40X115X80",
            Weight = "50",
            UserId = 1
          });
      });

    }
    public DbSet<Image> Images { get; set; }
    public DbSet<Item> Items { get; set; }
  
  }
}