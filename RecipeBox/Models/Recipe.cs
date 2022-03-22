using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
  public class Recipe
  {
    
    public Recipe()
    {
      this.JoinEntities = new HashSet<CategoryRecipe>();
      this.Ingredients = new HashSet<RecipeIngredient>();
    }

    public int RecipeId { get; set; }
    public string Title { get; set; }
    public string Instructions { get; set; }
    public virtual ApplicationUser User { get; set; }

    public virtual ICollection<CategoryRecipe> JoinEntities { get; set;}
    public virtual ICollection<RecipeIngredient> Ingredients { get; set;}

  }
}