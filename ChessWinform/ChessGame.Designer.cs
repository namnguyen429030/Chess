namespace ChessWinform
{
    partial class ChessGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessGame));
            White = new System.Windows.Forms.Timer(components);
            player2Timeleft = new TextBox();
            player1Timeleft = new TextBox();
            Black = new System.Windows.Forms.Timer(components);
            boardPanel = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            Player2Label = new Label();
            Player1Label = new Label();
            promotePanel = new Panel();
            bishopPromote = new RadioButton();
            rookPromote = new RadioButton();
            knightPromote = new RadioButton();
            queenPromote = new RadioButton();
            promoteButton = new Button();
            movesView = new RichTextBox();
            promotePanel.SuspendLayout();
            SuspendLayout();
            // 
            // White
            // 
            White.Interval = 1000;
            White.Tick += timer1_Tick;
            // 
            // player2Timeleft
            // 
            player2Timeleft.BorderStyle = BorderStyle.FixedSingle;
            player2Timeleft.Enabled = false;
            player2Timeleft.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            player2Timeleft.Location = new Point(983, 219);
            player2Timeleft.Margin = new Padding(4, 5, 4, 5);
            player2Timeleft.Name = "player2Timeleft";
            player2Timeleft.ReadOnly = true;
            player2Timeleft.Size = new Size(141, 37);
            player2Timeleft.TabIndex = 0;
            // 
            // player1Timeleft
            // 
            player1Timeleft.BorderStyle = BorderStyle.FixedSingle;
            player1Timeleft.Enabled = false;
            player1Timeleft.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            player1Timeleft.Location = new Point(984, 436);
            player1Timeleft.Margin = new Padding(4, 5, 4, 5);
            player1Timeleft.Name = "player1Timeleft";
            player1Timeleft.ReadOnly = true;
            player1Timeleft.Size = new Size(141, 37);
            player1Timeleft.TabIndex = 1;
            // 
            // Black
            // 
            Black.Interval = 1000;
            Black.Tick += timer2_Tick;
            // 
            // boardPanel
            // 
            boardPanel.Location = new Point(164, 59);
            boardPanel.Margin = new Padding(4, 5, 4, 5);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(560, 560);
            boardPanel.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(177, 624);
            label1.Name = "label1";
            label1.Size = new Size(31, 38);
            label1.TabIndex = 3;
            label1.Text = "a";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(248, 624);
            label2.Name = "label2";
            label2.Size = new Size(33, 38);
            label2.TabIndex = 4;
            label2.Text = "b";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(321, 624);
            label3.Name = "label3";
            label3.Size = new Size(30, 38);
            label3.TabIndex = 5;
            label3.Text = "c";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(391, 624);
            label4.Name = "label4";
            label4.Size = new Size(33, 38);
            label4.TabIndex = 6;
            label4.Text = "d";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(464, 624);
            label5.Name = "label5";
            label5.Size = new Size(32, 38);
            label5.TabIndex = 7;
            label5.Text = "e";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(536, 624);
            label6.Name = "label6";
            label6.Size = new Size(26, 38);
            label6.TabIndex = 8;
            label6.Text = "f";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(602, 624);
            label7.Name = "label7";
            label7.Size = new Size(33, 38);
            label7.TabIndex = 9;
            label7.Text = "g";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(675, 624);
            label8.Name = "label8";
            label8.Size = new Size(33, 38);
            label8.TabIndex = 10;
            label8.Text = "h";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(110, 576);
            label9.Name = "label9";
            label9.Size = new Size(32, 38);
            label9.TabIndex = 11;
            label9.Text = "1";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(110, 504);
            label10.Name = "label10";
            label10.Size = new Size(32, 38);
            label10.TabIndex = 12;
            label10.Text = "2";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(110, 432);
            label11.Name = "label11";
            label11.Size = new Size(32, 38);
            label11.TabIndex = 13;
            label11.Text = "3";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(110, 360);
            label12.Name = "label12";
            label12.Size = new Size(32, 38);
            label12.TabIndex = 14;
            label12.Text = "4";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(110, 288);
            label13.Name = "label13";
            label13.Size = new Size(32, 38);
            label13.TabIndex = 15;
            label13.Text = "5";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(110, 216);
            label14.Name = "label14";
            label14.Size = new Size(32, 38);
            label14.TabIndex = 16;
            label14.Text = "6";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(110, 144);
            label15.Name = "label15";
            label15.Size = new Size(32, 38);
            label15.TabIndex = 17;
            label15.Text = "7";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(110, 72);
            label16.Name = "label16";
            label16.Size = new Size(32, 38);
            label16.TabIndex = 18;
            label16.Text = "8";
            // 
            // Player2Label
            // 
            Player2Label.AutoSize = true;
            Player2Label.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            Player2Label.Location = new Point(983, 169);
            Player2Label.Name = "Player2Label";
            Player2Label.Size = new Size(140, 45);
            Player2Label.TabIndex = 19;
            Player2Label.Text = "Player 2";
            // 
            // Player1Label
            // 
            Player1Label.AutoSize = true;
            Player1Label.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            Player1Label.Location = new Point(984, 386);
            Player1Label.Name = "Player1Label";
            Player1Label.Size = new Size(140, 45);
            Player1Label.TabIndex = 20;
            Player1Label.Text = "Player 1";
            // 
            // promotePanel
            // 
            promotePanel.Controls.Add(bishopPromote);
            promotePanel.Controls.Add(rookPromote);
            promotePanel.Controls.Add(knightPromote);
            promotePanel.Controls.Add(queenPromote);
            promotePanel.Location = new Point(758, 482);
            promotePanel.Name = "promotePanel";
            promotePanel.Size = new Size(157, 143);
            promotePanel.TabIndex = 21;
            promotePanel.Visible = false;
            // 
            // bishopPromote
            // 
            bishopPromote.AutoSize = true;
            bishopPromote.Location = new Point(7, 108);
            bishopPromote.Name = "bishopPromote";
            bishopPromote.Size = new Size(91, 29);
            bishopPromote.TabIndex = 3;
            bishopPromote.TabStop = true;
            bishopPromote.Text = "Bishop";
            bishopPromote.UseVisualStyleBackColor = true;
            // 
            // rookPromote
            // 
            rookPromote.AutoSize = true;
            rookPromote.Location = new Point(7, 73);
            rookPromote.Name = "rookPromote";
            rookPromote.Size = new Size(78, 29);
            rookPromote.TabIndex = 2;
            rookPromote.TabStop = true;
            rookPromote.Text = "Rook";
            rookPromote.UseVisualStyleBackColor = true;
            // 
            // knightPromote
            // 
            knightPromote.AutoSize = true;
            knightPromote.Location = new Point(7, 38);
            knightPromote.Name = "knightPromote";
            knightPromote.Size = new Size(88, 29);
            knightPromote.TabIndex = 1;
            knightPromote.TabStop = true;
            knightPromote.Text = "Knight";
            knightPromote.UseVisualStyleBackColor = true;
            // 
            // queenPromote
            // 
            queenPromote.AutoSize = true;
            queenPromote.Location = new Point(7, 3);
            queenPromote.Name = "queenPromote";
            queenPromote.Size = new Size(89, 29);
            queenPromote.TabIndex = 0;
            queenPromote.TabStop = true;
            queenPromote.Text = "Queen";
            queenPromote.UseVisualStyleBackColor = true;
            // 
            // promoteButton
            // 
            promoteButton.Location = new Point(921, 591);
            promoteButton.Name = "promoteButton";
            promoteButton.Size = new Size(112, 34);
            promoteButton.TabIndex = 22;
            promoteButton.Text = "Promote";
            promoteButton.UseVisualStyleBackColor = true;
            promoteButton.Visible = false;
            promoteButton.Click += promoteButton_Click;
            // 
            // movesView
            // 
            movesView.BackColor = SystemColors.ActiveBorder;
            movesView.Location = new Point(758, 182);
            movesView.Name = "movesView";
            movesView.ReadOnly = true;
            movesView.Size = new Size(212, 294);
            movesView.TabIndex = 23;
            movesView.Text = "";
            // 
            // ChessGame
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(promoteButton);
            Controls.Add(movesView);
            Controls.Add(promotePanel);
            Controls.Add(Player1Label);
            Controls.Add(Player2Label);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(boardPanel);
            Controls.Add(player1Timeleft);
            Controls.Add(player2Timeleft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "ChessGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chess";
            FormClosed += ChessGame_FormClosed;
            Load += ChessGame_Load;
            promotePanel.ResumeLayout(false);
            promotePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer White;
        private TextBox player2Timeleft;
        private TextBox player1Timeleft;
        private System.Windows.Forms.Timer Black;
        private Panel boardPanel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label Player2Label;
        private Label Player1Label;
        private Panel promotePanel;
        private Button promoteButton;
        private RadioButton bishopPromote;
        private RadioButton rookPromote;
        private RadioButton knightPromote;
        private RadioButton queenPromote;
        private RichTextBox movesView;
    }
}