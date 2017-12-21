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

        public MainWindow(List<SavedRoute> savedRoutes)
        {
            InitializeComponent();
            _savedRoutes = savedRoutes;
            foreach(var route in savedRoutes)
            {
                SavedRoutes.Items.Add(route);
            }
            if (savedRoutes.Any())
            {
                SavedRoutes.SelectedItem = savedRoutes.First();
            }
        }

        private void HexList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int nSelected = 0;
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
                nSelected++;

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

            var tileCosts = Enumerable.Range(0, nSelected + 2).Select(o => o < _tilesCosts.Length ? _tilesCosts[o] : _tilesCosts[_tilesCosts.Length - 1] * Math.Pow(1.72, o - _tilesCosts.Length + 1)).ToList();

            var nextTileCost = tileCosts[tileCosts.Count - 1];
            var totalTileCost = tileCosts.Sum() - nextTileCost;

            TileCost.Text = (nSelected + 1 < _tilesCosts.Length ? "" : "~") + FormatNumber(nextTileCost);
            TileCostTotal.Text = (nSelected < _tilesCosts.Length ? "" : "~") + FormatNumber(totalTileCost);
            SelectedInfo.Text = nSelected.ToString();
            ForestInfo.Text = forests.ToString();
            PrestigeMultiplier.Text = FormatNumber(prestige);
            PrestigeInfo.Text = FormatNumber(nSelected - 9 > 0 ? (nSelected - 9) * prestige : 0);
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

            var selectedRoute = SavedRoutes.SelectedItem as SavedRoute;
            if (selectedRoute == null) return;
            selectedRoute.Cells = SelectedCells;
        }

        private string FormatNumber(double n)
        {
            int index = 0;

            while (n > 1000)
            {
                n /= 1000;
                index++;
            }

            return $"{n:###.##}{_numberSuffixes[index]}";
        }

        private void WidthTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (hexGrid == null) return;
            if (double.TryParse(WidthTextBox.Text, out var width))
            {
                hexGrid.Width = width;
            }

            var selectedRoute = SavedRoutes.SelectedItem as SavedRoute;
            if (selectedRoute == null) return;
            selectedRoute.Width = width;
        }

        private void HeightTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (hexGrid == null) return;
            if (double.TryParse(HeightTextBox.Text, out var height))
            {
                hexGrid.Height = height;
            }

            var selectedRoute = SavedRoutes.SelectedItem as SavedRoute;
            if (selectedRoute == null) return;
            selectedRoute.Height = height;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            HexList.SelectedItems.Clear();
        }

        private void SavedRoutes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRoute = SavedRoutes.SelectedItem as SavedRoute;
            if (selectedRoute == null) return;

            HexList.SelectedItems.Clear();

            hexGrid.Width = selectedRoute.Width;
            hexGrid.Height = selectedRoute.Height;

            var hexCells = from hexItem in HexList.Items.Cast<UIElement>()
                           join hexCell in selectedRoute.Cells on new { Row = Grid.GetRow(hexItem), Col = Grid.GetColumn(hexItem) } equals new { hexCell.Row, hexCell.Col }
                           select hexItem;


            foreach (var cell in hexCells)
            {
                HexList.SelectedItems.Add(cell);
            }
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
            if (string.IsNullOrWhiteSpace(RouteName.Text)) return;

            var savedRoute = new SavedRoute { Name = RouteName.Text, Cells = SelectedCells, Height = hexGrid.Height, Width = hexGrid.Width };
            _savedRoutes.Add(savedRoute);
            SavedRoutes.Items.Add(savedRoute);
            SavedRoutes.SelectedItem = savedRoute;
            RouteName.Text = "";
        }

        private List<HexCell> SelectedCells => HexList.SelectedItems.Cast<UIElement>().Select(o => new HexCell { Row = Grid.GetRow(o), Col = Grid.GetColumn(o) }).ToList();

        static readonly string[] _numberSuffixes =
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

        static readonly double[] _tilesCosts =
        {
            0,
            0,
            1,
            94,
            165,
            372,
            2_980,
            4_890,
            8_110,
            14_230,
            19_230,
            25_230,
            65_800,
            121_190,
            221_860,
            404_110,
            732_780,
            1_320_00,
            2_380_000,
            4_280_000,
            7_650_000,
            13_660_000,
            24_320_000,
            43_220_000,
            76_680_000,
            135_780_000,
            240_040_000,
            423_800_000,
            747_140_000,
            1_320_000_000,
            2_310_000_000,
            4_060_000_000,
            7_130_000_000,
            12_500_000_000,
            21_900_000_000,
            38_320_000_000,
            67_010_000_000,
            117_080_000_000,
            204_420_000_000,
            356_650_000_000,
            621_850_000_000,
            1_080_000_000_000,
            1_890_000_000_000,
            3_280_000_000_000,
            5_710_000_000_000,
            9_930_000_000_000,
            17_620_000_000_000,
            28_980_000_000_000,
            52_050_000_000_000,
            90_340_000_000_000,
            156_710_000_000_000,
            271_730_000_000_000,
            471_000_000_000_000,
            816_090_000_000_000,
            1_410_000_000_000_000,
            2_450_000_000_000_000,
            4_240_000_000_000_000,
            7_330_000_000_000_000,
            12_680_000_000_000_000,
            21_930_000_000_000_000,
            37_910_000_000_000_000,
            65_520_000_000_000_000,
            113_210_000_000_000_000,
            195_570_000_000_000_000,
            337_740_000_000_000_000,
            583_130_000_000_000_000,
            1_010_000_000_000_000_000,
            1_740_000_000_000_000_000,
            3_000_000_000_000_000_000,
            5_170_000_000_000_000_000,
            8_920_000_000_000_000_000,
            15_370_000_000_000_000_000,
            26_500_000_000_000_000_000d,
            45_680_000_000_000_000_000d,
            78_730_000_000_000_000_000d,
            135_640_000_000_000_000_000d,
            233_670_000_000_000_000_000d,
            402_470_000_000_000_000_000d,
            693_080_000_000_000_000_000d,
            1_190_000_000_000_000_000_000d,
            2_050_000_000_000_000_000_000d,
            3_540_000_000_000_000_000_000d,
            6_090_000_000_000_000_000_000d,
            10_470_000_000_000_000_000_000d,
            18_020_000_000_000_000_000_000d,
            30_990_000_000_000_000_000_000d,
            53_310_000_000_000_000_000_000d,
            91_670_000_000_000_000_000_000d,
            157_640_000_000_000_000_000_000d,
            271_030_000_000_000_000_000_000d,
            465_930_000_000_000_000_000_000d,
            800_880_000_000_000_000_000_000d,
        };

    }
}
