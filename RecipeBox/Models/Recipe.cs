using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public Item()
    {
      this.JoinEntities = new HashSet<CategoryRecipe>();
    }

    public int RecipeId { get; set; }
    public string Title { get; set; }
    public List<string> Ingredients { get; set; }
    public string Instructions { get; set; }
    public virtual ApplicationUser User { get; set; }

    public virtual ICollection<CategoryRecipe> JoinEntities { get;}
  }
}