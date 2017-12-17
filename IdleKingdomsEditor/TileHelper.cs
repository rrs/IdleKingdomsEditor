using System.Windows;

namespace IdleKingdomsEditor
{
    class TileHelper
    {
        public static readonly DependencyProperty TileTypeProperty = DependencyProperty.RegisterAttached("TileType", typeof(TileType), typeof(TileHelper));

        public static TileType GetTileType(DependencyObject obj)
        {
            return (TileType)obj.GetValue(TileTypeProperty);
        }

        public static void SetTileType(DependencyObject obj, TileType value)
        {
            obj.SetValue(TileTypeProperty, value);
        }

        public static readonly DependencyProperty PrestigeMultiplierProperty = DependencyProperty.RegisterAttached("PrestigeMultiplier", typeof(double), typeof(TileHelper));

        public static double GetPrestigeMultiplier(DependencyObject obj)
        {
            return (double)obj.GetValue(PrestigeMultiplierProperty);
        }

        public static void SetPrestigeMultiplier(DependencyObject obj, double value)
        {
            obj.SetValue(PrestigeMultiplierProperty, value);
        }
    }
}
