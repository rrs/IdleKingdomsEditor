using IdleKingdomsEditor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            //_savedRoutes = savedRoutes;
            //foreach(var route in savedRoutes)
            //{
            //    SavedRoutes.Items.Add(route);
            //}
            //if (savedRoutes.Any())
            //{
            //    SavedRoutes.SelectedItem = savedRoutes.First();
            //}
        }

        //private void HexList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
           
        //    //if (e.AddedItems.Count > 0 && e.AddedItems[0] is DependencyObject selected)
        //    //{

        //    //    var currentPrestige = TileHelper.GetPrestigeMultiplier(selected);
        //    //    var currentFood = TileHelper.GetFoodMultiplier(selected);
        //    //    var currentFoodCart = TileHelper.GetFoodCartMultiplier(selected);
        //    //    var currentWood = TileHelper.GetWoodMultiplier(selected);
        //    //    var currentWoodCart = TileHelper.GetWoodCartMultiplier(selected);
        //    //    var currentScience = TileHelper.GetScienceMultiplier(selected);
        //    //    var currentAllCart = TileHelper.GetAllCartMultiplier(selected);

        //    //    CurrentPrestige.Text = currentPrestige > 0 ? FormatNumber(currentPrestige) : null;
        //    //    CurrentFood.Text = currentFood > 0 ? FormatNumber(currentFood) : null;
        //    //    CurrentFoodCart.Text = currentFoodCart > 0 ? FormatNumber(currentFoodCart) : null;
        //    //    CurrentWood.Text = currentWood > 0 ? FormatNumber(currentWood) : null;
        //    //    CurrentWoodCart.Text = currentWoodCart > 0 ? FormatNumber(currentWoodCart) : null;
        //    //    CurrentScience.Text = currentScience > 0 ? FormatNumber(currentScience) : null;
        //    //    CurrentAllCart.Text = currentAllCart > 0 ? FormatNumber(currentAllCart) : null;
        //    //}

        //    //if (SavedRoutes.SelectedItem is SavedRoute selectedRoute)
        //    //{
        //    //    selectedRoute.Cells = SelectedCells.ToList();
        //    //}
        //}

        //private void SavedRoutes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //var selectedRoute = SavedRoutes.SelectedItem as SavedRoute;
        //    //if (selectedRoute == null) return;

        //    //HexList.SelectedItems.Clear();

        //    //var hexCells = from hexItem in HexList.Items.Cast<UIElement>()
        //    //               join hexCell in selectedRoute.Cells on new { Row = Grid.GetRow(hexItem), Col = Grid.GetColumn(hexItem) } equals new { hexCell.Row, hexCell.Col }
        //    //               select hexItem;

        //    //foreach (var cell in hexCells)
        //    //{
        //    //    HexList.SelectedItems.Add(cell);
        //    //}

        //    //HeightTextBox.Text = selectedRoute.Height.ToString();
        //    //WidthTextBox.Text = selectedRoute.Width.ToString();
        //}
    }
}
