using ChessWinform.Components;
using ChessWinform.Properties;
using System.Diagnostics;
using System.Media;
using System.Windows.Forms;

namespace ChessWinform
{
    public partial class ChessGame : Form
    {
        public TimeSpan Duration { get; set; }
        private int index = 1;
        internal Player Player1 { get; set; }
        internal Player Player2 { get; set; }
        private Board board = null!;
        private PictureBox? selectedPieceInterface;
        private Image? selectedPieceImage;
        private Tile? selectedTile;
        private SoundPlayer soundPlayer = new SoundPlayer();
        private History History;
        private List<Move> moves = new List<Move>();
        private Dictionary<string, PictureBox> TileInterface = new Dictionary<string, PictureBox>();
        private Menu Menu { get; set; }

        public ChessGame(Menu menu)
        {
            InitializeComponent();
            this.Menu = menu;
        }

        private void ChessGame_Load(object sender, EventArgs e)
        {
            SetUpBoard();
            SetUpPlayer();
            SetUpTime();
            History = new History(DateTime.Now, Player1, Player2);
            SwitchTurn("White");
        }

        private void SetUpBoard()
        {
            board = new Board();
            board.SetUpPieces();
            foreach (Tile tile in board.Tiles)
            {
                Point location = new Point((tile.X) * 70, 490 - (tile.Y) * 70);
                Size size = new Size(70, 70);

                PictureBox tileBox = new PictureBox();
                tileBox.Name = tile.Name;
                tileBox.Size = size;
                tileBox.Location = location;
                tileBox.Image = tile.Image;

                PictureBox pieceBox = new PictureBox();
                if (tile.Piece != null)
                {
                    pieceBox.Name = tile.Name;
                    pieceBox.Image = tile.Piece.Image;
                }
                else
                {
                    pieceBox.Name = tile.Name;
                }
                pieceBox.Size = size;
                pieceBox.BackgroundImage = tileBox.Image;
                pieceBox.BackColor = Color.Transparent;
                pieceBox.Location = location;
                pieceBox.SizeMode = PictureBoxSizeMode.Zoom;
                pieceBox.Click += BoardInteract;
                boardPanel.Controls.Add(pieceBox);
                boardPanel.Controls.Add(tileBox);
                TileInterface.Add(tile.Name, tileBox);
            }
        }
        private void SetUpPlayer()
        {
            Player1 = new Player("Player1");
            Player2 = new Player("Player2");

            Player1.TimeLeft = Duration;
            Player2.TimeLeft = Duration;
        }
        private void SetUpTime()
        {
            player1Timeleft.Text = Duration.Minutes.ToString() + ":" + Duration.Seconds.ToString();
            player2Timeleft.Text = Duration.Minutes.ToString() + ":" + Duration.Seconds.ToString();
        }

        private void BoardInteract(object? sender, EventArgs e)
        {
            PictureBox? piecePictureBox = sender as PictureBox;
            Tile destinationTile;
            if (piecePictureBox != null)
            {
                destinationTile = board.FindTileByName(piecePictureBox.Name);
                if (selectedTile != null)
                {
                    if (selectedTile.Piece != null && selectedTile.Piece.CanMove == true)
                    {
                        string side = selectedTile.Piece.Side;
                        if (selectedTile.Piece.CanLeadToChecked(board, selectedTile, destinationTile, side))
                        {
                            selectedTile.Piece.ValidMove.Remove(destinationTile);
                        }
                        if (selectedTile.Piece.ValidMove.Contains(destinationTile))
                        {
                            if (selectedTile.Piece.Type == "King")
                            {
                                moves.Add(selectedTile.Piece.Move(board, selectedTile, destinationTile, piecePictureBox, selectedPieceInterface, index));
                                if (selectedPieceInterface != null)
                                {
                                    selectedPieceInterface.BackgroundImage = selectedPieceImage;
                                }
                                if (selectedTile.X - destinationTile.X == 2)
                                {
                                    if (destinationTile.Piece.Side == "White")
                                    {
                                        Tile tempDestinationTile = board.FindTileByName("d1");
                                        Tile tempSelectedTile = board.FindTileByName("a1");
                                        PictureBox destinationPictureBox = (PictureBox)boardPanel.Controls.Find("d1", false)[0];
                                        PictureBox selectedPictureBox = (PictureBox)boardPanel.Controls.Find("a1", false)[0];
                                        moves.Add(board.FindTileByName("a1").Piece.Move(board, tempSelectedTile, tempDestinationTile, destinationPictureBox, selectedPictureBox, index));
                                    }
                                    else
                                    {
                                        Tile tempDestinationTile = board.FindTileByName("d8");
                                        Tile tempSelectedTile = board.FindTileByName("a8");
                                        PictureBox destinationPictureBox = (PictureBox)boardPanel.Controls.Find("d8", false)[0];
                                        PictureBox selectedPictureBox = (PictureBox)boardPanel.Controls.Find("a8", false)[0];
                                        moves.Add(board.FindTileByName("a8").Piece.Move(board, tempSelectedTile, tempDestinationTile, destinationPictureBox, selectedPictureBox, index));
                                    }
                                }
                                else if (selectedTile.X - destinationTile.X == -2)
                                {
                                    if (destinationTile.Piece.Side == "White")
                                    {
                                        Tile tempDestinationTile = board.FindTileByName("f1");
                                        Tile tempSelectedTile = board.FindTileByName("h1");
                                        PictureBox destinationPictureBox = (PictureBox)boardPanel.Controls.Find("f1", false)[0];
                                        PictureBox selectedPictureBox = (PictureBox)boardPanel.Controls.Find("h1", false)[0];
                                        moves.Add(board.FindTileByName("h1").Piece.Move(board, tempSelectedTile, tempDestinationTile, destinationPictureBox, selectedPictureBox, index));
                                    }
                                    else
                                    {
                                        Tile tempDestinationTile = board.FindTileByName("f8");
                                        Tile tempSelectedTile = board.FindTileByName("h8");
                                        PictureBox destinationPictureBox = (PictureBox)boardPanel.Controls.Find("f8", false)[0];
                                        PictureBox selectedPictureBox = (PictureBox)boardPanel.Controls.Find("h8", false)[0];
                                        moves.Add(board.FindTileByName("h8").Piece.Move(board, tempSelectedTile, tempDestinationTile, destinationPictureBox, selectedPictureBox, index));
                                    }
                                }
                            }
                            else if (selectedTile.Piece.Type == "Pawn")
                            {
                                if (destinationTile.Piece == null && selectedTile.X - destinationTile.X == 1)
                                {
                                    Tile leftTile = board.Tiles[selectedTile.X - 1, selectedTile.Y];
                                    PictureBox removedPictureBox = (PictureBox)boardPanel.Controls.Find(leftTile.Name, false)[0];
                                    selectedTile.Piece.Move(board, selectedTile, leftTile, removedPictureBox, selectedPieceInterface, index);
                                    moves.Add(leftTile.Piece.Move(board, leftTile, destinationTile, piecePictureBox, removedPictureBox, index));
                                }
                                else if (destinationTile.Piece == null && selectedTile.X - destinationTile.X == -1)
                                {
                                    Tile rightTile = board.Tiles[selectedTile.X + 1, selectedTile.Y];
                                    PictureBox removedPictureBox = (PictureBox)boardPanel.Controls.Find(rightTile.Name, false)[0];
                                    selectedTile.Piece.Move(board, selectedTile, rightTile, removedPictureBox, selectedPieceInterface, index);
                                    moves.Add(rightTile.Piece.Move(board, rightTile, destinationTile, piecePictureBox, removedPictureBox, index));
                                }
                                else
                                {
                                    moves.Add(selectedTile.Piece.Move(board, selectedTile, destinationTile, piecePictureBox, selectedPieceInterface, index));
                                }
                                if (destinationTile.Y == 7 || destinationTile.Y == 0)
                                {
                                    promotePanel.Visible = true;
                                    promoteButton.Visible = true;
                                }
                            }
                            else
                            {
                                moves.Add(selectedTile.Piece.Move(board, selectedTile, destinationTile, piecePictureBox, selectedPieceInterface, index));
                            }
                            soundPlayer.Stream = Properties.Resources.Moving;
                            soundPlayer.Play();
                            index++;
                            if (side == "White")
                            {
                                string text = "";
                                foreach (Move move in moves)
                                {
                                    text += move.ToString();
                                }
                                movesView.Text = text;
                                if (!promotePanel.Visible)
                                {
                                    SwitchTurn("Black");
                                }
                            }
                            else
                            {
                                List<Move> dataMove = new List<Move>();
                                string text = "";
                                foreach (Move move in moves)
                                {
                                    text += move.ToString();
                                }
                                movesView.Text = text;
                                if (!promotePanel.Visible)
                                {
                                    SwitchTurn("White");
                                }
                            }
                        }
                    }
                }
            }
            if (selectedPieceInterface != null)
            {
                selectedPieceInterface.BackgroundImage = selectedPieceImage;
            }
            if (piecePictureBox != null)
            {
                selectedPieceImage = piecePictureBox.BackgroundImage;
                piecePictureBox.BackgroundImage = Properties.Resources.choosen_tile;
                selectedPieceInterface = piecePictureBox;
                selectedTile = board.FindTileByName(piecePictureBox.Name);
            }
        }
        private void SwitchTurn(string side)
        {
            switch (side)
            {
                case "White":
                    board.IsWhiteChecked();
                    if (IsStalemate("White"))
                    {
                        MessageBox.Show("Stalemate");
                        Black.Stop();
                        White.Stop();
                        foreach (Tile tile in board.Tiles)
                        {
                            if (tile.Piece != null)
                            {
                                tile.Piece.CanMove = false;
                            }
                        }
                        History.Duration = DateTime.Now - History.Time;
                        History.Moves = moves;
                        SaveHistory();
                        return;
                    }
                    if (!board.WhiteKingChecked)
                    {
                        foreach (Tile tile in board.Tiles)
                        {
                            if (tile.Piece != null)
                            {
                                tile.Piece.FindValidTile(board);
                            }
                            if (tile.Piece != null && tile.Piece.Side == "White")
                            {
                                tile.Piece.CanMove = true;
                            }
                        }
                    }
                    else
                    {
                        soundPlayer.Stream = Properties.Resources.check;
                        soundPlayer.Play();
                        if (IsWhiteMate())
                        {
                            MessageBox.Show(Player2.Name + " won");
                            Black.Stop();
                            White.Stop();
                            foreach (Tile tile in board.Tiles)
                            {
                                if (tile.Piece != null)
                                {
                                    tile.Piece.CanMove = false;
                                }
                            }
                            History.Duration = DateTime.Now - History.Time;
                            History.Moves = moves;
                            SaveHistory();
                            return;
                        }
                        board.PreMove("White");
                        foreach (Tile tile in board.Tiles)
                        {
                            if (tile.Piece != null && tile.Piece.Side == "White" && tile.Piece.PreventCheckMove.Count > 0)
                            {
                                tile.Piece.CanMove = true;
                                tile.Piece.ValidMove.Clear();
                                foreach (Tile preventCheckTile in tile.Piece.PreventCheckMove)
                                {
                                    tile.Piece.ValidMove.Add(preventCheckTile);
                                }
                            }
                        }
                    }
                    foreach (Tile tile in board.Tiles)
                    {
                        if (tile.Piece != null && tile.Piece.Side == "Black")
                        {
                            tile.Piece.CanMove = false;
                        }
                    }
                    White.Start();
                    Black.Stop();
                    break;
                case "Black":
                    board.IsBlackChecked();
                    if (IsStalemate("Black"))
                    {
                        MessageBox.Show("Stalemate");
                        Black.Stop();
                        White.Stop();
                        foreach (Tile tile in board.Tiles)
                        {
                            if (tile.Piece != null)
                            {
                                tile.Piece.CanMove = false;
                            }
                        }
                        History.Duration = DateTime.Now - History.Time;
                        History.Moves = moves;
                        SaveHistory();
                        return;
                    }
                    if (!board.BlackKingChecked)
                    {
                        foreach (Tile tile in board.Tiles)
                        {
                            if (tile.Piece != null)
                            {
                                tile.Piece.FindValidTile(board);
                            }
                            if (tile.Piece != null && tile.Piece.Side == "Black")
                            {
                                tile.Piece.CanMove = true;
                            }
                        }
                    }
                    else
                    {
                        soundPlayer.Stream = Properties.Resources.check;
                        soundPlayer.Play();
                        if (IsBlackMate())
                        {
                            MessageBox.Show(Player1.Name + " won");
                            Black.Stop();
                            White.Stop();
                            foreach (Tile tile in board.Tiles)
                            {
                                if (tile.Piece != null)
                                {
                                    tile.Piece.CanMove = false;
                                }
                            }
                            History.Duration = DateTime.Now - History.Time;
                            History.Moves = moves;
                            SaveHistory();
                            return;
                        }
                        board.PreMove("Black");
                        foreach (Tile tile in board.Tiles)
                        {
                            if (tile.Piece != null && tile.Piece.Side == "Black" && tile.Piece.PreventCheckMove.Count > 0)
                            {
                                tile.Piece.CanMove = true;
                                tile.Piece.ValidMove.Clear();
                                foreach (Tile preventCheckTile in tile.Piece.PreventCheckMove)
                                {
                                    tile.Piece.ValidMove.Add(preventCheckTile);
                                }
                            }
                        }
                    }
                    foreach (Tile tile in board.Tiles)
                    {
                        if (tile.Piece != null && tile.Piece.Side == "White")
                        {
                            tile.Piece.CanMove = false;
                        }
                    }
                    Black.Start();
                    White.Stop();
                    break;
            }
        }
        public bool IsStalemate(string side)
        {
            int count = 0;
            foreach (Tile tile in board.Tiles)
            {
                if (tile.Piece != null && tile.Piece.Type == side)
                {
                    tile.Piece.FindValidTile(board);
                    if (tile.Piece.ValidMove.Count > 0)
                    {
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsWhiteMate()
        {
            foreach (Tile tile in board.Tiles)
            {
                if (tile.Piece is King && tile.Piece.Side == "White")
                {
                    King king = tile.Piece as King;
                    king.FindValidTile(board);
                    if (king.ValidMove.Count == 0 && board.WhiteKingChecked)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsBlackMate()
        {
            foreach (Tile tile in board.Tiles)
            {
                if (tile.Piece is King && tile.Piece.Side == "Black")
                {
                    King king = tile.Piece as King;
                    king.FindValidTile(board);
                    if (king.ValidMove.Count == 0 && board.WhiteKingChecked)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Player1.TimeLeft = Player1.TimeLeft.Subtract(TimeSpan.FromSeconds(1));
            player1Timeleft.Text = Player1.TimeLeft.Minutes.ToString() + ":" + Player1.TimeLeft.Seconds.ToString();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            Player2.TimeLeft = Player2.TimeLeft.Subtract(TimeSpan.FromSeconds(1));
            player2Timeleft.Text = Player2.TimeLeft.Minutes.ToString() + ":" + Player2.TimeLeft.Seconds.ToString();
        }

        private void promoteButton_Click(object sender, EventArgs e)
        {
            string role = "";
            foreach (RadioButton promoteRole in promotePanel.Controls)
            {
                if (promoteRole.Checked)
                {
                    role = promoteRole.Text;
                }
            }
            foreach (Tile tile in board.Tiles)
            {
                if (tile.Piece != null && tile.Piece.Type == "Pawn" && (tile.Piece.CurrentTile.Y == 7 || tile.Piece.CurrentTile.Y == 0))
                {
                    Pawn pawn = tile.Piece as Pawn;
                    pawn.Promoted(board, role);
                    foreach (PictureBox pictureBox in boardPanel.Controls)
                    {
                        if (pictureBox.Name == tile.Name)
                        {
                            pictureBox.Image = tile.Piece.Image;
                            if (tile.Piece.Side == "White")
                            {
                                SwitchTurn("Black");
                            }
                            else
                            {
                                SwitchTurn("White");
                            }
                            promotePanel.Visible = false;
                            promoteButton.Visible = false;
                            break;
                        }
                    }
                    break;
                }
            }
        }
        public void SaveHistory()
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }
            using (StreamWriter writer = File.CreateText(Path.Combine("data", History.Time.Ticks + ".txt")))
            {
                writer.Write(History);
            }
        }

        private void ChessGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu.Show();
        }
    }
}