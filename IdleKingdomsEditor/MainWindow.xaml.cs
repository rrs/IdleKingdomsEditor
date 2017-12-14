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
            Info.Text = HexList.SelectedItems.Count.ToString();
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
