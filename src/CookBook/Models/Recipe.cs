using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Ingredients { get; set; }

        public List<string> Instructions { get; set; }

        public string ImageUrl { get; set; }

        public int Rating { get; set; }
    }
}
