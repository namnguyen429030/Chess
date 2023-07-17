using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinform.Components
{
    [Serializable]
    internal class History
    {
        public DateTime Time {  get; set; }
        public Player Player1 { get; set; }
        public Player PLayer2 { get; set; }
        public List<Move> Moves = new List<Move>();
        public TimeSpan Duration {  get; set; }
        public History(DateTime time, Player player1, Player player2) 
        {
            this.Time = time;
            this.Player1 = player1;
            this.PLayer2 = player2;
        }
        public override string ToString()
        {
            string moves = "";
            foreach (Move move in Moves)
            {
                moves += move.ToString();
            }
            return moves;
        }
    }
}
