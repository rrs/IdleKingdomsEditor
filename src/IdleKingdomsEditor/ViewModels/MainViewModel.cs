using IdleKingdomsEditor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IdleKingdomsEditor.ViewModels
{
    /// <summary>
    /// Not yet in use
    /// </summary>
    class MainViewModel : NotifyPropertyChangedViewModel
    {

        public RouteInfoViewModel RouteInfoViewModel { get; } = new RouteInfoViewModel();
        public SelectedTileInfoViewModel SelectedTileInfoViewModel { get; } = new SelectedTileInfoViewModel();
        public RouteManagementViewModel RouteManagementViewModel { get; private set; }

        private readonly HexMap _hexMap;

        public int Diameter => _hexMap.Diameter;

        public BindingList<MapTile> Tiles { get; set; }

        public MainViewModel(IEnumerable<SavedRoute> savedRoutes)
        {
            _hexMap = MapHelper.Generate(19);
            Tiles = new BindingList<MapTile>(_hexMap.Tiles.SelectMany(row => row.Where(col => col != null)).ToList());
            RouteManagementViewModel = new RouteManagementViewModel(Tiles, savedRoutes);
            RouteManagementViewModel.AverageFoodPerSecondChanged += RouteManagementViewModel_AverageFoodPerSecondChanged;
            Tiles.ListChanged += Tiles_ListChanged;
            UpdateRoute(0);
        }

        private void RouteManagementViewModel_AverageFoodPerSecondChanged()
        {
            RouteInfoViewModel.UpdateInfo(Tiles.Where(o => o.IsSelected), RouteManagementViewModel);

        }

        private void Tiles_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateRoute(e.NewIndex);
        }

        private void UpdateRoute(int newIndex)
        {
            RouteInfoViewModel.UpdateInfo(Tiles.Where(o => o.IsSelected), RouteManagementViewModel);
            SelectedTileInfoViewModel.ChangeSelectedInfo(Tiles[newIndex]);
            RouteManagementViewModel.UpdateCurrentSavedRoute();
        }
    }
}
