using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecipeBox.Controllers
{
  public class IngredientsController : Controller
  {
    private readonly RecipeBoxContext _db;

    public IngredientsController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Ingredients.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.BeerId = new SelectList(_db.Beers, "BeerId", "Name");
      ViewBag.DrinkerId = new SelectList(_db.Drinkers, "DrinkerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Ingredient Ingredient, int BeerId, int DrinkerId, string Title, string Description)
    {
      _db.Ingredients.Add(Ingredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisIngredient = _db.Ingredients
          .Include(Ingredient => Ingredient.Drinker)
          .Include(Ingredient => Ingredient.Beer)
          .FirstOrDefault(Ingredient => Ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    public ActionResult Edit(int id)
    {
      var thisIngredient = _db.Ingredients
      .FirstOrDefault(Ingredient => Ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    [HttpPost]
    public ActionResult Edit(Ingredient Ingredient)
    {
      _db.Entry(Ingredient).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisIngredient = _db.Ingredients.FirstOrDefault(Ingredient => Ingredient.IngredientId == id);
      return View(thisIngredient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisIngredient = _db.Ingredients.FirstOrDefault(Ingredient => Ingredient.IngredientId == id);
      _db.Ingredients.Remove(thisIngredient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}