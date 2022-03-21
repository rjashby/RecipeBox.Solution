using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  // public class Ingredient
  // {
  //   public int RecipeId { get; set; }
  //   public string Title { get; set; }
  //   public string Instructions { get; set; }
  //   public virtual ApplicationUser User { get; set; }

  //   public virtual ICollection<CategoryRecipe> JoinEntities { get;}
  // }

  public class Recipe
  {
    
    public Recipe()
    {
      this.JoinEntities = new HashSet<CategoryRecipe>();
    }

    public int RecipeId { get; set; }
    public string Title { get; set; }
    public HashSet<string> Ingredients { get; set; } = new();
    public string Instructions { get; set; }
    public virtual ApplicationUser User { get; set; }

    public virtual ICollection<CategoryRecipe> JoinEntities { get;}

  }
}