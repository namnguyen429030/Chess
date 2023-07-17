using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinform.Components
{
    internal class Knight : ChessPiece
    {
        public Knight(string name, string side, string type, Tile tile) : base(name, side, type, tile)
        {
            if (side == "White")
            {
                this.Image = Properties.Resources.white_knight;
            }
            else
            {
                this.Image = Properties.Resources.black_knight;
            }
        }
        public override void FindValidTile(Board board)
        {
            base.FindValidTile(board);
            int currentX = CurrentTile.X;
            int currentY = CurrentTile.Y;

            //Quarter 1 moves
            if (currentY < 6)
            {
                if (currentX < 7)
                {
                    Tile q1Tile = board.Tiles[currentX + 1, currentY + 2];
                    if ((q1Tile.Piece != null && q1Tile.Piece.Side != Side) || (q1Tile.Piece == null))
                    {
                        CheckedMove.Add(q1Tile);
                        CheckedTile(q1Tile);
                        ValidMove.Add(q1Tile);
                    }
                }
                if (currentX > 0) 
                { 
                    Tile q2Tile = board.Tiles[currentX - 1, currentY + 2];

                    if ((q2Tile.Piece != null && q2Tile.Piece.Side != Side) || (q2Tile.Piece == null))
                    {
                        CheckedMove.Add(q2Tile);
                        CheckedTile(q2Tile); 
                        ValidMove.Add(q2Tile);
                    }
                }
            }
            //Quarter 2 moves
            if (currentX < 6)
            {
                if (currentY < 7)
                {
                    Tile q1Tile = board.Tiles[currentX + 2, currentY + 1];
                    if (q1Tile.Piece != null && q1Tile.Piece.Side != Side || (q1Tile.Piece == null))
                    {
                        CheckedMove.Add(q1Tile);
                        CheckedTile(q1Tile);
                        ValidMove.Add(q1Tile);
                    }
                }
                if (currentY > 0)
                {
                    Tile q2Tile = board.Tiles[currentX + 2, currentY - 1];
                    if (q2Tile.Piece != null && q2Tile.Piece.Side != Side || (q2Tile.Piece == null))
                    {
                        CheckedMove.Add(q2Tile);
                        CheckedTile(q2Tile);
                        ValidMove.Add(q2Tile);
                    }
                }
            }
            //Quarter 3 moves
            if (currentY > 1) 
            {
                if (currentX < 7)
                {
                    Tile q1Tile = board.Tiles[currentX + 1, currentY - 2];

                    if (q1Tile.Piece != null && q1Tile.Piece.Side != Side || (q1Tile.Piece == null))
                    {
                        CheckedMove.Add(q1Tile);
                        CheckedTile(q1Tile);
                        ValidMove.Add(q1Tile);
                    }
                }
                if (currentX > 0)
                {
                    Tile q2Tile = board.Tiles[currentX - 1, currentY - 2];
                    if (q2Tile.Piece != null && q2Tile.Piece.Side != Side || (q2Tile.Piece == null))
                    {
                        CheckedMove.Add(q2Tile);
                        CheckedTile(q2Tile);
                        ValidMove.Add(q2Tile);
                    }
                }
            }
            //Quarter 4 moves
            if (currentX > 1) 
            {
                if (currentY < 7)
                {
                    Tile q1Tile = board.Tiles[currentX - 2, currentY + 1];
                    if (q1Tile.Piece != null && q1Tile.Piece.Side != Side || (q1Tile.Piece == null))
                    {
                        CheckedMove.Add(q1Tile);
                        CheckedTile(q1Tile);
                        ValidMove.Add(q1Tile);
                    }
                }
                if (currentY > 0)
                {
                    Tile q2Tile = board.Tiles[currentX - 2, currentY - 1];
                    if (q2Tile.Piece != null && q2Tile.Piece.Side != Side || (q2Tile.Piece == null))
                    {
                        CheckedMove.Add(q2Tile);
                        CheckedTile(q2Tile);
                        ValidMove.Add(q2Tile);
                    }
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
