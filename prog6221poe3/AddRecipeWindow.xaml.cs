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
    /// Interaction logic for AddRecipeWindow.xaml
    /// </summary>

    
        public partial class AddRecipeWindow : Window
        {
            private RecipeManager recipeManager;

            public AddRecipeWindow(RecipeManager manager)
            {
                InitializeComponent();
                recipeManager = manager;
            }

            private void AddRecipe_Click(object sender, RoutedEventArgs e)
            {
                string recipeName = RecipeNameTextBox.Text;
                if (int.TryParse(NumIngredientsTextBox.Text, out int numIngredients) &&
                    int.TryParse(NumStepsTextBox.Text, out int numSteps))
                {
                    Recipe recipe = new Recipe(recipeName);

                    // Add ingredients
                    for (int i = 0; i < numIngredients; i++)
                    {
                        var ingredientPanel = IngredientsPanel.Children[i] as StackPanel;
                        var name = (ingredientPanel.Children[0] as TextBox).Text;
                        var quantity = double.Parse((ingredientPanel.Children[1] as TextBox).Text);
                        var unit = (ingredientPanel.Children[2] as TextBox).Text;
                        var calories = int.Parse((ingredientPanel.Children[3] as TextBox).Text);
                        var foodGroup = (ingredientPanel.Children[4] as TextBox).Text;

                        recipe.AddIngredient(name, quantity, unit, calories, foodGroup);
                    }

                    // Add steps
                    for (int i = 0; i < numSteps; i++)
                    {
                        var stepDescription = (StepsPanel.Children[i] as TextBox).Text;
                        recipe.AddStep(stepDescription);
                    }

                    recipeManager.AddRecipe(recipe);
                    this.Close();
                }
            }

            private void NumIngredientsTextBox_LostFocus(object sender, RoutedEventArgs e)
            {
                if (int.TryParse(NumIngredientsTextBox.Text, out int numIngredients))
                {
                    IngredientsPanel.Children.Clear();
                    for (int i = 0; i < numIngredients; i++)
                    {
                        var panel = new StackPanel { Orientation = Orientation.Horizontal };
                        panel.Children.Add(new TextBox { Text = "Name", Width = 80 });
                        panel.Children.Add(new TextBox { Text = "Quantity", Width = 60 });
                        panel.Children.Add(new TextBox { Text = "Unit", Width = 50 });
                        panel.Children.Add(new TextBox { Text = "Calories", Width = 60 });
                        panel.Children.Add(new TextBox { Text = "Food Group", Width = 80 });
                        IngredientsPanel.Children.Add(panel);
                    }
                }
            }

            private void NumStepsTextBox_LostFocus(object sender, RoutedEventArgs e)
            {
                if (int.TryParse(NumStepsTextBox.Text, out int numSteps))
                {
                    StepsPanel.Children.Clear();
                    for (int i = 0; i < numSteps; i++)
                    {
                        StepsPanel.Children.Add(new TextBox { Text = $"Step {i + 1}", Margin = new Thickness(0, 5, 0, 5) });
                    }
                }
            }
        }
    }

