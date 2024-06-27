using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog6221poe3
{

    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<string> Steps { get; private set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
        }

        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        public int GetTotalCalories()
        {
            return Ingredients.Sum(i => i.Calories);
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }
    }

   
}
    

