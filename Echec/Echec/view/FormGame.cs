using Echec.Properties;
using System.Drawing;

namespace Echec.view
{
    public partial class FormGame : Form
    {
        private int clickCounter = 0;
        private Point start, end;
        private Echec chess;
        private string[] pieces = new string[64];

        public int Id { get; set; }

        public FormGame(Echec chess)
        {
            this.chess = chess;
            InitializeComponent();
        }

        private void ClickSelection(EventArgs e)
        {
            clickCounter++;

            if (clickCounter == 1)
            {
                MouseEventArgs meStart = (MouseEventArgs)e;
                Point coordinates = meStart.Location;
                start = coordinates;

                if (IsEmpty(start))
                {
                    clickCounter = 0;
                    return;
                }

                label2.Visible = false;
                label1.Text = start.ToString();
            }

            if (clickCounter == 2)
            {
                MouseEventArgs meDestination = (MouseEventArgs)e;
                Point coordinates2 = meDestination.Location;
                end = coordinates2;

                label2.Visible = true;
                label2.Text = end.ToString();

                PlayMove(start.X, start.Y, end.X, end.Y);

                clickCounter = 0;
            }
        }

        private void PlayMove(int xStart, int yStart, int xEnd, int yEnd)
        {
            chess.PlayMove(xStart, yStart, xEnd, yEnd, this);
        }


        public void ParseFen(string fen)
        {
            ClearBoard();
            Bitmap bmp = new Bitmap(chessboard.Image);

            string[] parts = fen.Split(' ');
            string[] rows = parts[0].Split('/');

            int row = 0;
            int col = 0;
            int index = 0;

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    char c = rows[i][j];
                    int x = col * (chessboard.Width / 8);
                    int y = row * (chessboard.Height / 8);

                    if (char.IsDigit(c))
                    {
                        col += int.Parse(c.ToString());
                        index += int.Parse(c.ToString());
                    }
                    else if (char.IsLetter(c))
                    {
                        col++;
                        pieces[index] = Convert.ToString(c);
                        index++;
                    }


                    switch (c)
                    {
                        case 'P':
                            DrawPiece(x, y, Resources.wpawn, bmp);
                            break;
                        case 'N':
                            DrawPiece(x, y, Resources.wknight, bmp);
                            break;
                        case 'B':
                            DrawPiece(x, y, Resources.wbishop, bmp);
                            break;
                        case 'R':
                            DrawPiece(x, y, Resources.wrook, bmp);
                            break;
                        case 'Q':
                            DrawPiece(x, y, Resources.wqueen, bmp);
                            break;
                        case 'K':
                            DrawPiece(x, y, Resources.wking, bmp);
                            break;
                        case 'p':
                            DrawPiece(x, y, Resources.bpawn, bmp);
                            break;
                        case 'n':
                            DrawPiece(x, y, Resources.bknight, bmp);
                            break;
                        case 'b':
                            DrawPiece(x, y, Resources.bbishop, bmp);
                            break;
                        case 'r':
                            DrawPiece(x, y, Resources.brook, bmp);
                            break;
                        case 'q':
                            DrawPiece(x, y, Resources.bqueen, bmp);
                            break;
                        case 'k':
                            DrawPiece(x, y, Resources.bking, bmp);
                            break;
                    }
                }
                row++;
                col = 0;
            }
            chessboard.Image = bmp;
            if (parts[1] == "w")
            {
                labWhichTurn.Text = "Blanc";
            } else if (parts[1] == "b")
            {
                labWhichTurn.Text = "Noir";
            }
  

            GC.Collect();
        }

        private void DrawPiece(int x, int y, Bitmap imageName, Bitmap bmp)
        {
            Pen pen = new(Color.Black, -5);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(imageName, new Rectangle(x, y, (chessboard.Height / 8), (chessboard.Width / 8)));
            g.Dispose();
        }

        private static void DrawSquare(int x, int y, Bitmap bmp)
        {
            Pen pen = new(Color.White, 2);
            Graphics formGraphics;
            formGraphics = Graphics.FromImage(bmp);
            formGraphics.DrawRectangle(pen, new Rectangle(500, 500, 100, 100));
            pen.Dispose();
            formGraphics.Dispose();
        }

        private void ClearBoard()
        {
            chessboard.Image.Dispose();
            chessboard.Image = Resources.chessboard;
        }

        private void chessboard_MouseDown(object sender, MouseEventArgs e)
        {
            ClickSelection(e);
        }

        private bool IsEmpty(Point coords)
        {
            int index = GetIndex(coords.X / 100, coords.Y / 100);

            if (pieces[index] == null)
            {
                return true;
            }
            return false;
        }

        private int GetIndex(int x, int y)
        {
            return y * 8 + x;
        }
    }
}
