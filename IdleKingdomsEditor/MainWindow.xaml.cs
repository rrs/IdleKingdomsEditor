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

            foreach(var hexItem in HexList.SelectedItems)
            {
                total++;

                var o = (DependencyObject)hexItem;
                var type = TileHelper.GetTileType(o);
                if (type == TileType.Forest) forests++;
                var multiplier = TileHelper.GetPrestigeMultiplier(o);
                if (multiplier > 1) prestige *= multiplier;
            }

            SelectedInfo.Text = total.ToString();
            ForestInfo.Text = forests.ToString();
            PrestigeInfo.Text = prestige.ToString();
            
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
