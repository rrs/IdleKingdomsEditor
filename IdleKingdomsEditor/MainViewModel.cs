using IdleKingdomsEditor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace IdleKingdomsEditor
{
    /// <summary>
    /// Not yet in use
    /// </summary>
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _width;

        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        private double _height;

        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
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

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
