using IdleKingdomsEditor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace IdleKingdomsEditor.ViewModels
{
    class InfoViewModel : INotifyPropertyChanged
    {
        public void UpdateInfo(IEnumerable<MapTile> selectedMapTiles)
        {
            int nSelected = 0;
            int forests = 0;
            double prestige = 1;
            double food = 1;
            double foodCart = 1;
            double wood = 1;
            double woodCart = 1;
            double science = 1;
            double scienceCart = 1;
            double foragingHuts = 1;

            foreach (var hexItem in selectedMapTiles)
            {
                nSelected++;

                if (hexItem.TileType == TileType.Forest) forests++;

                var shrine = hexItem as ShrineTile;

                if (shrine == null) continue;

                prestige *= shrine.PrestigeMultiplier;
                food *= shrine.FoodMultiplier;
                foodCart *= shrine.FoodCartMultiplier;
                wood *= shrine.WoodMultiplier;
                woodCart *= shrine.WoodCartMultiplier;
                science *= shrine.ScienceMultiplier;
                foragingHuts *= shrine.ForagingHutMultiplier;

                var aMultiplier = shrine.AllCartMultiplier;
                if (aMultiplier > 1)
                {
                    foodCart *= aMultiplier;
                    woodCart *= aMultiplier;
                    scienceCart *= aMultiplier;
                }
            }

            var tileCosts = TileCosts.Values(nSelected + 2);

            var nextTileCost = tileCosts[tileCosts.Count - 1];
            var totalTileCost = tileCosts.Sum() - nextTileCost;

            NextTileCostText = (nSelected + 1 < TileCosts.KnownValues.Length ? "" : "~") + NumberFormatter.FormatNumber(nextTileCost);
            TileCostTotalText = (nSelected < TileCosts.KnownValues.Length ? "" : "~") + NumberFormatter.FormatNumber(totalTileCost);
            SelectedTilesText = nSelected.ToString();
            SelectedForestsText = forests.ToString();
            PrestigeMultiplierText = NumberFormatter.FormatNumber(prestige);
            PrestigeTotalText = NumberFormatter.FormatNumber(nSelected - 9 > 0 ? (nSelected - 9) * prestige : 0);
            FoodMultiplierText = NumberFormatter.FormatNumber(food);
            FoodCartMultiplierText = NumberFormatter.FormatNumber(foodCart);
            WoodMultiplierText = NumberFormatter.FormatNumber(wood);
            WoodCartMultiplierText = NumberFormatter.FormatNumber(woodCart);
            ScienceMultiplierText = NumberFormatter.FormatNumber(science);
            ScienceCartMultiplierText = NumberFormatter.FormatNumber(scienceCart);
            ForagingHutMultiplierText = NumberFormatter.FormatNumber(foragingHuts);
        }

        private string _selectedTilesText;

        public string SelectedTilesText
        {
            get => _selectedTilesText;
            set
            {
                _selectedTilesText = value;
                OnPropertyChanged(nameof(SelectedTilesText));
            }
        }

        private string _selectedForestsText;

        public string SelectedForestsText
        {
            get => _selectedForestsText;
            set
            {
                _selectedForestsText = value;
                OnPropertyChanged(nameof(SelectedForestsText));
            }
        }

        private string _nextTileCostText;

        public string NextTileCostText
        {
            get => _nextTileCostText;
            set
            {
                _nextTileCostText = value;
                OnPropertyChanged(nameof(NextTileCostText));
            }
        }

        private string _tileCostTotalText;

        public string TileCostTotalText
        {
            get => _tileCostTotalText;
            set
            {
                _tileCostTotalText = value;
                OnPropertyChanged(nameof(TileCostTotalText));
            }
        }

        private string _foodMultiplierText;

        public string FoodMultiplierText
        {
            get => _foodMultiplierText;
            set
            {
                _foodMultiplierText = value;
                OnPropertyChanged(nameof(FoodMultiplierText));
            }
        }

        private string _foodCartMultiplierText;

        public string FoodCartMultiplierText
        {
            get => _foodCartMultiplierText;
            set
            {
                _foodCartMultiplierText = value;
                OnPropertyChanged(nameof(FoodCartMultiplierText));
            }
        }

        private string _woodMultiplierText;

        public string WoodMultiplierText
        {
            get => _woodMultiplierText;
            set
            {
                _woodMultiplierText = value;
                OnPropertyChanged(nameof(WoodMultiplierText));
            }
        }

        private string _woodCartMultiplierText;

        public string WoodCartMultiplierText
        {
            get => _woodCartMultiplierText;
            set
            {
                _woodCartMultiplierText = value;
                OnPropertyChanged(nameof(WoodCartMultiplierText));
            }
        }

        private string _scienceMultiplierText;

        public string ScienceMultiplierText
        {
            get => _scienceMultiplierText;
            set
            {
                _scienceMultiplierText = value;
                OnPropertyChanged(nameof(ScienceMultiplierText));
            }
        }

        private string _scienceCartMultiplierText;

        public string ScienceCartMultiplierText
        {
            get => _scienceCartMultiplierText;
            set
            {
                _scienceCartMultiplierText = value;
                OnPropertyChanged(nameof(ScienceCartMultiplierText));
            }
        }

        private string _foragingHutMultiplierText;

        public string ForagingHutMultiplierText
        {
            get => _foragingHutMultiplierText;
            set
            {
                _foragingHutMultiplierText = value;
                OnPropertyChanged(nameof(ForagingHutMultiplierText));
            }
        }

        private string _prestigeMultiplierText;

        public string PrestigeMultiplierText
        {
            get => _prestigeMultiplierText;
            set
            {
                _prestigeMultiplierText = value;
                OnPropertyChanged(nameof(PrestigeMultiplierText));
            }
        }

        private string _prestigeTotalText;

        public string PrestigeTotalText
        {
            get => _prestigeTotalText;
            set
            {
                _prestigeTotalText = value;
                OnPropertyChanged(nameof(PrestigeTotalText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
