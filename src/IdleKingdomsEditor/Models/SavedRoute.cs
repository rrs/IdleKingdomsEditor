using IdleKingdomsEditor.DataObjects;
using System.Collections.Generic;

namespace IdleKingdomsEditor.Models
{
    public class SavedRoute
    {
        public string Name { get; set; }
        public List<HexCell> Cells { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
