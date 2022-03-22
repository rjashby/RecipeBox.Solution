using System;
using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Ingredient
  {

    public Ingredient()
    {
      this.Ingredients = new HashSet<RecipeIngredient>();
    }
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    public virtual ICollection<RecipeIngredient> Ingredients { get; set;}
  }

}