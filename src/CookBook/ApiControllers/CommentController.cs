using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookBook.Models;
using Microsoft.AspNetCore.Mvc.Filters;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CookBook.ApiControllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        public static List<Comment> Database { get; set; }
        public static int id { get; set; }

        // GET api/values/5
        [Route("/api/comments/{id}")]
        public JsonResult GetByRecipeID(int id)
        {
            var comments = Database.Where(m => m.RecipeId == id).OrderBy(m => m.CommentedOn).ToList();

            return Json(comments);
        }

        // POST api/values
        [HttpPost]
        [Route("/api/comment")]
        public JsonResult Post(Comment comment)
        {
            if (!string.IsNullOrEmpty(comment.Text) && !string.IsNullOrEmpty(comment.Name))
            {
                id++;
                comment.Id = id;
                comment.CommentedOn = DateTime.Now;
                Database.Add(comment);
                return Json(comment);
            }
            return Json("error");
        }

        // DELETE api/values/5
        [Route("/api/deletecomment/{id}")]
        [HttpGet]
        public JsonResult Delete(int id)
        {
            Comment comment = Database.FirstOrDefault(m => m.Id == id);
            if (comment != null)
            {
                Database.Remove(comment);
                return Json("success");
            }
            return Json("error");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (Database == null)
            {
                Database = new List<Comment>();
                id = 0;
            }
            base.OnActionExecuting(context);
        }
    }
}
