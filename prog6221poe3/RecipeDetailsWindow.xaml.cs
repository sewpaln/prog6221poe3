using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prog6221poe3
{
    /// <summary>
    /// Interaction logic for RecipeDetailsWindow.xaml
    /// </summaryy
  
    
        public partial class RecipeDetailsWindow : Window
        {
            public RecipeDetailsWindow(Recipe recipe)
            {
                InitializeComponent();
                DisplayRecipeDetails(recipe);
            }

            private void DisplayRecipeDetails(Recipe recipe)
            {
                RecipeDetailsTextBlock.Text = $"Recipe: {recipe.Name}\n\nIngredients:\n";
                foreach (var ingredient in recipe.Ingredients)
                {
                    RecipeDetailsTextBlock.Text += $"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit} ({ingredient.Calories} calories, {ingredient.FoodGroup})\n";
                }
                RecipeDetailsTextBlock.Text += "\nSteps:\n";
                for (int i = 0; i < recipe.Steps.Count; i++)
                {
                    RecipeDetailsTextBlock.Text += $"{i + 1}. {recipe.Steps[i]}\n";
                }
                RecipeDetailsTextBlock.Text += $"\nTotal Calories: {recipe.GetTotalCalories()}";
            }
        }
    }
