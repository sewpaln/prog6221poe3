using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog6221poe3
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
        public double OriginalQuantity { get; private set; } // To store original quantity

        // Constructor to initialize ingredient properties
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            OriginalQuantity = quantity; // Set original quantity
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        // Method to reset quantity to its original value
        public void ResetQuantity()
        {
            Quantity = OriginalQuantity;
        }

    }
}

