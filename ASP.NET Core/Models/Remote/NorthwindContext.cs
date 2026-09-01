using System;
using Microsoft.EntityFrameworkCore;

namespace ASP_NET_Core.Models.Remote {
  public partial class NorthwindContext : DbContext
  {
    public NorthwindContext() {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options) {
    }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if (!optionsBuilder.IsConfigured) {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;");
      }
    }
  }
}
