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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prog6221poe3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RecipeManager recipeManager;

        public MainWindow()
        {
            InitializeComponent();
            recipeManager = new RecipeManager();
        }

        private void AddNewRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow(recipeManager);
            addRecipeWindow.ShowDialog();
        }

        private void DisplayAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            RecipesListBox.Items.Clear();
            foreach (var recipe in recipeManager.GetRecipes())
            {
                RecipesListBox.Items.Add(recipe.Name);
            }
        }

        private void DisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesListBox.SelectedItem != null)
            {
                string recipeName = RecipesListBox.SelectedItem.ToString();
                Recipe recipe = recipeManager.GetRecipeByName(recipeName);
                if (recipe != null)
                {
                    RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow(recipe);
                    recipeDetailsWindow.ShowDialog();
                }
            }
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesListBox.SelectedItem != null)
            {
                string recipeName = RecipesListBox.SelectedItem.ToString();
                Recipe recipe = recipeManager.GetRecipeByName(recipeName);
                if (recipe != null)
                {
                    ScaleRecipeWindow scaleRecipeWindow = new ScaleRecipeWindow();
                    if (scaleRecipeWindow.ShowDialog() == true && scaleRecipeWindow.IsScaled)
                    {
                        recipe.ScaleRecipe(scaleRecipeWindow.ScalingFactor);
                        MessageBox.Show($"Recipe '{recipe.Name}' scaled by factor {scaleRecipeWindow.ScalingFactor}.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            string ingredient = FilterIngredientTextBox.Text.ToLower();
            string foodGroup = ((ComboBoxItem)FilterFoodGroupComboBox.SelectedItem).Content.ToString();
            bool maxCaloriesValid = int.TryParse(MaxCaloriesTextBox.Text, out int maxCalories);

            var filteredRecipes = recipeManager.GetRecipes().Where(r =>
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredient))) &&
                (foodGroup == "All" || r.Ingredients.Any(i => i.FoodGroup.Equals(foodGroup, StringComparison.OrdinalIgnoreCase))) &&
                (!maxCaloriesValid || r.GetTotalCalories() <= maxCalories)).ToList();

            RecipesListBox.Items.Clear();
            foreach (var recipe in filteredRecipes)
            {
                RecipesListBox.Items.Add(recipe.Name);
            }
        }
    }
}





