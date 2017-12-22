namespace IdleKingdomsEditor.Models
{
    class ShrineTile : MapTile
    {
        public double PrestigeMultiplier { get; set; }
        public double FoodMultiplier { get; set; }
        public double FoodCartMultiplier { get; set; }
        public double WoodMultiplier { get; set; }
        public double WoodCartMultiplier { get; set; }
        public double ScienceMultiplier { get; set; }
        public double AllCartMultiplier { get; set; }
        public double ForagingHutMultiplier { get; set; }
        public string Text { get; set; }

        public override string ToString() => Text;
    }
}
