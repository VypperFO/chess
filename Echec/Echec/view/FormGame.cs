using ChessGame.Properties;

namespace ChessGame.view
{
    public partial class FormGame : Form
    {
        private int clickCounter = 0; // counteur de click de la vue
        private Point start, end; // cordonne des click
        private Chess chess; // controlleur de la partie 
        private string[] pieces = new string[64]; // tableau contenant les piece de la partie

        public int Id { get; set; } // id du form de la partie

        public FormGame(Chess chess)
        {
            this.chess = chess;
            InitializeComponent();
        }

        /// <summary>
        /// Calcule les cordonnes des click fait par l'utilisateur et envoie au controlleur de jouer un coup avec les cordoones.
        /// </summary>
        /// <param name="e">Event listener</param>
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

        /// <summary>
        ///  Envoie les coordonne du mouvement au controlleur
        /// </summary>
        /// <param name="xStart">cordonnees de depart X du coup</param>
        /// <param name="yStart">cordonnees de depart Y du coup</param>
        /// <param name="xEnd">cordonnees de fin X du coup</param>
        /// <param name="yEnd">cordonnees de fin Y du coup</param>
        private void PlayMove(int xStart, int yStart, int xEnd, int yEnd)
        {
            chess.PlayMove(xStart, yStart, xEnd, yEnd, this);
        }

        /// <summary>
        /// Transforme le string en piece dans le form
        /// </summary>
        /// <param name="fen">string du contenu du plateau formater en FEN</param>
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
            }
            else if (parts[1] == "b")
            {
                labWhichTurn.Text = "Noir";
            }


            GC.Collect();
        }

        /// <summary>
        /// Dessine les piece dans le Form
        /// </summary>
        /// <param name="x">Coordones X de la piece</param>
        /// <param name="y">Coordones Y de la piece</param>
        /// <param name="imageName">Bitmap de la piece</param>
        /// <param name="bmp">contient un image de la piece</param>
        private void DrawPiece(int x, int y, Bitmap imageName, Bitmap bmp)
        {
            Pen pen = new(Color.Black, -5);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(imageName, new Rectangle(x, y, (chessboard.Height / 8), (chessboard.Width / 8)));
            g.Dispose();
        }

        /// <summary>
        /// Vide le board de la partie
        /// </summary>
        private void ClearBoard()
        {
            chessboard.Image.Dispose();
            chessboard.Image = Resources.chessboard;
        }

        /// <summary>
        /// Event listener qui ecoute quand un click est fait
        /// </summary>
        /// <param name="sender">Qui a fait le click</param>
        /// <param name="e">Event</param>
        private void chessboard_MouseDown(object sender, MouseEventArgs e)
        {
            ClickSelection(e);
        }

        /// <summary>
        /// Regarde si un index du tableau pieces est vide
        /// </summary>
        /// <param name="coords">index dans le tableau</param>
        /// <returns>si le tableau est vide ou non a cette index</returns>
        private bool IsEmpty(Point coords)
        {
            int index = GetIndex(coords.X / 100, coords.Y / 100);

            if (pieces[index] == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Calcule l'index d'une piece dans un tableau, a l'aide de ces cordonée sur le plateau
        /// </summary>
        /// <param name="x">Coordonnes X de la piece</param>
        /// <param name="y">Coordonnes Y de la piece</param>
        /// <returns> l'index d'une piece dans un tableau</returns>
        private int GetIndex(int x, int y)
        {
            return y * 8 + x;
        }

        /// <summary>
        /// Confirme au joueurs qui a gagner la partie
        /// </summary>
        /// <param name="joueur1">nom du joueur qui a gagner la partie</param>
        public void gameWon(string joueur1)
        {
            string message = joueur1 + " a gagner la partie";
            string title = "Partie Terminer";
            MessageBoxButtons button = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, button);
            if (result == DialogResult.OK)
            {
                Close();
            }
        }

        /// <summary>
        /// Confirme au joueurs que la partie a terminer en Null
        /// </summary>
        public void gameNull()
        {
            string message = "La partie est null";
            string title = "Partie Terminer";
            MessageBoxButtons button = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, button);
            if (result == DialogResult.OK)
            {
                Close();
            }
        }

    }
}
