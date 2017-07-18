using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ÄlytaUusi {
    public class ColorPickUp {

        public Color colorBursh(byte r, byte g, byte b) {
            Color pickedColor = new Color();
            pickedColor = Color.FromRgb(r, g, b);
            return pickedColor;
        }
    }
}
