using IdleKingdomsEditor.DataObjects;
using IdleKingdomsEditor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IdleKingdomsEditor.ViewModels
{
    class RouteManagementViewModel : NotifyPropertyChangedViewModel
    {
        private readonly IList<MapTile> _mapTiles;

        private double _width = 900;

        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
                if (SelectedRoute != null) SelectedRoute.Width = value;
            }
        }

        private double _height = 900;

        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
                if (SelectedRoute != null) SelectedRoute.Height = value;
            }
        }

        private string _newRouteName;

        public string NewRouteName
        {
            get => _newRouteName;
            set
            {
                _newRouteName = value;
                OnPropertyChanged(nameof(NewRouteName));
            }
        }

        public ObservableCollection<SavedRoute> SavedRoutes { get; set; }

        private SavedRoute _selectedRoute;

        public SavedRoute SelectedRoute
        {
            get => _selectedRoute;
            set
            {
                _selectedRoute = value;
                OnPropertyChanged(nameof(SelectedRoute));
                ChangeRoute();
            }
        }

        private void ChangeRoute()
        {
            if (SelectedRoute == null) return;

            Height = SelectedRoute.Height;
            Width = SelectedRoute.Width;

            var tilesToSelect = from hexItem in _mapTiles
                           join hexCell in SelectedRoute.Cells on new { hexItem.Row, hexItem.Col } equals new { hexCell.Row, hexCell.Col }
                           select hexItem;

            var tilesToDeselect = _mapTiles.Except(tilesToSelect);

            foreach (var tile in tilesToSelect) tile.IsSelected = true;
            foreach (var tile in tilesToDeselect) tile.IsSelected = false;
        }

        public ICommand SaveRoutesCommand { get; }
        public ICommand ClearRouteCommand { get; }
        public ICommand NewRouteCommand { get; }
        public ICommand DeleteRouteCommand { get; }

        public RouteManagementViewModel()
        {
            SaveRoutesCommand = new RelayCommand(SaveRoutes);
            ClearRouteCommand = new RelayCommand(ClearRoute, o => _mapTiles?.Any(t => t.IsSelected) ?? false);
            NewRouteCommand = new RelayCommand(NewRoute, o => !string.IsNullOrEmpty(NewRouteName));
            DeleteRouteCommand = new RelayCommand(DeleteRoute, o => SelectedRoute != null);
        }

        public RouteManagementViewModel(IList<MapTile> mapTiles, IEnumerable<SavedRoute> savedRoutes) : this()
        {
            _mapTiles = mapTiles;
            SavedRoutes = new ObservableCollection<SavedRoute>(savedRoutes);
            if (savedRoutes.Any()) SelectedRoute = savedRoutes.First();
        }

        public void UpdateCurrentSavedRoute()
        {
            if (SelectedRoute == null) return;
            SelectedRoute.Cells = SelectedCells.ToList();
        }

        private void SaveRoutes(object obj)
        {
            var json = JsonConvert.SerializeObject(SavedRoutes);
            File.WriteAllText(Constants.SavedRoutesFilePath, json);
        }

        private void ClearRoute(object obj)
        {
            foreach (var t in _mapTiles) t.IsSelected = false;
        }

        private void NewRoute(object obj)
        {
            var savedRoute = new SavedRoute
            {
                Name = NewRouteName,
                Cells = SelectedCells.ToList(),
                Height = Height,
                Width = Width
            };

            SavedRoutes.Add(savedRoute);
            SelectedRoute = savedRoute;
            NewRouteName = "";
        }

        private void DeleteRoute(object obj)
        {
            SavedRoutes.Remove(SelectedRoute);
        }

        private IEnumerable<HexCell> SelectedCells => _mapTiles.Where(o => o.IsSelected).Select(o => new HexCell { Row = o.Row, Col = o.Col });
    }
}
