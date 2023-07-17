namespace ChessWinform
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            panel1 = new Panel();
            twoMinsButton = new Button();
            fiveMinsButton = new Button();
            tenMinsButton = new Button();
            thirtyMinsButton = new Button();
            audioButton = new PictureBox();
            pictureBox2 = new PictureBox();
            aboutGameButton = new PictureBox();
            noAudioButton = new PictureBox();
            modePanel = new Panel();
            specialModeButton = new Button();
            normalModeButton = new Button();
            historyButton = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)audioButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)aboutGameButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)noAudioButton).BeginInit();
            modePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)historyButton).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(twoMinsButton);
            panel1.Controls.Add(fiveMinsButton);
            panel1.Controls.Add(tenMinsButton);
            panel1.Controls.Add(thirtyMinsButton);
            panel1.Location = new Point(312, 243);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(387, 422);
            panel1.TabIndex = 1;
            panel1.Visible = false;
            // 
            // twoMinsButton
            // 
            twoMinsButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            twoMinsButton.Location = new Point(104, 320);
            twoMinsButton.Margin = new Padding(4, 5, 4, 5);
            twoMinsButton.Name = "twoMinsButton";
            twoMinsButton.Size = new Size(181, 67);
            twoMinsButton.TabIndex = 3;
            twoMinsButton.Text = "2 mins";
            twoMinsButton.UseVisualStyleBackColor = true;
            twoMinsButton.Click += twoMinsButton_Click;
            // 
            // fiveMinsButton
            // 
            fiveMinsButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            fiveMinsButton.Location = new Point(104, 223);
            fiveMinsButton.Margin = new Padding(4, 5, 4, 5);
            fiveMinsButton.Name = "fiveMinsButton";
            fiveMinsButton.Size = new Size(181, 67);
            fiveMinsButton.TabIndex = 2;
            fiveMinsButton.Text = "5 mins";
            fiveMinsButton.UseVisualStyleBackColor = true;
            fiveMinsButton.Click += fiveMinsButton_Click;
            // 
            // tenMinsButton
            // 
            tenMinsButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            tenMinsButton.Location = new Point(104, 127);
            tenMinsButton.Margin = new Padding(4, 5, 4, 5);
            tenMinsButton.Name = "tenMinsButton";
            tenMinsButton.Size = new Size(181, 67);
            tenMinsButton.TabIndex = 1;
            tenMinsButton.Text = "10 mins ";
            tenMinsButton.UseVisualStyleBackColor = true;
            tenMinsButton.Click += tenMinsButton_Click;
            // 
            // thirtyMinsButton
            // 
            thirtyMinsButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            thirtyMinsButton.Location = new Point(104, 32);
            thirtyMinsButton.Margin = new Padding(4, 5, 4, 5);
            thirtyMinsButton.Name = "thirtyMinsButton";
            thirtyMinsButton.Size = new Size(181, 67);
            thirtyMinsButton.TabIndex = 0;
            thirtyMinsButton.Text = "30 mins ";
            thirtyMinsButton.UseVisualStyleBackColor = true;
            thirtyMinsButton.Click += thirtyMinsButton_Click;
            // 
            // audioButton
            // 
            audioButton.BackColor = Color.Transparent;
            audioButton.Cursor = Cursors.Hand;
            audioButton.Image = Properties.Resources.AudioButton;
            audioButton.Location = new Point(766, 577);
            audioButton.Name = "audioButton";
            audioButton.Size = new Size(70, 70);
            audioButton.TabIndex = 2;
            audioButton.TabStop = false;
            audioButton.Click += audioButton_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.Chess_Logo;
            pictureBox2.Location = new Point(700, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(444, 400);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // aboutGameButton
            // 
            aboutGameButton.BackColor = Color.Transparent;
            aboutGameButton.Cursor = Cursors.Hand;
            aboutGameButton.Image = Properties.Resources.Black_question_mark;
            aboutGameButton.Location = new Point(644, 673);
            aboutGameButton.Name = "aboutGameButton";
            aboutGameButton.Size = new Size(70, 70);
            aboutGameButton.TabIndex = 4;
            aboutGameButton.TabStop = false;
            // 
            // noAudioButton
            // 
            noAudioButton.BackColor = Color.Transparent;
            noAudioButton.Cursor = Cursors.Hand;
            noAudioButton.Image = Properties.Resources.NoAudioButton;
            noAudioButton.Location = new Point(766, 577);
            noAudioButton.Name = "noAudioButton";
            noAudioButton.Size = new Size(70, 70);
            noAudioButton.TabIndex = 5;
            noAudioButton.TabStop = false;
            noAudioButton.Visible = false;
            noAudioButton.Click += noAudioButton_Click;
            // 
            // modePanel
            // 
            modePanel.BackColor = Color.Transparent;
            modePanel.Controls.Add(specialModeButton);
            modePanel.Controls.Add(normalModeButton);
            modePanel.Location = new Point(316, 238);
            modePanel.Margin = new Padding(4, 5, 4, 5);
            modePanel.Name = "modePanel";
            modePanel.Size = new Size(387, 422);
            modePanel.TabIndex = 6;
            // 
            // specialModeButton
            // 
            specialModeButton.Enabled = false;
            specialModeButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            specialModeButton.Location = new Point(127, 256);
            specialModeButton.Margin = new Padding(4, 5, 4, 5);
            specialModeButton.Name = "specialModeButton";
            specialModeButton.Size = new Size(181, 67);
            specialModeButton.TabIndex = 2;
            specialModeButton.Text = "Special";
            specialModeButton.UseVisualStyleBackColor = true;
            specialModeButton.Click += specialModeButton_Click;
            // 
            // normalModeButton
            // 
            normalModeButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            normalModeButton.Location = new Point(127, 141);
            normalModeButton.Margin = new Padding(4, 5, 4, 5);
            normalModeButton.Name = "normalModeButton";
            normalModeButton.Size = new Size(181, 67);
            normalModeButton.TabIndex = 1;
            normalModeButton.Text = "Normal";
            normalModeButton.UseVisualStyleBackColor = true;
            normalModeButton.Click += normalModeButton_Click;
            // 
            // historyButton
            // 
            historyButton.BackColor = Color.Transparent;
            historyButton.Cursor = Cursors.Hand;
            historyButton.Image = Properties.Resources.history;
            historyButton.Location = new Point(316, 673);
            historyButton.Name = "historyButton";
            historyButton.Size = new Size(70, 70);
            historyButton.TabIndex = 7;
            historyButton.TabStop = false;
            historyButton.Click += historyButton_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._360_F_565995516_f63OOWisw9DFMUamposi5puuHQPWtgP9;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1143, 750);
            Controls.Add(historyButton);
            Controls.Add(modePanel);
            Controls.Add(noAudioButton);
            Controls.Add(aboutGameButton);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(audioButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chess";
            Load += Menu_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)audioButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)aboutGameButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)noAudioButton).EndInit();
            modePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)historyButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Button thirtyMinsButton;
        private Button tenMinsButton;
        private Button fiveMinsButton;
        private Button twoMinsButton;
        private PictureBox audioButton;
        private PictureBox pictureBox2;
        private PictureBox aboutGameButton;
        private PictureBox noAudioButton;
        private Panel modePanel;
        private Button specialModeButton;
        private Button normalModeButton;
        private PictureBox historyButton;
    }
}