using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinform.Components
{
    internal class Move
    {
        public int Index { get; set; }
        public Tile Location { get; set; }
        public Tile Destination { get; set; }
        public ChessPiece MovedPiece { get; set; }
        public ChessPiece? OccupiedPiece { get; set; }
        public Move(int Index, Tile Location, Tile Destionation, ChessPiece MovedPiece, ChessPiece? OccupiedPiece) {
            this.Index = Index;
            this.Location = Location;
            this.Destination = Destionation;
            this.MovedPiece = MovedPiece;
            this.OccupiedPiece = OccupiedPiece;
        }
        public override string ToString()
        {
            if(OccupiedPiece!=null) return Index+". "+MovedPiece.Type + Location.Name + "->" + OccupiedPiece.Type + Destination.Name+"\n";
            return Index + ". " + MovedPiece.Type + Location.Name + "->" + Destination.Name+"\n";
        }
    }
}
