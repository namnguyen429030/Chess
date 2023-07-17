using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWinform.Components
{
    internal class Board
    {
        public Tile[,] Tiles = new Tile[8,8];
        public bool WhiteKingChecked { get; set; }
        public bool BlackKingChecked { get; set; }
        public Board()
        {
            char[] alphabet = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'};
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    string tileName = ""+ alphabet[i] + (j+1);
                    Tile tile = null!;
                    if ((i % 2 != 0 && j % 2 !=0) || (i % 2 == 0 && j % 2 == 0))
                    {
                        tile = new Tile(i, j, tileName, "Black", Properties.Resources.black_tile);
                    }
                    else
                    {
                        tile = new Tile(i, j, tileName, "White", Properties.Resources.white_tile);
                    }
                    tile.IsChecked.Add("White", false);
                    tile.IsChecked.Add("Black", false);
                    WhiteKingChecked = false;
                    BlackKingChecked = false;
                    Tiles[i, j]= tile;
                }
            }
        }

        public void SetUpPieces()
        {
            //Pawns spawn
            for (int i = 0; i < 8; i++)
            {
                Tile white = Tiles[i, 1];
                Tile black = Tiles[i, 6];
                white.Piece = new Pawn("Pawn" + white.Name, "White", "Pawn", white);
                black.Piece = new Pawn("Pawn" + black.Name, "Black", "Pawn", black);
            }
            //Rooks spawn
            for (int i = 0; i < 8; i+=7) 
            {
                Tile white = Tiles[i, 0];
                Tile black = Tiles[i, 7];
                white.Piece = new Rook("Rook" + white.Name, "White", "Rook", white);
                black.Piece = new Rook("Rook" + black.Name, "Black", "Rook", black);
            }
            //Knights spawn
            for (int i = 1; i < 8; i += 5)
            {
                Tile white = Tiles[i, 0];
                Tile black = Tiles[i, 7];
                white.Piece = new Knight("Knight" + white.Name, "White", "Knight", white);
                black.Piece = new Knight("Knight" + black.Name, "Black", "Knight", black);
            }
            //Bishops spawn
            for (int i = 2; i < 8; i += 3)
            {
                Tile white = Tiles[i, 0];
                Tile black = Tiles[i, 7];
                white.Piece = new Bishop("Bishop" + white.Name, "White", "Bishop", white);
                black.Piece = new Bishop("Bishop" + black.Name, "Black", "Bishop", black);
            }
            //Queens and Kings spawn
            Tiles[3, 0].Piece = new Queen("Queen" + Tiles[3, 0].Name, "White", "Queen", Tiles[3,0]);
            Tiles[3, 7].Piece = new Queen("Queen" + Tiles[3, 7].Name, "Black", "Queen", Tiles[3, 7]);
            Tiles[4, 0].Piece = new King("King" + Tiles[4, 0].Name, "White", "King", Tiles[4, 0]);
            Tiles[4, 7].Piece = new King("King" + Tiles[4, 7].Name, "Black", "King", Tiles[4, 7]);
            foreach (Tile tile in Tiles)
            {
                if (tile.Piece != null)
                {
                    tile.Piece.FindValidTile(this);
                }
            }
        }
        public Tile FindTileByName(string tileName)
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (Tiles[i, j].Name == tileName)
                    {
                        return Tiles[i, j];
                    }
                }
            }
            return null!;
        }
        public void IsWhiteChecked()
        {
            foreach (Tile tile in Tiles)
            {
                if (tile.Piece is King)
                {
                    King king = tile.Piece as King;
                    king.FindValidTile(this);
                    if (king.Side == "White")
                    {
                        if (king.IsChecked)
                        {
                            WhiteKingChecked = true;
                        }
                        else
                        {
                            WhiteKingChecked = false;
                        }
                        break;
                    }

                }
            }
        }
        public void IsBlackChecked()
        {
            foreach (Tile tile in Tiles)
            {
                if (tile.Piece is King)
                {
                    King king = tile.Piece as King;
                    king.FindValidTile(this);
                    if (king.Side == "Black")
                    {
                        if (king.IsChecked)
                        {
                            BlackKingChecked = true;
                        }
                        else
                        {
                            BlackKingChecked = false;
                        }
                        break;
                    }

                }
            }
        }
        public bool CanTileBeWhiteChecked(Tile chosenTile)
        {
            foreach (Tile tile in Tiles)
            {
                if (tile.Piece != null) 
                { 
                    if (tile.Piece.CheckedMove.Contains(chosenTile) && tile.Piece.Side == "White")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CanTileBeBlackChecked(Tile chosenTile)
        {
            foreach (Tile tile in Tiles)
            {
                if (tile.Piece != null)
                {
                    if (tile.Piece.CheckedMove.Contains(chosenTile) && tile.Piece.Side == "Black")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void PreMove(string side)
        {
            foreach(Tile tile in  Tiles)
            { 
                if (tile.Piece != null)
                {
                    ChessPiece piece = tile.Piece;
                    piece.PreventCheckMove.Clear();
                    piece.FindValidTile(this);
                    if (piece.Side == side)
                    {
                        foreach (Tile validTile in piece.ValidMove.ToList())
                        {
                            piece.CanPreventCheck(this, piece.CurrentTile, validTile, side);
                        }
                    }
                }
            }
        }
        public void ClearTile()
        {
            foreach (Tile tile in Tiles)
            {
                if (!CanTileBeBlackChecked(tile))
                {
                    tile.IsChecked["White"] = false;
                }
                if (!CanTileBeWhiteChecked(tile))
                {
                    tile.IsChecked["Black"] = false;
                }
            }
        }
    }
}
