using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Name { get; set; }

        public int RecipeId { get; set; }

        public DateTime CommentedOn { get; set; }
    }
}
