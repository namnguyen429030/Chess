using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinform.Components
{
    internal class Player
    {
        public string Side { get; set; }
        public string Name { get; set; }
        public TimeSpan TimeLeft { get; set; }
        public List<Move> Moves = new List<Move>();
        public List<ChessPiece> GottenPieces = new List<ChessPiece>();
        public Player(string name)
        {
            this.Name = name;
        }
    }
}
