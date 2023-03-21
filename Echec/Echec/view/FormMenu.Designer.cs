namespace Echec.view
{
    partial class FormMenu
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
            this.btnNewGame = new System.Windows.Forms.Button();
            this.labPlayerOne = new System.Windows.Forms.Label();
            this.labPlayerTwo = new System.Windows.Forms.Label();
            this.txbPlayerOne = new System.Windows.Forms.TextBox();
            this.txbPlayerTwo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(138, 242);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(101, 23);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "Commencer";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // labPlayerOne
            // 
            this.labPlayerOne.AutoSize = true;
            this.labPlayerOne.Location = new System.Drawing.Point(85, 104);
            this.labPlayerOne.Name = "labPlayerOne";
            this.labPlayerOne.Size = new System.Drawing.Size(51, 15);
            this.labPlayerOne.TabIndex = 1;
            this.labPlayerOne.Text = "Joueur 1";
            // 
            // labPlayerTwo
            // 
            this.labPlayerTwo.AutoSize = true;
            this.labPlayerTwo.Location = new System.Drawing.Point(85, 153);
            this.labPlayerTwo.Name = "labPlayerTwo";
            this.labPlayerTwo.Size = new System.Drawing.Size(51, 15);
            this.labPlayerTwo.TabIndex = 2;
            this.labPlayerTwo.Text = "Joueur 2";
            // 
            // txbPlayerOne
            // 
            this.txbPlayerOne.Location = new System.Drawing.Point(189, 101);
            this.txbPlayerOne.Name = "txbPlayerOne";
            this.txbPlayerOne.Size = new System.Drawing.Size(100, 23);
            this.txbPlayerOne.TabIndex = 3;
            // 
            // txbPlayerTwo
            // 
            this.txbPlayerTwo.Location = new System.Drawing.Point(189, 150);
            this.txbPlayerTwo.Name = "txbPlayerTwo";
            this.txbPlayerTwo.Size = new System.Drawing.Size(100, 23);
            this.txbPlayerTwo.TabIndex = 4;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 355);
            this.Controls.Add(this.txbPlayerTwo);
            this.Controls.Add(this.txbPlayerOne);
            this.Controls.Add(this.labPlayerTwo);
            this.Controls.Add(this.labPlayerOne);
            this.Controls.Add(this.btnNewGame);
            this.Name = "FormMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnNewGame;
        private Label labPlayerOne;
        private Label labPlayerTwo;
        private TextBox txbPlayerOne;
        private TextBox txbPlayerTwo;
    }
}