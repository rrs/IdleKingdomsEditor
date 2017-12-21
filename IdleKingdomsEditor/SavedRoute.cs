using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace IdleKingdomsEditor
{
    public class SavedRoute
    {
        public string Name { get; set; }
        public List<HexCell> Cells { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
