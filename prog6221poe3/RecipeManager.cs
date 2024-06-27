using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog6221poe3
{
    public class RecipeManager
    { 

        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            recipes = recipes.OrderBy(r => r.Name).ToList();
        }

        public List<Recipe> GetRecipes()
        {
            return recipes;
        }

        public Recipe GetRecipeByName(string name)
        {
            return recipes.FirstOrDefault(recipe => recipe.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
    

