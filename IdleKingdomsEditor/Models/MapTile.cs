namespace IdleKingdomsEditor.Models
{
    class MapTile
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public TileType TileType { get; set; }
        //public virtual string Text { get; set; }
        public bool IsSelected { get; set; }
        public override string ToString() => "";
    }
}
