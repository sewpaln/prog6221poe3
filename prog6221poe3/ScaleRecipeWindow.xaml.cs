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
    /// Interaction logic for ScaleRecipeWindow.xaml
    /// </summary>
    
        public partial class ScaleRecipeWindow : Window
        {
            public double ScalingFactor { get; private set; }
            public bool IsScaled { get; private set; }

            public ScaleRecipeWindow()
            {
                InitializeComponent();
                IsScaled = false;
            }

            private void Scale_Click(object sender, RoutedEventArgs e)
            {
                if (double.TryParse(ScalingFactorTextBox.Text, out double scalingFactor) && scalingFactor > 0)
                {
                    ScalingFactor = scalingFactor;
                    IsScaled = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a valid positive number for the scaling factor.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            private void Cancel_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        }
    }
