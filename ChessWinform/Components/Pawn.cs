using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinform.Components
{
    internal class Pawn : ChessPiece
    {
        public bool CanEnPassantLeft { get; set; }
        public bool CanEnPassantRight { get; set; }
        public bool CanSprint { get; set; }
        public Tile StartTile { get; set; }
        public int MovedTurn = 0;
        public bool CanEnPassantAnyMore { get; set; }
        public Pawn(string name, string side, string type, Tile tile) : base(name, side, type, tile)
        {
            if(side == "White")
            {
                this.Image = Properties.Resources.white_pawn;
            }
            else
            {
                this.Image = Properties.Resources.black_pawn;
            }
            this.CanEnPassantLeft = false;
            this.CanEnPassantRight = false;
            this.CanEnPassantAnyMore = true;
            this.CanSprint = true;
            StartTile = tile;
        }
        public override void FindValidTile(Board board)
        {
            base.FindValidTile(board);
            int currentX = CurrentTile.X;
            int currentY = CurrentTile.Y;

            
            if (CurrentTile != StartTile || !CanEnPassantAnyMore)
            {
                CanSprint = false;
            }
            else
            {
                CanSprint = true;
            }

            Pawn toRight;
            Pawn toLeft;
            if (MovedTurn < 1)
            {
                if (Side == "White")
                {
                    if (currentY == StartTile.Y + 2)
                    {
                        if (currentX > 0)
                        {
                            Tile leftTile = board.Tiles[currentX - 1, currentY];
                            if (leftTile != null && leftTile.Piece != null)
                            {
                                if (leftTile.Piece is Pawn && leftTile.Piece.Side == "Black")
                                {
                                    toLeft = leftTile.Piece as Pawn;
                                    if (toLeft.CanEnPassantAnyMore && toLeft.LastMoveTurn < LastMoveTurn)
                                    {
                                        toLeft.CanEnPassantRight = true;
                                        toLeft.CanEnPassantAnyMore = false;
                                    }
                                }
                            }
                        }

                        if (currentX < 7)
                        {
                            Tile rightTile = board.Tiles[currentX + 1, currentY];
                            if (rightTile != null && rightTile.Piece != null)
                            {
                                if (rightTile.Piece is Pawn && rightTile.Piece.Side == "Black")
                                {
                                    toRight = rightTile.Piece as Pawn;
                                    if (toRight.CanEnPassantAnyMore && toRight.LastMoveTurn < LastMoveTurn)
                                    {
                                        toRight.CanEnPassantLeft = true;
                                        CanEnPassantAnyMore = false;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (currentY == StartTile.Y - 2)
                    {
                        if (currentX > 0)
                        {
                            Tile leftTile = board.Tiles[currentX - 1, currentY];
                            if (leftTile != null && leftTile.Piece != null)
                            {
                                if (leftTile.Piece is Pawn && leftTile.Piece.Side == "White")
                                {
                                    toLeft = leftTile.Piece as Pawn;
                                    if (toLeft.CanEnPassantAnyMore && toLeft.LastMoveTurn < LastMoveTurn)
                                    {
                                        toLeft.CanEnPassantRight = true;
                                        toLeft.CanEnPassantAnyMore = false;
                                    }
                                }
                            }
                        }

                        if (currentX < 7)
                        {
                            Tile rightTile = board.Tiles[currentX + 1, currentY];
                            if (rightTile != null && rightTile.Piece != null)
                            {
                                if (rightTile.Piece is Pawn && rightTile.Piece.Side == "White")
                                {
                                    toRight = rightTile.Piece as Pawn;
                                    if (toRight.CanEnPassantAnyMore && toRight.LastMoveTurn < LastMoveTurn)
                                    {
                                        toRight.CanEnPassantLeft = true;
                                        toRight.CanEnPassantAnyMore = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (Side == "White")
            {
                if (currentY < 7)
                {
                    if (board.Tiles[currentX, currentY + 1].Piece == null)
                    {
                        ValidMove.Add(board.Tiles[currentX, currentY + 1]);
                        if (CanSprint && board.Tiles[currentX, currentY + 2].Piece == null)
                        {
                            ValidMove.Add(board.Tiles[currentX, currentY + 2]);
                        }
                    }
                    if (currentX < 7)
                    {
                        if (board.Tiles[currentX + 1, currentY + 1].Piece != null && board.Tiles[currentX + 1, currentY + 1].Piece.Side != "White")
                        {
                            CheckedMove.Add(board.Tiles[currentX + 1, currentY + 1]);
                            CheckedTile(board.Tiles[currentX + 1, currentY + 1]);
                            ValidMove.Add(board.Tiles[currentX + 1, currentY + 1]);
                        }
                    }
                    if (currentX > 0)
                    {
                        if (board.Tiles[currentX - 1, currentY + 1].Piece != null && board.Tiles[currentX - 1, currentY + 1].Piece.Side != "White")
                        {
                            CheckedMove.Add(board.Tiles[currentX - 1, currentY + 1]);
                            CheckedTile(board.Tiles[currentX - 1, currentY + 1]);
                            ValidMove.Add(board.Tiles[currentX - 1, currentY + 1]);
                        }
                    }
                    if(CanEnPassantLeft)
                    {
                        ValidMove.Add(board.Tiles[currentX - 1, currentY + 1]);
                    }
                    if(CanEnPassantRight)
                    {
                        ValidMove.Add(board.Tiles[currentX + 1, currentY + 1]);
                    }
                }
            }
            else
            {
                if (currentY > 0)
                {
                    if (board.Tiles[currentX, currentY - 1].Piece == null)
                    {
                        ValidMove.Add(board.Tiles[currentX, currentY - 1]);
                        if (CanSprint && board.Tiles[currentX, currentY - 2].Piece == null)
                        {
                            ValidMove.Add(board.Tiles[currentX, currentY - 2]);
                        }
                    }
                    if (currentX < 7)
                    {
                        if (board.Tiles[currentX + 1, currentY - 1].Piece != null && board.Tiles[currentX + 1, currentY - 1].Piece.Side != "Black")
                        {
                            CheckedMove.Add(board.Tiles[currentX + 1, currentY - 1]);
                            CheckedTile(board.Tiles[currentX + 1, currentY - 1]);
                            ValidMove.Add(board.Tiles[currentX + 1, currentY - 1]);
                        }
                    }
                    if (currentX > 0)
                    {
                        if (board.Tiles[currentX - 1, currentY - 1].Piece != null && board.Tiles[currentX - 1, currentY - 1].Piece.Side != "Black")
                        {
                            CheckedMove.Add(board.Tiles[currentX - 1, currentY - 1]);
                            CheckedTile(board.Tiles[currentX - 1, currentY - 1]);
                            ValidMove.Add(board.Tiles[currentX - 1, currentY - 1]);
                        }
                    }
                    if (CanEnPassantLeft)
                    {
                        ValidMove.Add(board.Tiles[currentX - 1, currentY - 1]);
                        CanEnPassantLeft = false;
                    }
                    if (CanEnPassantRight)
                    {
                        ValidMove.Add(board.Tiles[currentX + 1, currentY - 1]);
                        CanEnPassantRight = false;
                    }
                }
            }
            foreach (Tile tile in CheckedMove)
            {
                tile.IsChecked[Side] = true;
            }
        }
        public void Promoted(Board board, string promotedType)
        {
            Tile tile = board.Tiles[CurrentTile.X, CurrentTile.Y];

            string tileNo = this.Name.Substring(4);
            switch (promotedType)
            {
                case "Rook":
                    Rook rook = new Rook("Rook" + tileNo, this.Side, "Rook", CurrentTile);
                    tile.Piece = rook;
                    break;
                case "Knight":
                    Knight knight = new Knight("Knight" + tileNo, this.Side, "Knight", CurrentTile);
                    tile.Piece = knight;
                    break;
                case "Bishop":
                    Bishop bishop = new Bishop("Bishop" + tileNo, this.Side, "Bishop", CurrentTile);
                    tile.Piece = bishop;
                    break;
                case "Queen":
                    Queen queen = new Queen("Queen" + tileNo, this.Side, "Queen", CurrentTile);
                    tile.Piece = queen;
                    break;
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
            MovedTurn++;
            LastMoveTurn = index;
            return move;
        }
    }
}
