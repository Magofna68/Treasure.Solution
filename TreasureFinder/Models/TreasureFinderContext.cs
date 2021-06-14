using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
     
    }
    public DbSet<Image> Images { get; set; }
    public DbSet<Item> Items { get; set; }
  
  }
}