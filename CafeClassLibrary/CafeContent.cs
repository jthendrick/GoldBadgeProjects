using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeClassLibrary
{
    public class CafeContent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int MealNumber { get; set; }
        public double Price { get; set; }


        public CafeContent() { }

        public CafeContent(string name, string description, string ingredients, double price, int mealNumber)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
            MealNumber = mealNumber;

        }
    }
}

