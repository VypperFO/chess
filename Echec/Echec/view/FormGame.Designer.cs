namespace Echec.view
{
    partial class FormGame
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
            chessboard = new PictureBox();
            labWhichTurn = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)chessboard).BeginInit();
            SuspendLayout();
            // 
            // chessboard
            // 
            chessboard.BackgroundImageLayout = ImageLayout.Center;
            chessboard.Image = Properties.Resources.chessboard;
            chessboard.Location = new Point(13, 12);
            chessboard.Name = "chessboard";
            chessboard.Size = new Size(800, 800);
            chessboard.TabIndex = 0;
            chessboard.TabStop = false;
            chessboard.Click += chessboard_Click;
            chessboard.MouseDown += chessboard_MouseDown;
            // 
            // labWhichTurn
            // 
            labWhichTurn.AutoSize = true;
            labWhichTurn.Location = new Point(830, 25);
            labWhichTurn.Name = "labWhichTurn";
            labWhichTurn.Size = new Size(36, 15);
            labWhichTurn.TabIndex = 1;
            labWhichTurn.Text = "Blanc";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(830, 56);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 2;
            label1.Text = "Blanc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(830, 89);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 3;
            label2.Text = "Blanc";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(788, 25);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "Tour :";
            // 
            // FormGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 961);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labWhichTurn);
            Controls.Add(chessboard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormGame";
            Text = "Game";
            Load += FormGame_Load;
            ((System.ComponentModel.ISupportInitialize)chessboard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox chessboard;
        private Label labWhichTurn;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}