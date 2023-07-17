using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinform.Components
{
    internal class Bishop : ChessPiece
    {
        public Bishop(string name, string side, string type, Tile tile) : base(name, side, type, tile) 
        {
            if (side == "White")
            {
                this.Image = Properties.Resources.white_bishop;
            }
            else
            {
                this.Image = Properties.Resources.black_bishop;
            }
        }
        public override void FindValidTile(Board board)
        {
            base.FindValidTile(board);
            int currentX = CurrentTile.X;
            int currentY = CurrentTile.Y;

            int i = currentX;
            int j = currentY;

            bool blocked = false;
            //Quarter 1 moves
            while (i < 7 && j < 7)
            {
                i++;
                j++;
                Tile tile = board.Tiles[i, j];
                if (tile.Piece != null && tile.Piece.Side == this.Side)
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    break;
                }
                if (tile.Piece != null && tile.Piece.Side != this.Side)
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                    if (tile.Piece.Type != "King")
                    {
                        break;
                    }
                    blocked = true;
                    continue;
                }
                CheckedMove.Add(tile);
                CheckedTile(tile);
                if (!blocked)
                {
                    ValidMove.Add(tile);
                }
            }
            i = currentX;
            j = currentY;
            blocked = false;
            //Quarter 2 moves
            while (i >= 1 && j < 7)
            {
                i--;
                j++;
                Tile tile = board.Tiles[i, j];
                if (tile.Piece != null && tile.Piece.Side == this.Side)
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    break;
                }
                if (tile.Piece != null && tile.Piece.Side != this.Side)
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                    if (tile.Piece.Type != "King")
                    {
                        break;
                    }
                    blocked = true;
                    continue;
                }
                CheckedMove.Add(tile);
                CheckedTile(tile);
                if (!blocked)
                {
                    ValidMove.Add(tile);
                }
            }
            i = currentX;
            j = currentY;
            blocked = false;
            //Quarter 3 moves
            while (i > 0 && j >= 1)
            {
                i--;
                j--;
                Tile tile = board.Tiles[i, j];
                if (tile.Piece != null && tile.Piece.Side == this.Side)
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    break;
                }
                if (tile.Piece != null && tile.Piece.Side != this.Side)
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                    if (tile.Piece.Type != "King")
                    {
                        break;
                    }
                    blocked = true;
                    continue;
                }
                CheckedMove.Add(tile);
                CheckedTile(tile);
                if (!blocked)
                {
                    ValidMove.Add(tile);
                }
            }
            i = currentX;
            j = currentY;
            blocked = false;
            //Quarter 4 moves
            while (i < 7 && j >= 1)
            {
                i++;
                j--;
                Tile tile = board.Tiles[i, j];
                if (tile.Piece != null && tile.Piece.Side == this.Side)
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    break;
                }
                if (tile.Piece != null && tile.Piece.Side != this.Side)
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                    if (tile.Piece.Type != "King")
                    {
                        break;
                    }
                    blocked = true;
                    continue;
                }
                CheckedMove.Add(tile);
                CheckedTile(tile);
                if (!blocked)
                {
                    ValidMove.Add(tile);
                }
            }
            foreach (Tile tile in CheckedMove)
            {
                tile.IsChecked[Side] = true;
            }
        }
        public override Move Move(Board board, Tile selectedTile, Tile destinationTile, PictureBox piecePictureBox, PictureBox selectedPieceInterface, int index)
        {
            Move move = new Move(index, selectedTile, destinationTile, selectedTile.Piece, destinationTile.Piece);
            destinationTile.Piece = selectedTile.Piece;
            destinationTile.Piece.CurrentTile = destinationTile;
            destinationTile.Piece.FindValidTile(board);
            piecePictureBox.Image = selectedTile.Piece.Image;
            selectedPieceInterface.Image = null;
            selectedTile.Piece = null;
            LastMoveTurn = index;
            return move;
        }
    }
}
