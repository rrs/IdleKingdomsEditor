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

        public static readonly DependencyProperty FoodMultiplierProperty = DependencyProperty.RegisterAttached("FoodMultiplier", typeof(double), typeof(TileHelper));

        public static double GetFoodMultiplier(DependencyObject obj)
        {
            return (double)obj.GetValue(FoodMultiplierProperty);
        }

        public static void SetFoodMultiplier(DependencyObject obj, double value)
        {
            obj.SetValue(FoodMultiplierProperty, value);
        }

        public static readonly DependencyProperty FoodCartMultiplierProperty = DependencyProperty.RegisterAttached("FoodCartMultiplier", typeof(double), typeof(TileHelper));

        public static double GetFoodCartMultiplier(DependencyObject obj)
        {
            return (double)obj.GetValue(FoodCartMultiplierProperty);
        }

        public static void SetFoodCartMultiplier(DependencyObject obj, double value)
        {
            obj.SetValue(FoodCartMultiplierProperty, value);
        }

        public static readonly DependencyProperty AllCartMultiplierProperty = DependencyProperty.RegisterAttached("AllCartMultiplier", typeof(double), typeof(TileHelper));

        public static double GetAllCartMultiplier(DependencyObject obj)
        {
            return (double)obj.GetValue(AllCartMultiplierProperty);
        }

        public static void SetAllCartMultiplier(DependencyObject obj, double value)
        {
            obj.SetValue(AllCartMultiplierProperty, value);
        }

        public static readonly DependencyProperty WoodMultiplierProperty = DependencyProperty.RegisterAttached("WoodMultiplier", typeof(double), typeof(TileHelper));

        public static double GetWoodMultiplier(DependencyObject obj)
        {
            return (double)obj.GetValue(WoodMultiplierProperty);
        }

        public static void SetWoodMultiplier(DependencyObject obj, double value)
        {
            obj.SetValue(WoodMultiplierProperty, value);
        }

        public static readonly DependencyProperty WoodCartMultiplierProperty = DependencyProperty.RegisterAttached("WoodCartMultiplier", typeof(double), typeof(TileHelper));

        public static double GetWoodCartMultiplier(DependencyObject obj)
        {
            return (double)obj.GetValue(WoodCartMultiplierProperty);
        }

        public static void SetWoodCartMultiplier(DependencyObject obj, double value)
        {
            obj.SetValue(WoodCartMultiplierProperty, value);
        }

        public static readonly DependencyProperty ScienceMultiplierProperty = DependencyProperty.RegisterAttached("ScienceMultiplier", typeof(double), typeof(TileHelper));

        public static double GetScienceMultiplier(DependencyObject obj)
        {
            return (double)obj.GetValue(ScienceMultiplierProperty);
        }

        public static void SetScienceMultiplier(DependencyObject obj, double value)
        {
            obj.SetValue(ScienceMultiplierProperty, value);
        }

        public static readonly DependencyProperty ForagingHutMultiplierProperty = DependencyProperty.RegisterAttached("ForagingHutMultiplier", typeof(double), typeof(TileHelper));

        public static double GetForagingHutMultiplier(DependencyObject obj)
        {
            return (double)obj.GetValue(ForagingHutMultiplierProperty);
        }

        public static void SetForagingHutMultiplier(DependencyObject obj, double value)
        {
            obj.SetValue(ForagingHutMultiplierProperty, value);
        }
    }
}
