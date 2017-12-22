using System;

namespace IdleKingdomsEditor.Models
{
    class HexMap
    {
        public int Radius { get; }
        public int Diameter => Radius * 2 + 1;

        public MapTile[][] Tiles { get; }

        private HexMap(int r, MapTile[][] tiles)
        {
            Radius = r;
            Tiles = tiles;
        }

        public static HexMap Create(int radius)
        {
            var diameter = radius * 2 + 1;
            var tiles = new MapTile[diameter][];

            for (var j = 0; j < diameter; ++j)
            {
                var row = new MapTile[diameter];
                var shift = Math.Abs(radius - j) / 2.0;

                var front = (int)Math.Ceiling(shift);
                var back = diameter - (int)Math.Floor(shift);
                for (var i = front; i < back; ++i)
                {
                    row[i] = new MapTile { Row = j, Col = i, TileType = TileType.Grass };
                }
                tiles[j] = row;
            }

            return new HexMap(radius, tiles);
        }
    }
}
