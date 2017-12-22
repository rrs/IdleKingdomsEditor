using IdleKingdomsEditor.DataObjects;
using IdleKingdomsEditor.Models;

namespace IdleKingdomsEditor
{
    static class MapHelper
    {
        public static HexMap Generate(int radius)
        {
            var hexMap = HexMap.Create(radius);

            foreach (var cell in KnownCoordinates.Forests())
            {
                hexMap.Tiles[cell.Row][cell.Col].TileType = TileType.Forest;
            }

            foreach (var cell in KnownCoordinates.Water())
            {
                hexMap.Tiles[cell.Row][cell.Col].TileType = TileType.Water;
            }

            foreach (var cell in KnownCoordinates.Sand())
            {
                hexMap.Tiles[cell.Row][cell.Col].TileType = TileType.Sand;
            }

            foreach (var cell in KnownCoordinates.Mountains())
            {
                hexMap.Tiles[cell.Row][cell.Col].TileType = TileType.Mountain;
            }

            foreach (var cell in KnownCoordinates.Shrines())
            {
                hexMap.Tiles[cell.Row][cell.Col] = new ShrineTile
                {
                    Col = cell.Col,
                    Row = cell.Row,
                    TileType = TileType.Shrine,
                    PrestigeMultiplier = cell.PrestigeMultiplier,
                    FoodMultiplier = cell.FoodMultiplier,
                    FoodCartMultiplier = cell.FoodCartMultiplier,
                    WoodMultiplier = cell.WoodMultiplier,
                    WoodCartMultiplier = cell.WoodCartMultiplier,
                    AllCartMultiplier = cell.AllCartMultiplier,
                    ScienceMultiplier = cell.ScienceMultiplier,
                    ForagingHutMultiplier = cell.ForagingHutMultiplier,
                    Text = GenerateShrineText(cell)
                };
            }

            return hexMap;
        }

        private static string GenerateShrineText(ShrineCell shrine)
        {
            if (!string.IsNullOrEmpty(shrine.Content)) return shrine.Content;

            var p = $"{(shrine.PrestigeMultiplier > 0 ? $"P{shrine.PrestigeMultiplier}" : "")}";
            var f = $"{(shrine.FoodMultiplier > 0 ? $"F{shrine.FoodMultiplier}" : "")}";
            var fc = $"{(shrine.FoodCartMultiplier > 0 ? $"FC{shrine.FoodCartMultiplier}" : "")}";
            var w = $"{(shrine.WoodMultiplier > 0 ? $"W{shrine.WoodMultiplier}" : "")}";
            var wc = $"{(shrine.WoodCartMultiplier > 0 ? $"WC{shrine.WoodCartMultiplier}" : "")}";
            var s = $"{(shrine.ScienceMultiplier > 0 ? $"S{shrine.ScienceMultiplier}" : "")}";
            var ac = $"{(shrine.AllCartMultiplier > 0 ? $"AC{shrine.AllCartMultiplier}" : "")}";
            var fh = $"{(shrine.ForagingHutMultiplier > 0 ? $"FH{shrine.ForagingHutMultiplier}" : "")}";

            var mods = new[] { p, f, fc, w, wc, s, ac, fh };

            var lines = "";

            var line = "";
            foreach (var mod in mods)
            {
                if (mod == "") continue;
                if (line.Length + mod.Length > 4)
                {
                    lines += line + "\n";
                    line = mod;
                }
                else
                {
                    line += mod;
                }
            }
            lines += line;
            return lines;
        }
    }
}
