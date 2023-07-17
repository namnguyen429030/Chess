using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChessWinform.Components
{
    internal class King : ChessPiece
    {
        public bool CanCastle { get; set; }
        public bool IsChecked { get; set; }
        public Tile StartTile { get; set; }
        public King(string name, string side, string type, Tile tile) : base(name, side, type, tile)
        {
            this.CanCastle = true;
            if(side == "White")
            {
                this.Image = Properties.Resources.white_king;
            }
            else
            {
                this.Image = Properties.Resources.black_king;
            }
            StartTile = tile;
            CanCastle = true;
        }

        public override void FindValidTile(Board board)
        {
            base.FindValidTile(board);
            int currentX = CurrentTile.X;
            int currentY = CurrentTile.Y;

            if(CurrentTile != StartTile || IsChecked)
            {
                CanCastle = false;
            }
            //Rook
            //Quarter 1 move
            if (currentY < 7)
            {
                Tile tile = board.Tiles[currentX, currentY + 1];
                if ((tile.Piece == null || tile.Piece.Side != this.Side) && !tile.IsChecked[Side])
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                }
            }
            //Quarter 2 move
            if (currentX < 7)
            {
                Tile tile = board.Tiles[currentX + 1, currentY];
                if ((tile.Piece == null || tile.Piece.Side != this.Side) && !tile.IsChecked[Side])
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                }
            }
            //Quarter 3 move
            if (currentY > 0)
            {
                Tile tile = board.Tiles[currentX, currentY - 1];
                if ((tile.Piece == null || tile.Piece.Side != this.Side) && !tile.IsChecked[Side])
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                }
            }
            //Quarter 4 moves
            if (currentX > 0)
            {
                Tile tile = board.Tiles[currentX - 1, currentY];
                if ((tile.Piece == null || tile.Piece.Side != this.Side) && !tile.IsChecked[Side])
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                }
            }
            //Bishop
            //Half 1 moves
            if (currentX > 0 && currentY < 7)
            {
                Tile tile = board.Tiles[currentX - 1, currentY + 1];

                if ((tile.Piece == null || tile.Piece.Side != this.Side) && !tile.IsChecked[Side])
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                }
            }
            if (currentX < 7 && currentY > 0)
            {
                Tile tile = board.Tiles[currentX + 1, currentY - 1];
                if ((tile.Piece == null || tile.Piece.Side != this.Side) && !tile.IsChecked[Side])
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                }
            }
            //Half 2 moves
            if (currentX > 0 && currentY > 0)
            {
                Tile tile = board.Tiles[currentX - 1, currentY - 1];
                if ((tile.Piece == null || tile.Piece.Side != this.Side) && !tile.IsChecked[Side])
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                }
            }
            if (currentX < 7 && currentY < 7)
            {
                Tile tile = board.Tiles[currentX + 1, currentY + 1];
                if ((tile.Piece == null || tile.Piece.Side != this.Side)  && !tile.IsChecked[Side])
                {
                    CheckedMove.Add(tile);
                    CheckedTile(tile);
                    ValidMove.Add(tile);
                }
            }
            if (CanCastle)
            {
                if (Side == "White")
                {
                    bool canCastleShort = true;
                    bool canCastleLong = true;
                    for (int i = currentX + 1; i < 7; i++)
                    {
                        if(board.Tiles[i, 0].Piece != null || IsChecked)
                        {
                            canCastleShort = false;
                            break;
                        }
                    }
                    for(int i = currentX - 1; i > 1; i--)
                    {
                        if (board.Tiles[i,0].Piece != null || IsChecked)
                        {
                            canCastleLong = false;
                            break;
                        }
                    }
                    if (canCastleShort)
                    {
                        Tile shortTile = board.Tiles[currentX + 2, 0];
                        ValidMove.Add(shortTile);
                    }
                    if(canCastleLong)
                    {
                        Tile longTile = board.Tiles[currentX - 2, 0];
                        ValidMove.Add(longTile);
                    }
                }
                else
                {
                    bool canCastleLong = true;
                    bool canCastleShort = true;
                    for (int i = currentX + 1; i < 7; i++)
                    {
                        if (board.Tiles[i, 7].Piece != null || IsChecked)
                        {
                            canCastleShort = false;
                            break;
                        }
                    }
                    for (int i = currentX - 1; i > 1; i--)
                    {
                        if (board.Tiles[i, 7].Piece != null || IsChecked)
                        {
                            canCastleLong = false;
                            break;
                        }
                    }
                    if (canCastleShort)
                    {
                        Tile shortTile = board.Tiles[currentX + 2, 7];
                        ValidMove.Add(shortTile);
                    }
                    if (canCastleLong)
                    {
                        Tile longTile = board.Tiles[currentX - 2, 7];
                        ValidMove.Add(longTile);
                    }
                }
            }
            foreach (Tile tile in CheckedMove)
            {
                tile.IsChecked[Side] = true;
            }
            int allTileCanMove = FindAllTileCanMove(board);
            if ((ValidMove.Count < allTileCanMove) && CurrentTile.IsChecked[Side])
            {
                IsChecked = true;
            }
            else
            {
                IsChecked = false;
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
        public int FindAllTileCanMove(Board board)
        {
            int currentX = CurrentTile.X;
            int currentY = CurrentTile.Y;
            int count = 0;
            //Rook
            //Quarter 1 move
            if (currentY < 7)
            {
                Tile q1Tile = board.Tiles[currentX, currentY + 1];
                if (q1Tile.Piece == null || q1Tile.Piece.Side != this.Side)
                {
                    count++;
                }
            }
            //Quarter 2 move
            if (currentX < 7)
            {
                Tile q2Tile = board.Tiles[currentX + 1, currentY];
                if (q2Tile.Piece == null || q2Tile.Piece.Side != this.Side)
                {
                    count++;
                }
            }
            //Quarter 3 move
            if (currentY > 0)
            {
                Tile q3Tile = board.Tiles[currentX, currentY - 1];
                if (q3Tile.Piece == null || q3Tile.Piece.Side != this.Side)
                {
                    count++;
                }
            }
            //Quarter 4 moves
            if (currentX > 0)
            {
                Tile q4Tile = board.Tiles[currentX - 1, currentY];
                if (q4Tile.Piece == null || q4Tile.Piece.Side != this.Side)
                {
                    count++;
                }
            }
            //Bishop
            //Half 1 moves
            if (currentX > 0 && currentY < 7)
            {
                Tile q5Tile = board.Tiles[currentX - 1, currentY + 1];

                if (q5Tile.Piece == null || q5Tile.Piece.Side != this.Side)
                {
                    count++;
                }
            }
            if (currentX < 7 && currentY > 0)
            {
                Tile q6Tile = board.Tiles[currentX + 1, currentY - 1];
                if (q6Tile.Piece == null || q6Tile.Piece.Side != this.Side)
                {
                    count++;
                }
            }
            //Half 2 moves
            if (currentX > 0 && currentY > 0)
            {
                Tile q7Tile = board.Tiles[currentX - 1, currentY - 1];
                if (q7Tile.Piece == null || q7Tile.Piece.Side != this.Side)
                {
                    count++;
                }
            }
            if (currentX < 7 && currentY < 7)
            {
                Tile q8Tile = board.Tiles[currentX + 1, currentY + 1];
                if (q8Tile.Piece == null || q8Tile.Piece.Side != this.Side)
                {
                    count++;
                }
            }
            if (CanCastle)
            {
                bool canCastleShort = true;
                bool canCastleLong = true;
                if (Side == "White")
                {
                    for (int i = currentX + 1; i < 7; i++)
                    {
                        if (board.Tiles[i, 0].Piece != null || !IsChecked)
                        {
                            canCastleShort = false;
                            break;
                        }
                    }
                    for (int i = currentX - 1; i > 1; i--)
                    {
                        if (board.Tiles[i, 0].Piece != null || !IsChecked)
                        {
                            canCastleLong = false;
                            break;
                        }
                    }
                    if (canCastleShort)
                    {
                        count++;
                    }
                    if (canCastleLong)
                    {
                        count++;
                    }
                }
                else
                {
                    canCastleLong = true;
                    canCastleShort = true;
                    for (int i = currentX + 1; i < 7; i++)
                    {
                        if (board.Tiles[i, 7].Piece != null)
                        {
                            canCastleShort = false;
                            break;
                        }
                    }
                    for (int i = currentX - 1; i > 1; i--)
                    {
                        if (board.Tiles[i, 7].Piece != null)
                        {
                            canCastleLong = false;
                            break;
                        }
                    }
                    if (canCastleShort)
                    {
                        count++;
                    }
                    if (canCastleLong)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
