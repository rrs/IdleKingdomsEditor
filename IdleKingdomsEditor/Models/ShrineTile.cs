namespace IdleKingdomsEditor.Models
{
    class ShrineTile : MapTile
    {
        public double PrestigeMultiplier { get; set; } = 1;
        public double FoodMultiplier { get; set; } = 1;
        public double FoodCartMultiplier { get; set; } = 1;
        public double WoodMultiplier { get; set; } = 1;
        public double WoodCartMultiplier { get; set; } = 1;
        public double ScienceMultiplier { get; set; } = 1;
        public double AllCartMultiplier { get; set; } = 1;
        public double ForagingHutMultiplier { get; set; } = 1;
        public string Text { get; set; }

        public override string ToString() => Text;
    }
}
