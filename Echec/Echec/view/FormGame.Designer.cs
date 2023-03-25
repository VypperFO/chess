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
            ((System.ComponentModel.ISupportInitialize)chessboard).BeginInit();
            SuspendLayout();
            // 
            // chessboard
            // 
            chessboard.Image = Properties.Resources.chessboard;
            chessboard.Location = new Point(14, 16);
            chessboard.Margin = new Padding(3, 4, 3, 4);
            chessboard.Name = "chessboard";
            chessboard.Size = new Size(800, 800);
            chessboard.TabIndex = 0;
            chessboard.TabStop = false;
            chessboard.Click += pictureBox1_Click;
            // 
            // labWhichTurn
            // 
            labWhichTurn.AutoSize = true;
            labWhichTurn.Location = new Point(949, 33);
            labWhichTurn.Name = "labWhichTurn";
            labWhichTurn.Size = new Size(45, 20);
            labWhichTurn.TabIndex = 1;
            labWhichTurn.Text = "Blanc";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(949, 75);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 2;
            label1.Text = "Blanc";
            // 
            // FormGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 1055);
            Controls.Add(label1);
            Controls.Add(labWhichTurn);
            Controls.Add(chessboard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormGame";
            Text = "Game";
            ((System.ComponentModel.ISupportInitialize)chessboard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox chessboard;
        private Label labWhichTurn;
        private Label label1;
    }
}