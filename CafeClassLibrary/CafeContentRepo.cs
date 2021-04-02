using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeClassLibrary
{
    public class CafeContentRepo
    {
        protected readonly List<CafeContent> _cafeDirectory = new List<CafeContent>();

        public bool AddItemToMenu(CafeContent item)
        {
            int startingCount = _cafeDirectory.Count;
            _cafeDirectory.Add(item);
            bool wasAdded = (_cafeDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<CafeContent> GetContent()
        {
            return _cafeDirectory;
        }

        public CafeContent GetContentByName(string name)
        {
            foreach(CafeContent item in _cafeDirectory)
            {
                if(item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }

            }
            return null;
        }

        public CafeContent GetContentByMealNumber(int mealNumber)
        {
            foreach (CafeContent item in _cafeDirectory)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }

            }
            return null;
        }

        public bool DeleteMealFromMenu(CafeContent existingMeal)
        {
            bool deleteMeal = _cafeDirectory.Remove(existingMeal);
            return deleteMeal;
        }
    }
}
