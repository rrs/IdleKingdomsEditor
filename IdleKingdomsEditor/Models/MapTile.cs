namespace IdleKingdomsEditor.Models
{
    class MapTile : NotifyPropertyChangedViewModel
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public TileType TileType { get; set; }
        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public override string ToString() => "";
    }
}
