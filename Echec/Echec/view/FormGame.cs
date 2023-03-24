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
        private int clickCounter = 0;
        private Point start;
        private Point end;
        private Echec chess;
        private int id;

        public int Id
        {
            get { return id; }
        }

        public FormGame(Echec chess,int id)
        {
            this.chess = chess;
            this.id = id;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            clickSelection(e);
        }

        private void clickSelection(EventArgs e)
        {
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

                // Does the move after second click
                playMove(start.X, start.Y, end.X, end.Y);
                
                clickCounter = 0;
            }
        }

        private void playMove(int xStart, int yStart, int xEnd, int yEnd)
        {
            chess.playMove(xStart, yStart, xEnd, yEnd, this);
        }


        public void parseFen(string fen)
        {
            clear();
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
                            drawPiece(x, y, Resources.wpawn);
                            break;
                        case 'N':
                            drawPiece(x, y, Resources.wknight);
                            break;
                        case 'B':
                            drawPiece(x, y, Resources.wbishop);
                            break;
                        case 'R':
                            drawPiece(x, y, Resources.wrook);
                            break;
                        case 'Q':
                            drawPiece(x, y, Resources.wqueen);
                            break;
                        case 'K':
                            drawPiece(x, y, Resources.wking);
                            break;
                        case 'p':
                            drawPiece(x, y, Resources.bpawn);
                            break;
                        case 'n':
                            drawPiece(x, y, Resources.bknight);
                            break;
                        case 'b':
                            drawPiece(x, y, Resources.bbishop);
                            break;
                        case 'r':
                            drawPiece(x, y, Resources.brook);
                            break;
                        case 'q':
                            drawPiece(x, y, Resources.bqueen);
                            break;
                        case 'k':
                            drawPiece(x, y, Resources.bking);
                            break;
                    }
                }
            }
        }

        private void drawPiece(int x, int y, Bitmap imageName)
        {
            Bitmap bmp = new Bitmap(chessboard.Image);

            Graphics g = Graphics.FromImage(bmp);

            Bitmap piece = new Bitmap(imageName);

            g.DrawImage(piece, new Rectangle(x, y, (chessboard.Height / 8), (chessboard.Width / 8)));

            chessboard.Image = bmp;
        }

        private void clear()
        {
            chessboard.Image.Dispose();
            chessboard.Image = global::Echec.Properties.Resources.chessboard;
        }

        private void Form1_load(object sender, EventArgs e)
        {
            parseFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
        }
    }
}
