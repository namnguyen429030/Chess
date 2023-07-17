using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinform.Components
{
    internal class Tile
    {
        public int X {  get; private set; }
        public int Y { get; private set; }
        public string Name { get; private set; }
        public ChessPiece? Piece {  get; set; }
        public string Color { get; private set; } = null!;
        public Image Image { get; private set; } = null!;
        public Dictionary<string, bool> IsChecked = new Dictionary<string, bool>();

        public Tile(int x, int y, string Name, string color, Image image)
        {
            this.X = x; 
            this.Y = y; 
            this.Name = Name;
            this.Color = color; 
            this.Image = image;
        }
    }
}
