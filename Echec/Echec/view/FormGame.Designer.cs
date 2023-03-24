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
            this.chessboard = new System.Windows.Forms.PictureBox();
            this.labWhichTurn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chessboard)).BeginInit();
            this.SuspendLayout();
            // 
            // chessboard
            // 
            this.chessboard.Image = global::Echec.Properties.Resources.chessboard;
            this.chessboard.Location = new System.Drawing.Point(17, 20);
            this.chessboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chessboard.Name = "chessboard";
            this.chessboard.Size = new System.Drawing.Size(800, 800);
            this.chessboard.TabIndex = 0;
            this.chessboard.TabStop = false;
            this.chessboard.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labWhichTurn
            // 
            this.labWhichTurn.AutoSize = true;
            this.labWhichTurn.Location = new System.Drawing.Point(883, 20);
            this.labWhichTurn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labWhichTurn.Name = "labWhichTurn";
            this.labWhichTurn.Size = new System.Drawing.Size(53, 25);
            this.labWhichTurn.TabIndex = 1;
            this.labWhichTurn.Text = "Blanc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(883, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Blanc";
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 1032);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labWhichTurn);
            this.Controls.Add(this.chessboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormGame";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Form1_load);
            ((System.ComponentModel.ISupportInitialize)(this.chessboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox chessboard;
        private Label labWhichTurn;
        private Label label1;
    }
}