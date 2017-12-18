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

            foreach(var hexItem in HexList.SelectedItems)
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
            PrestigeInfo.Text = $"{prestige:N}";
            FoodInfo.Text = $"{food:N}";
            FoodCartInfo.Text = $"{foodCart:N}";
            WoodInfo.Text = $"{wood:N}";
            WoodCartInfo.Text = $"{woodCart:N}";
            ScienceInfo.Text = $"{science:N}";
            ScienceCartInfo.Text = $"{scienceCart:N}";
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
    }
}
