using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinform.Components
{
    internal class ChessPiece
    {
        public string Name { get; private set; } = null!;
        public Image Image { get; internal set; } = null!;
        public string Side { get; private set; } = null!;
        public string Type { get; private set; } = null!;
        public List<Tile> ValidMove = new List<Tile>();
        public bool CanMove { get; set; }
        public List<Tile> PreventCheckMove = new List<Tile>();
        public List<Tile> CheckedMove = new List<Tile>();
        public Tile CurrentTile { get; set; }
        public int LastMoveTurn { get; set; }
        public ChessPiece(string name, string side, string type, Tile tile)
        {
            this.Name = name;
            this.Side = side;
            this.Type = type;
            this.CurrentTile = tile;
            this.CanMove = false;
        }
        public virtual void FindValidTile(Board board)
        {
            this.ValidMove.Clear();
            this.CheckedMove.Clear();
            board.ClearTile();
        }

        public virtual void CheckedTile(Tile tile)
        {
            if (Side == "White")
            {
                tile.IsChecked["Black"] = true;
            }
            else
            {
                tile.IsChecked["White"] = true;
            }
        }
        public virtual Move Move(Board board, Tile selectedTile, Tile destinationTile, PictureBox piecePictureBox, PictureBox selectedPieceInterface, int index)
        {
            return new Move(index,selectedTile, destinationTile, selectedTile.Piece, destinationTile.Piece);
        }
        public virtual void CanPreventCheck(Board board, Tile currentTile, Tile destinationTile, string side)
        {
            ChessPiece tmpCurrent = currentTile.Piece;
            ChessPiece tmpDes = destinationTile.Piece;
            this.CurrentTile = destinationTile;
            destinationTile.Piece = currentTile.Piece;
            currentTile.Piece = null;
            this.ValidMove.Clear();
            foreach(Tile tile in board.Tiles)
            {
                if(tile.Piece != null)
                {
                    tile.Piece.FindValidTile(board);
                }
            }
            if(side == "White")
            {
                board.IsWhiteChecked();
                if (!board.WhiteKingChecked)
                {
                    tmpCurrent.PreventCheckMove.Add(destinationTile);
                }
            }
            else
            {
                board.IsBlackChecked();
                if (!board.BlackKingChecked)
                {
                    tmpCurrent.PreventCheckMove.Add(destinationTile);
                }
            }
            this.CurrentTile = currentTile;
            destinationTile.Piece = tmpDes;
            currentTile.Piece = tmpCurrent;
            this.ValidMove.Clear();
            FindValidTile(board);
        }
        public virtual bool CanLeadToChecked(Board board, Tile currentTile, Tile destinationTile, string side)
        {
            ChessPiece tmpCurrent = currentTile.Piece;
            ChessPiece tmpDes = destinationTile.Piece;
            bool isChecked = false;
            this.CurrentTile = destinationTile;
            destinationTile.Piece = currentTile.Piece;
            currentTile.Piece = null;
            this.ValidMove.Clear();
            foreach (Tile tile in board.Tiles)
            {
                if (tile.Piece != null)
                {
                    tile.Piece.FindValidTile(board);
                }
            }
            if (side == "White")
            {
                board.IsWhiteChecked();
                if (board.WhiteKingChecked)
                {
                    isChecked = true;
                }
            }
            else
            {
                board.IsBlackChecked();
                if (board.BlackKingChecked)
                {
                    isChecked = true;
                }
            }
            this.CurrentTile = currentTile;
            destinationTile.Piece = tmpDes;
            currentTile.Piece = tmpCurrent;
            this.ValidMove.Clear();
            FindValidTile(board);
            return isChecked;
        }
    }
}
