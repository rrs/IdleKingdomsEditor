using IdleKingdomsEditor.Models;

namespace IdleKingdomsEditor.ViewModels
{
    class SelectedTileInfoViewModel : NotifyPropertyChangedViewModel
    {
        public void ChangeSelectedInfo(MapTile tile)
        {
            var shrine = tile as ShrineTile;
            if (tile.IsSelected == false || shrine == null)
            {
                PrestigeMultiplier = 0;
                FoodMultiplier = 0;
                FoodCartMultiplier = 0;
                WoodMultiplier = 0;
                WoodCartMultiplier = 0;
                ScienceMultiplier = 0;
                ForagingHutMultiplier = 0;
                AllCartsMultiplier = 0;
            }
            else
            {
                PrestigeMultiplier = shrine.PrestigeMultiplier;
                FoodMultiplier = shrine.FoodMultiplier;
                FoodCartMultiplier = shrine.FoodCartMultiplier;
                WoodMultiplier = shrine.WoodMultiplier;
                WoodCartMultiplier = shrine.WoodCartMultiplier;
                ScienceMultiplier = shrine.ScienceMultiplier;
                ForagingHutMultiplier = shrine.ForagingHutMultiplier;
                AllCartsMultiplier = shrine.AllCartMultiplier;
            }
        }

        public bool ShowPrestigeMultiplier => PrestigeMultiplier > 1;
        public bool ShowFoodMultiplier => FoodMultiplier > 1;
        public bool ShowFoodCartMultiplier => FoodCartMultiplier > 1;
        public bool ShowWoodMultiplier => WoodMultiplier > 1;
        public bool ShowWoodCartMultiplier => WoodCartMultiplier > 1;
        public bool ShowScienceMultiplier => ScienceMultiplier > 1;
        public bool ShowForagingHutMultiplier => ForagingHutMultiplier > 1;
        public bool ShowAllCartsMultiplier => AllCartsMultiplier  > 1;

        private double _prestigeMultiplier;

        public double PrestigeMultiplier
        {
            get => _prestigeMultiplier;
            set
            {
                _prestigeMultiplier = value;
                OnPropertyChanged(nameof(PrestigeMultiplier));
                OnPropertyChanged(nameof(ShowPrestigeMultiplier));
            }
        }

        private double _foodMultiplier;

        public double FoodMultiplier
        {
            get => _foodMultiplier;
            set
            {
                _foodMultiplier = value;
                OnPropertyChanged(nameof(FoodMultiplier));
                OnPropertyChanged(nameof(ShowFoodMultiplier));
            }
        }

        private double _foodCartMultiplier;

        public double FoodCartMultiplier
        {
            get => _foodCartMultiplier;
            set
            {
                _foodCartMultiplier = value;
                OnPropertyChanged(nameof(FoodCartMultiplier));
                OnPropertyChanged(nameof(ShowFoodCartMultiplier));
            }
        }

        private double _woodMultiplier;

        public double WoodMultiplier
        {
            get => _woodMultiplier;
            set
            {
                _woodMultiplier = value;
                OnPropertyChanged(nameof(WoodMultiplier));
                OnPropertyChanged(nameof(ShowWoodMultiplier));
            }
        }

        private double _woodCartMultiplier;

        public double WoodCartMultiplier
        {
            get => _woodCartMultiplier;
            set
            {
                _woodCartMultiplier = value;
                OnPropertyChanged(nameof(WoodCartMultiplier));
                OnPropertyChanged(nameof(ShowWoodCartMultiplier));
            }
        }

        private double _scienceMultiplier;

        public double ScienceMultiplier
        {
            get => _scienceMultiplier;
            set
            {
                _scienceMultiplier = value;
                OnPropertyChanged(nameof(ScienceMultiplier));
                OnPropertyChanged(nameof(ShowScienceMultiplier));
            }
        }

        private double _foragingHutMultiplier;

        public double ForagingHutMultiplier
        {
            get => _foragingHutMultiplier;
            set
            {
                _foragingHutMultiplier = value;
                OnPropertyChanged(nameof(ForagingHutMultiplier));
                OnPropertyChanged(nameof(ShowForagingHutMultiplier));
            }
        }

        private double _allCartsMultiplier;

        public double AllCartsMultiplier
        {
            get => _allCartsMultiplier;
            set
            {
                _allCartsMultiplier = value;
                OnPropertyChanged(nameof(AllCartsMultiplier));
                OnPropertyChanged(nameof(ShowAllCartsMultiplier));
            }
        }
    }
}
