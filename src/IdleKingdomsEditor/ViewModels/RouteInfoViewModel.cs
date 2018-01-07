using IdleKingdomsEditor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace IdleKingdomsEditor.ViewModels
{
    class RouteInfoViewModel : NotifyPropertyChangedViewModel
    {
        public void UpdateInfo(IEnumerable<MapTile> selectedMapTiles, string averageFoodPerSecondText)
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

            var tileCosts = TileCostHelper.Values(nSelected + 2);

            var nextTileCost = tileCosts[tileCosts.Count - 1];
            var totalTileCost = tileCosts.Sum() - nextTileCost;

            var prestigeOnReset = nSelected - 9 > 0 ? (nSelected - 9) * prestige : 0;

            NextTileCostText = (nSelected + 1 < TileCostHelper.KnownValues.Length ? "" : "~") + NumberFormatter.FormatNumber(nextTileCost);
            TileCostTotalText = (nSelected < TileCostHelper.KnownValues.Length ? "" : "~") + NumberFormatter.FormatNumber(totalTileCost);
            SelectedTilesText = nSelected.ToString();
            SelectedForestsText = forests.ToString();
            PrestigeMultiplierText = NumberFormatter.FormatNumber(prestige);
            PrestigeTotalText = NumberFormatter.FormatNumber(prestigeOnReset);
            FoodMultiplierText = NumberFormatter.FormatNumber(food);
            FoodCartMultiplierText = NumberFormatter.FormatNumber(foodCart);
            WoodMultiplierText = NumberFormatter.FormatNumber(wood);
            WoodCartMultiplierText = NumberFormatter.FormatNumber(woodCart);
            ScienceMultiplierText = NumberFormatter.FormatNumber(science);
            ScienceCartMultiplierText = NumberFormatter.FormatNumber(scienceCart);
            ForagingHutMultiplierText = NumberFormatter.FormatNumber(foragingHuts);

            var averageFoodPerSecond = NumberFormatter.UnformatNumber(averageFoodPerSecondText);

            var estimateTimeInSeconds = (totalTileCost / averageFoodPerSecond) / 2; // divide by 2 assumed always double production


            if (double.IsNaN(estimateTimeInSeconds) || estimateTimeInSeconds > 3153600000)
            {
                EstimatedTimeText = "\u221E"; // infinity
                PrestigePerSecondText = $"0";
            }
            else
            {
                var estimateTimeSpan = TimeSpan.FromSeconds(estimateTimeInSeconds);
                var hoursMinutesString = $"{estimateTimeSpan:hh\\:mm}";

                EstimatedTimeText = estimateTimeSpan.Days > 0 
                    ? $"{estimateTimeSpan.Days}:{hoursMinutesString} Days" 
                    : $"{hoursMinutesString} Hours";

                var prestigePerSecond = prestigeOnReset / estimateTimeInSeconds;
                PrestigePerSecondText = NumberFormatter.FormatNumber(prestigePerSecond);
            }

            
        }

        private string _selectedTilesText = "0";

        public string SelectedTilesText
        {
            get => _selectedTilesText;
            set
            {
                _selectedTilesText = value;
                OnPropertyChanged(nameof(SelectedTilesText));
            }
        }

        private string _selectedForestsText = "0";

        public string SelectedForestsText
        {
            get => _selectedForestsText;
            set
            {
                _selectedForestsText = value;
                OnPropertyChanged(nameof(SelectedForestsText));
            }
        }

        private string _nextTileCostText = "0";

        public string NextTileCostText
        {
            get => _nextTileCostText;
            set
            {
                _nextTileCostText = value;
                OnPropertyChanged(nameof(NextTileCostText));
            }
        }

        private string _tileCostTotalText = "0";

        public string TileCostTotalText
        {
            get => _tileCostTotalText;
            set
            {
                _tileCostTotalText = value;
                OnPropertyChanged(nameof(TileCostTotalText));
            }
        }

        private string _foodMultiplierText = "0";

        public string FoodMultiplierText
        {
            get => _foodMultiplierText;
            set
            {
                _foodMultiplierText = value;
                OnPropertyChanged(nameof(FoodMultiplierText));
            }
        }

        private string _foodCartMultiplierText = "0";

        public string FoodCartMultiplierText
        {
            get => _foodCartMultiplierText;
            set
            {
                _foodCartMultiplierText = value;
                OnPropertyChanged(nameof(FoodCartMultiplierText));
            }
        }

        private string _woodMultiplierText = "0";

        public string WoodMultiplierText
        {
            get => _woodMultiplierText;
            set
            {
                _woodMultiplierText = value;
                OnPropertyChanged(nameof(WoodMultiplierText));
            }
        }

        private string _woodCartMultiplierText = "0";

        public string WoodCartMultiplierText
        {
            get => _woodCartMultiplierText;
            set
            {
                _woodCartMultiplierText = value;
                OnPropertyChanged(nameof(WoodCartMultiplierText));
            }
        }

        private string _scienceMultiplierText = "0";

        public string ScienceMultiplierText
        {
            get => _scienceMultiplierText;
            set
            {
                _scienceMultiplierText = value;
                OnPropertyChanged(nameof(ScienceMultiplierText));
            }
        }

        private string _scienceCartMultiplierText = "0";

        public string ScienceCartMultiplierText
        {
            get => _scienceCartMultiplierText;
            set
            {
                _scienceCartMultiplierText = value;
                OnPropertyChanged(nameof(ScienceCartMultiplierText));
            }
        }

        private string _foragingHutMultiplierText = "0";

        public string ForagingHutMultiplierText
        {
            get => _foragingHutMultiplierText;
            set
            {
                _foragingHutMultiplierText = value;
                OnPropertyChanged(nameof(ForagingHutMultiplierText));
            }
        }

        private string _prestigeMultiplierText = "0";

        public string PrestigeMultiplierText
        {
            get => _prestigeMultiplierText;
            set
            {
                _prestigeMultiplierText = value;
                OnPropertyChanged(nameof(PrestigeMultiplierText));
            }
        }

        private string _prestigeTotalText = "0";

        public string PrestigeTotalText
        {
            get => _prestigeTotalText;
            set
            {
                _prestigeTotalText = value;
                OnPropertyChanged(nameof(PrestigeTotalText));
            }
        }

        private string _prestigePerSecondText = "0";

        public string PrestigePerSecondText
        {
            get => _prestigePerSecondText;
            set
            {
                _prestigePerSecondText = value;
                OnPropertyChanged(nameof(PrestigePerSecondText));
            }
        }

        private string _estimatedTimeText = "0";

        public string EstimatedTimeText
        {
            get => _estimatedTimeText;
            set
            {
                _estimatedTimeText = value;
                OnPropertyChanged(nameof(EstimatedTimeText));
            }
        }
    }
}
