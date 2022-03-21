using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class RecipeBoxContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<CategoryRecipe> CategoryRecipe { get; set; }

    public RecipeBoxContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //   // Configure the value converter for the Animal
    //   modelBuilder.Entity<Recipe>()
    //     .Property(x => x.Ingredients)
    //     .HasConversion(new ValueConverter<List<string>, string>(
    //       v => JsonConvert.SerializeObject(v), // Convert to string for persistence
    //       v => JsonConvert.DeserializeObject<List<string>>(v))); // Convert to List<String> for use
    // }
  }
}
