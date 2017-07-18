using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookBook.Models;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CookBook
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        public static List<Recipe> Database { get; set; }
        public static int id { get; set; }

        // GET: api/values
        [Route("/api/recipes")]
        public JsonResult GetRecipes()
        {
            var recipes = Database.Select(m => new { m.Id, m.Title, m.ImageUrl }).ToList();

            return Json(recipes);
        }

        [Route("/api/recipes/{id}")]
        public JsonResult GetRecipes(int id)
        {

            var recipe = Database.FirstOrDefault(m => m.Id == id);

            return Json(recipe);
        }

        [Route("/api/recipe/")]
        [HttpPost]
        public JsonResult Post(Recipe recipe)
        {
            if (!string.IsNullOrEmpty(recipe.Title))
            {
                id++;
                recipe.Id = id;
                Database.Add(recipe);
                return Json(recipe.Id);
            }
            return Json("error");
        }

        [Route("/api/updaterecipe/")]
        [HttpPost]
        public JsonResult Update(Recipe recipe)
        {
            Recipe objRecipe = Database.FirstOrDefault(m => m.Id == recipe.Id);
            if (objRecipe != null)
            {
                int index = Database.IndexOf(objRecipe);
                objRecipe.Title = recipe.Title;
                objRecipe.ImageUrl = recipe.ImageUrl;
                objRecipe.Description = recipe.Description;
                objRecipe.Ingredients = recipe.Ingredients;
                objRecipe.Instructions = recipe.Instructions;
                objRecipe.Rating = recipe.Rating;
                Database[index] = objRecipe;
                return Json("success");
            }
            return Json("error");
        }

        [Route("/api/deleterecipe/{id}")]
        [HttpGet]
        public JsonResult Delete(int id)
        {
            Recipe objRecipe = Database.FirstOrDefault(m => m.Id == id);
            if (objRecipe != null)
            {
                Database.Remove(objRecipe);
                return Json("success");
            }
            return Json("error");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (Database == null)
                Database = GetDummyData();
            base.OnActionExecuting(context);
        }

        [NonAction]
        public List<Recipe> GetDummyData()
        {
            id = 3;
            return new List<Recipe>()
            {
                new Recipe { Id = 1, Title="Title 1", ImageUrl="http://i.imgur.com/FSfvsQl.jpg",Description="Vegetables in a curry sauce wrapped and fried until golden brown",Rating=0,Ingredients=new List<string>{"2 tablespoons vegetable oil","4 medium potatoes","peeled and cut into 1/2-inch cubes","1/2 cup chopped yellow onion","3/4 cup canned peas and carrots","drained 1 cup Red Curry Sauce","Flour for baking sheet","12 large wonton wrappers"},Instructions= new List<string>{"In large skillet heat 2 tablespoons oil over medium heat. Add potatoes and onion; cook stirring constantly. About 15 minutes or until soft. Add peas and carrots and curry sauce and cook 4-5 minutes. Cool.","Lightly flour baking sheet. Cut each wonton wrapper in half on the diagonal to make 2 triangles. Spoon 1-2 tablespoons filling in center of each triangle. Brush edges of wrappers with water; fold in half to form a triangle and press edges together to seal. Transfer to prepared baking sheet.","In deep-fryer heat oil to 350 degrees F. Fry samosas a few at a time. Turning occasionally for 2-3 minutes or until golden brown. Drain on paper towels. Serve with chutney."} },
                new Recipe { Id = 2, Title="Title 2", ImageUrl="http://i.imgur.com/FSfvsQl.jpg",Description="Vegetables in a curry sauce wrapped and fried until golden brown",Rating=0,Ingredients=new List<string>{"2 tablespoons vegetable oil","4 medium potatoes","peeled and cut into 1/2-inch cubes","1/2 cup chopped yellow onion","3/4 cup canned peas and carrots","drained 1 cup Red Curry Sauce","Flour for baking sheet","12 large wonton wrappers"},Instructions= new List<string>{"In large skillet heat 2 tablespoons oil over medium heat. Add potatoes and onion; cook stirring constantly. About 15 minutes or until soft. Add peas and carrots and curry sauce and cook 4-5 minutes. Cool.","Lightly flour baking sheet. Cut each wonton wrapper in half on the diagonal to make 2 triangles. Spoon 1-2 tablespoons filling in center of each triangle. Brush edges of wrappers with water; fold in half to form a triangle and press edges together to seal. Transfer to prepared baking sheet.","In deep-fryer heat oil to 350 degrees F. Fry samosas a few at a time. Turning occasionally for 2-3 minutes or until golden brown. Drain on paper towels. Serve with chutney."} },
                new Recipe { Id = 3, Title="Title 3", ImageUrl="http://i.imgur.com/FSfvsQl.jpg",Description="Vegetables in a curry sauce wrapped and fried until golden brown",Rating=0,Ingredients=new List<string>{"2 tablespoons vegetable oil","4 medium potatoes","peeled and cut into 1/2-inch cubes","1/2 cup chopped yellow onion","3/4 cup canned peas and carrots","drained 1 cup Red Curry Sauce","Flour for baking sheet","12 large wonton wrappers"},Instructions= new List<string>{"In large skillet heat 2 tablespoons oil over medium heat. Add potatoes and onion; cook stirring constantly. About 15 minutes or until soft. Add peas and carrots and curry sauce and cook 4-5 minutes. Cool.","Lightly flour baking sheet. Cut each wonton wrapper in half on the diagonal to make 2 triangles. Spoon 1-2 tablespoons filling in center of each triangle. Brush edges of wrappers with water; fold in half to form a triangle and press edges together to seal. Transfer to prepared baking sheet.", "In deep-fryer heat oil to 350 degrees F. Fry samosas a few at a time. Turning occasionally for 2-3 minutes or until golden brown. Drain on paper towels. Serve with chutney." } }
            };
        }
    }
}
