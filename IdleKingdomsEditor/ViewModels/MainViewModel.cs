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
    class MainViewModel : INotifyPropertyChanged
    {

        private double _width = 900;

        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
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
            }
        }

        private string _routeName;

        public string RouteName
        {
            get => _routeName;
            set
            {
                _routeName = value;
                OnPropertyChanged(nameof(RouteName));
            }
        }


        private MapTile _selectedTile;
        public MapTile SelectedTile
        {
            get => _selectedTile;
            set
            {
                _selectedTile = value;
                OnPropertyChanged(nameof(SelectedTile));
                UpdateInfo(Tiles.Where(o => o.IsSelected));
            }
        }


        private HexMap _hexMap;

        public int Diameter => _hexMap.Diameter;

        public IEnumerable<MapTile> Tiles { get; set; }

        public ICommand SaveRoutesCommand { get; }
        public ICommand ClearRouteCommand { get; }
        public ICommand NewRouteCommand { get; }
        public ICommand DeleteRouteCommand { get; }

        public MainViewModel()
        {
            SaveRoutesCommand = new RelayCommand(SaveRoutes);
            ClearRouteCommand = new RelayCommand(ClearRoute);
            NewRouteCommand = new RelayCommand(NewRoute);
            DeleteRouteCommand = new RelayCommand(DeleteRoute);

            _hexMap = MapHelper.Generate(19);
            Tiles = _hexMap.Tiles.SelectMany(row => row.Where(col => col != null)).ToList();
        }

        private void SaveRoutes(object obj)
        {
            throw new NotImplementedException();
        }

        private void ClearRoute(object obj)
        {
            throw new NotImplementedException();
        }

        private void NewRoute(object obj)
        {
            throw new NotImplementedException();
        }

        private void DeleteRoute(object obj)
        {
            throw new NotImplementedException();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
