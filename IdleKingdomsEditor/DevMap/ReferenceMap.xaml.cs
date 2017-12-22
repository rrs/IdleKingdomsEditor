using HexGridControl;
using IdleKingdomsEditor.DataObjects;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace IdleKingdomsEditor
{
    /// <summary>
    /// used to help me generate known tiles
    /// </summary>
    public partial class ReferenceMap : UserControl
    {
        public ReferenceMap()
        {
            InitializeComponent();
        }

        internal IEnumerable<HexCell> CellsOfType(TileType t) => HexList.Items.Cast<HexItem>().Where(o => TileHelper.GetTileType(o) == t).Select(o => new HexCell { Row = Grid.GetRow(o), Col = Grid.GetColumn(o) });

        private string HexCellsOfType(TileType t) => string.Join(",\n", CellsOfType(t).Select(o => $"new HexCell {{ Row = {o.Row},Col = {o.Col} }}"));


        internal string Forests() => $@"
        public static readonly HexCell[] Forests =
        {{
            {HexCellsOfType(TileType.Forest)}
        }}
";

        internal string Water() => $@"
        public static readonly HexCell[] Water =
        {{
            {HexCellsOfType(TileType.Forest)}
        }}
";

        internal string Mountains() => $@"
        public static readonly HexCell[] Mountains =
        {{
            {HexCellsOfType(TileType.Forest)}
        }}
";
        internal string Sand() => $@"
        public static readonly HexCell[] Sand =
        {{
            {HexCellsOfType(TileType.Forest)}
        }}
";

        private IEnumerable<ShrineCell> ShrineCells() => HexList.Items.Cast<HexItem>().Where(o => TileHelper.GetTileType(o) == TileType.Shrine).Select(o => new ShrineCell { Row = Grid.GetRow(o), Col = Grid.GetColumn(o), Content = (o.Content as TextBlock)?.Text, PrestigeMultiplier = TileHelper.GetPrestigeMultiplier(o), FoodMultiplier = TileHelper.GetFoodMultiplier(o), FoodCartMultiplier = TileHelper.GetFoodCartMultiplier(o), WoodMultiplier = TileHelper.GetWoodMultiplier(o), WoodCartMultiplier = TileHelper.GetWoodCartMultiplier(o), ScienceMultiplier = TileHelper.GetScienceMultiplier(o), AllCartMultiplier = TileHelper.GetAllCartMultiplier(o), ForagingHutMultiplier = TileHelper.GetForagingHutMultiplier(o) });

        private string ShrineTiles() => string.Join(",\n", ShrineCells().Select(o => $"new ShrineCell {{ Row = {o.Row}, Col = {o.Col}, Content = {o.Content}{(o.PrestigeMultiplier > 0 ? $", PrestigeMultiplier = {o.PrestigeMultiplier}" : "")}{(o.FoodMultiplier > 0 ? $", FoodMultiplier = {o.FoodMultiplier}" : "")}{(o.FoodCartMultiplier > 0 ? $", FoodCartMultiplier = {o.FoodCartMultiplier}" : "")}{(o.WoodMultiplier > 0 ? $", WoodMultiplier = {o.WoodMultiplier}" : "")}{(o.WoodCartMultiplier > 0 ? $", WoodCartMultiplier = {o.WoodCartMultiplier}" : "")}{(o.ScienceMultiplier > 0 ? $", ScienceMultiplier = {o.ScienceMultiplier}" : "")}{(o.AllCartMultiplier > 0 ? $", AllCartMultiplier = {o.AllCartMultiplier}" : "")}{(o.ForagingHutMultiplier > 0 ? $", ForagingHutMultiplier = {o.ForagingHutMultiplier}" : "")} }}"));

        internal string Shrines() => $@"
        public static readonly ShrineCell[] Shrines =
        {{
            {ShrineTiles()}
        }}
";
    }
}
