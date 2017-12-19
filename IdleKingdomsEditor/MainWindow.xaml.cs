using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IdleKingdomsEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HexList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int total = 0;
            int forests = 0;
            double prestige = 1;
            double food = 1;
            double foodCart = 1;
            double wood = 1;
            double woodCart = 1;
            double science = 1;
            double scienceCart = 1;

            foreach (var hexItem in HexList.SelectedItems)
            {
                total++;

                var o = (DependencyObject)hexItem;

                var type = TileHelper.GetTileType(o);
                if (type == TileType.Forest) forests++;

                var pMultiplier = TileHelper.GetPrestigeMultiplier(o);
                if (pMultiplier > 1) prestige *= pMultiplier;

                var fMultiplier = TileHelper.GetFoodMultiplier(o);
                if (fMultiplier > 1) food *= fMultiplier;

                var fcMultiplier = TileHelper.GetFoodCartMultiplier(o);
                if (fcMultiplier > 1) foodCart *= fcMultiplier;

                var wMultiplier = TileHelper.GetWoodMultiplier(o);
                if (wMultiplier > 1) wood *= wMultiplier;

                var wcMultiplier = TileHelper.GetWoodCartMultiplier(o);
                if (wcMultiplier > 1) woodCart *= wcMultiplier;

                var sMultiplier = TileHelper.GetScienceMultiplier(o);
                if (sMultiplier > 1) science *= sMultiplier;

                var aMultiplier = TileHelper.GetAllCartMultiplier(o);
                if (aMultiplier > 1)
                {
                    foodCart *= aMultiplier;
                    woodCart *= aMultiplier;
                    scienceCart *= aMultiplier;
                }
            }

            SelectedInfo.Text = total.ToString();
            ForestInfo.Text = forests.ToString();
            PrestigeMultiplier.Text = FormatNumber(prestige);
            PrestigeInfo.Text = FormatNumber(total - 9 > 0 ? (total - 9) * prestige : 0);
            FoodInfo.Text = FormatNumber(food);
            FoodCartInfo.Text = FormatNumber(foodCart);
            WoodInfo.Text = FormatNumber(wood);
            WoodCartInfo.Text = FormatNumber(woodCart);
            ScienceInfo.Text = FormatNumber(science);
            ScienceCartInfo.Text = FormatNumber(scienceCart);

            DependencyObject selected = null;
            if (e.AddedItems.Count > 0)
            {
                selected = (DependencyObject)e.AddedItems[0];
            }

            if (selected == null) return;

            var currentPrestige = TileHelper.GetPrestigeMultiplier(selected);
            var currentFood = TileHelper.GetFoodMultiplier(selected);
            var currentFoodCart = TileHelper.GetFoodCartMultiplier(selected);
            var currentWood = TileHelper.GetWoodMultiplier(selected);
            var currentWoodCart = TileHelper.GetWoodCartMultiplier(selected);
            var currentScience = TileHelper.GetScienceMultiplier(selected);
            var currentAllCart = TileHelper.GetAllCartMultiplier(selected);

            CurrentPrestige.Text = currentPrestige > 0 ? FormatNumber(currentPrestige) : null;
            CurrentFood.Text = currentFood > 0 ? FormatNumber(currentFood) : null;
            CurrentFoodCart.Text = currentFoodCart > 0 ? FormatNumber(currentFoodCart) : null;
            CurrentWood.Text = currentWood > 0 ? FormatNumber(currentWood) : null;
            CurrentWoodCart.Text = currentWoodCart > 0 ? FormatNumber(currentWoodCart) : null;
            CurrentScience.Text = currentScience > 0 ? FormatNumber(currentScience) : null;
            CurrentAllCart.Text = currentAllCart > 0 ? FormatNumber(currentAllCart) : null;
        }

        static readonly string[] _suffixes = 
            {
                "",
                "K",
                "M",
                "B",
                "T",
                "a",
                "b",
                "c",
                "d",
                "e",
                "f"
            };

        private string FormatNumber(double n)
        {
            int index = 0;

            while (n > 1000)
            {
                n /= 1000;
                index++;
            }

            return $"{n:###.##}{_suffixes[index]}";
        }

        private void WidthTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (hexGrid == null) return;
            if (double.TryParse(WidthTextBox.Text, out var width))
            {
                hexGrid.Width = width;
            }
        }

        private void HeightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (hexGrid == null) return;
            if (double.TryParse(HeightTextBox.Text, out var height))
            {
                hexGrid.Height = height;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HexList.SelectedItems.Clear();
        }
    }
}
