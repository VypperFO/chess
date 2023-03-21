using Echec.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Echec.view
{
    public partial class FormGame : Form
    {
        int clickCounter = 0;
        public FormGame()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Point start;
            Point end;
            clickCounter++;

            if (clickCounter == 1)
            {
                label1.Text = "";
            }

            if (clickCounter == 1)
            {
                MouseEventArgs meStart = (MouseEventArgs)e;
                Point coordinates = meStart.Location;
                start = coordinates;
                labWhichTurn.Text = start.ToString();
            }

            if (clickCounter == 2)
            {
                MouseEventArgs meDestination = (MouseEventArgs)e;
                Point coordinates2 = meDestination.Location;
                end = coordinates2;
                label1.Text = end.ToString();
                clickCounter = 0;
            }


        }


        private void parseFen(string fen)
        {
            string[] parts = fen.Split(' ');

            string[] rows = parts[0].Split('/');

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    char c = rows[i][j];
                    int x = j * (chessboard.Width / 8);
                    int y = (7 - i) * (chessboard.Height / 8);

                    switch (c)
                    {
                        case 'P':
                            DrawPiece(x, y, Resources.wpawn);
                            break;
                        case 'N':
                            DrawPiece(x, y, Resources.wknight);
                            break;
                        case 'B':
                            DrawPiece(x, y, Resources.wbishop);
                            break;
                        case 'R':
                            DrawPiece(x, y, Resources.wrook);
                            break;
                        case 'Q':
                            DrawPiece(x, y, Resources.wqueen);
                            break;
                        case 'K':
                            DrawPiece(x, y, Resources.wking);
                            break;
                        case 'p':
                            DrawPiece(x, y, Resources.bpawn);
                            break;
                        case 'n':
                            DrawPiece(x, y, Resources.bknight);
                            break;
                        case 'b':
                            DrawPiece(x, y, Resources.bbishop);
                            break;
                        case 'r':
                            DrawPiece(x, y, Resources.brook);
                            break;
                        case 'q':
                            DrawPiece(x, y, Resources.bqueen);
                            break;
                        case 'k':
                            DrawPiece(x, y, Resources.bking);
                            break;
                    }
                }
            }
        }

        private void DrawPiece(int x, int y, Bitmap imageName)
        {
            // Create a new Bitmap object from the PictureBox control's Image property
            Bitmap bmp = new Bitmap(chessboard.Image);

            // Create a new Graphics object from the bitmap
            Graphics g = Graphics.FromImage(bmp);

            // Load the image for the chess piece
            Bitmap piece = new Bitmap(imageName);

            // Draw the image on the appropriate square
            g.DrawImage(piece, new Rectangle(x, y, (chessboard.Height / 8), (chessboard.Width / 8)));
            labWhichTurn.Text = (new Rectangle(x, y, (chessboard.Height / 2), (chessboard.Width / 2))).ToString();

            // Update the PictureBox control's Image property with the new bitmap
            chessboard.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            parseFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");

        }
    }
}
