using ChessWinform.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessWinform
{
    public partial class Menu : Form
    {
        private string Mode { get; set; } = null!;
        private List<History> histories = new List<History>();
        private SoundPlayer soundPlayer = new SoundPlayer();
        public Menu()
        {
            InitializeComponent();
        }

        private void thirtyMinsButton_Click(object sender, EventArgs e)
        {
            ChessGame game = new ChessGame(this);
            game.Duration = new TimeSpan(0, 30, 0);
            this.Hide();
            game.Show();
        }

        private void tenMinsButton_Click(object sender, EventArgs e)
        {
            ChessGame game = new ChessGame(this);
            game.Duration = new TimeSpan(0, 10, 0);
            this.Hide();
            game.Show();
        }

        private void fiveMinsButton_Click(object sender, EventArgs e)
        {
            ChessGame game = new ChessGame(this);
            game.Duration = new TimeSpan(0, 5, 0);
            this.Hide();
            game.Show();
        }

        private void twoMinsButton_Click(object sender, EventArgs e)
        {
            ChessGame game = new ChessGame(this);
            game.Duration = new TimeSpan(0, 2, 0);
            this.Hide();
            game.Show();
        }

        private void normalModeButton_Click(object sender, EventArgs e)
        {
            modePanel.Visible = false;
            panel1.Visible = true;
            Mode = normalModeButton.Text;
        }

        private void specialModeButton_Click(object sender, EventArgs e)
        {
            modePanel.Visible = false;
            panel1.Visible = true;
            Mode = specialModeButton.Text;
        }

        private void noAudioButton_Click(object sender, EventArgs e)
        {
            soundPlayer.Play();
            audioButton.Visible = true;
            noAudioButton.Visible = false;
        }

        private void audioButton_Click(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            audioButton.Visible = false;
            noAudioButton.Visible = true;
        }

        private void historyButton_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            soundPlayer.Stream = Properties.Resources.y2mate_com___Dmitri_Shostakovich__Waltz_No_2;
            soundPlayer.PlayLooping();
        }
    }
}
