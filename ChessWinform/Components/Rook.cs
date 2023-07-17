﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinform.Components
{
    internal class Rook : ChessPiece
    {
        public Tile StartTile { get; set; }
        public bool CanCastle { get; set; }
        public Rook(string name, string side, string type, Tile tile) : base(name, side, type, tile) 
        {
            if (side == "White")
            {
                this.Image = Properties.Resources.white_rook;
            }
            else
            {
                this.Image = Properties.Resources.black_rook;
            }
            StartTile = tile;
            CanCastle = true;
        }
        public override void FindValidTile(Board board)
        {
            base.FindValidTile(board);
            int currentX = CurrentTile.X;
            int currentY = CurrentTile.Y;

            int i = currentX;
            int j = currentY;

            if (CurrentTile != StartTile)
            {
                CanCastle = false;
            }

            bool blocked = false;
            //Quarter 1 moves
            while (j < 7)
            {
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
            j = currentY;
            blocked = false;
            //Quarter 2 moves
            while (i < 7)
            {
                i++;
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
            blocked = false;
            //Quarter 3 moves
            while (j >= 1)
            {
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
            j = currentY;
            blocked = false;
            //Quarter 4 moves
            while (i >= 1)
            {
                i--;
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
            Move move = new Move(index,selectedTile, destinationTile, selectedTile.Piece, destinationTile.Piece);
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
