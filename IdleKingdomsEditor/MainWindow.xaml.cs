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
        private List<SavedRoute> _savedRoutes;

        public MainWindow(/*List<SavedRoute> savedRoutes*/)
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

        private void HexList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int nSelected = 0;
            //int forests = 0;
            //double prestige = 1;
            //double food = 1;
            //double foodCart = 1;
            //double wood = 1;
            //double woodCart = 1;
            //double science = 1;
            //double scienceCart = 1;

            //foreach (var hexItem in HexList.SelectedItems)
            //{
            //    nSelected++;

            //    var o = (DependencyObject)hexItem;

            //    var type = TileHelper.GetTileType(o);
            //    if (type == TileType.Forest) forests++;

            //    var pMultiplier = TileHelper.GetPrestigeMultiplier(o);
            //    if (pMultiplier > 1) prestige *= pMultiplier;

            //    var fMultiplier = TileHelper.GetFoodMultiplier(o);
            //    if (fMultiplier > 1) food *= fMultiplier;

            //    var fcMultiplier = TileHelper.GetFoodCartMultiplier(o);
            //    if (fcMultiplier > 1) foodCart *= fcMultiplier;

            //    var wMultiplier = TileHelper.GetWoodMultiplier(o);
            //    if (wMultiplier > 1) wood *= wMultiplier;

            //    var wcMultiplier = TileHelper.GetWoodCartMultiplier(o);
            //    if (wcMultiplier > 1) woodCart *= wcMultiplier;

            //    var sMultiplier = TileHelper.GetScienceMultiplier(o);
            //    if (sMultiplier > 1) science *= sMultiplier;

            //    var aMultiplier = TileHelper.GetAllCartMultiplier(o);
            //    if (aMultiplier > 1)
            //    {
            //        foodCart *= aMultiplier;
            //        woodCart *= aMultiplier;
            //        scienceCart *= aMultiplier;
            //    }
            //}

            //var lastKnowRatio = _tilesCosts[_tilesCosts.Length - 1] / _tilesCosts[_tilesCosts.Length - 2];

            //var tileCosts = Enumerable.Range(0, nSelected + 2).Select(o => o < _tilesCosts.Length ? _tilesCosts[o] : _tilesCosts[_tilesCosts.Length - 1] * Math.Pow(lastKnowRatio, o - _tilesCosts.Length + 1)).ToList();

            //var nextTileCost = tileCosts[tileCosts.Count - 1];
            //var totalTileCost = tileCosts.Sum() - nextTileCost;

            //TileCost.Text = (nSelected + 1 < _tilesCosts.Length ? "" : "~") + FormatNumber(nextTileCost);
            //TileCostTotal.Text = (nSelected < _tilesCosts.Length ? "" : "~") + FormatNumber(totalTileCost);
            //SelectedInfo.Text = nSelected.ToString();
            //ForestInfo.Text = forests.ToString();
            //PrestigeMultiplier.Text = FormatNumber(prestige);
            //PrestigeInfo.Text = FormatNumber(nSelected - 9 > 0 ? (nSelected - 9) * prestige : 0);
            //FoodInfo.Text = FormatNumber(food);
            //FoodCartInfo.Text = FormatNumber(foodCart);
            //WoodInfo.Text = FormatNumber(wood);
            //WoodCartInfo.Text = FormatNumber(woodCart);
            //ScienceInfo.Text = FormatNumber(science);
            //ScienceCartInfo.Text = FormatNumber(scienceCart);

            //if (e.AddedItems.Count > 0 && e.AddedItems[0] is DependencyObject selected)
            //{

            //    var currentPrestige = TileHelper.GetPrestigeMultiplier(selected);
            //    var currentFood = TileHelper.GetFoodMultiplier(selected);
            //    var currentFoodCart = TileHelper.GetFoodCartMultiplier(selected);
            //    var currentWood = TileHelper.GetWoodMultiplier(selected);
            //    var currentWoodCart = TileHelper.GetWoodCartMultiplier(selected);
            //    var currentScience = TileHelper.GetScienceMultiplier(selected);
            //    var currentAllCart = TileHelper.GetAllCartMultiplier(selected);

            //    CurrentPrestige.Text = currentPrestige > 0 ? FormatNumber(currentPrestige) : null;
            //    CurrentFood.Text = currentFood > 0 ? FormatNumber(currentFood) : null;
            //    CurrentFoodCart.Text = currentFoodCart > 0 ? FormatNumber(currentFoodCart) : null;
            //    CurrentWood.Text = currentWood > 0 ? FormatNumber(currentWood) : null;
            //    CurrentWoodCart.Text = currentWoodCart > 0 ? FormatNumber(currentWoodCart) : null;
            //    CurrentScience.Text = currentScience > 0 ? FormatNumber(currentScience) : null;
            //    CurrentAllCart.Text = currentAllCart > 0 ? FormatNumber(currentAllCart) : null;
            //}

            //if (SavedRoutes.SelectedItem is SavedRoute selectedRoute)
            //{
            //    selectedRoute.Cells = SelectedCells.ToList();
            //}
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            //HexList.SelectedItems.Clear();

            //var selectedRoute = SavedRoutes.SelectedItem as SavedRoute;
            //if (selectedRoute == null) return;
            //selectedRoute.Cells = SelectedCells.ToList();
        }

        private void SavedRoutes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selectedRoute = SavedRoutes.SelectedItem as SavedRoute;
            //if (selectedRoute == null) return;

            //HexList.SelectedItems.Clear();

            //var hexCells = from hexItem in HexList.Items.Cast<UIElement>()
            //               join hexCell in selectedRoute.Cells on new { Row = Grid.GetRow(hexItem), Col = Grid.GetColumn(hexItem) } equals new { hexCell.Row, hexCell.Col }
            //               select hexItem;

            //foreach (var cell in hexCells)
            //{
            //    HexList.SelectedItems.Add(cell);
            //}

            //HeightTextBox.Text = selectedRoute.Height.ToString();
            //WidthTextBox.Text = selectedRoute.Width.ToString();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRoute = SavedRoutes.SelectedItem as SavedRoute;
            if (selectedRoute == null) return;

            _savedRoutes.Remove(selectedRoute);
            SavedRoutes.Items.Remove(selectedRoute);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var json = JsonConvert.SerializeObject(_savedRoutes);
            File.WriteAllText(Constants.SavedRoutesFilePath, json);
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(RouteName.Text)) return;

            //var savedRoute = new SavedRoute { Name = RouteName.Text, Cells = SelectedCells.ToList(), Height = hexGrid.Height, Width = hexGrid.Width };
            //_savedRoutes.Add(savedRoute);
            //SavedRoutes.Items.Add(savedRoute);
            //SavedRoutes.SelectedItem = savedRoute;
            //RouteName.Text = "";
        }

        //private IEnumerable<HexCell> SelectedCells => HexList.SelectedItems.Cast<UIElement>().Select(o => new HexCell { Row = Grid.GetRow(o), Col = Grid.GetColumn(o) });

    }
}
