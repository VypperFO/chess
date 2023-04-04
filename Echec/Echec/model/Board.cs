using ChessGame.model.pieces;
using System.Text;

namespace ChessGame.model
{
    public class Board
    {
        private Piece[]? pieces; // tableau contenant le placement des piece dans le plateau
        private string whichTurn; // a qui est le tour de jouer dans la partie
        private Piece[]? TempPieces;

        public Board()
        {
            whichTurn = "w";
            InitPieces();
        }

        /// <summary>
        /// Deplace les piece si leur mouvement sont valide
        /// </summary>
        /// <param name="coords">Coordones du mouvement de la piece</param>
        /// <returns>un string contenant le placement des piece dans le plateau</returns>
        public string PlayMove(Coordinates coords)
        {
            int indexStart = GetIndex(coords.XStart / 100, coords.YStart / 100);
            int indexEnd = GetIndex(coords.XDestination / 100, coords.YDestination / 100);
            TempPieces = new Piece[64];
            for (int i = 0; i < 64; i++)
            {
                TempPieces[i] = pieces[i];
            }
            TempPieces.SetValue(pieces[indexStart], indexEnd);
            TempPieces.SetValue(null, indexStart);
            Piece piece = pieces[indexStart];
            if (piece == null || !CheckTurn(piece) || !piece.PlayMove(indexStart, indexEnd))
            {
                return null;
            }

            if (isChecked() == "echec")
            {
                return null;
            }

            if (isChecked() == "WIN" || isChecked() == "win")
            {
                return isChecked();
            }

            pieces.SetValue(pieces[indexStart], indexEnd);
            pieces.SetValue(null, indexStart);
            ChangeTurn();
            return ToString();
        }

        /// <summary>
        /// Regarde si un des deux jouer est en echec ou en echec et math ou echec et pat
        /// </summary>
        /// <returns>Si la partie est terminer et si oui par qui</returns>
        private string isChecked()
        {
            int possibleMovesBlack;
            possibleMovesBlack = EchecBlack().Count;
            if (possibleMovesBlack == 0 && IsInDangerBlackTemp())
            {
                return "WIN";
            }
            else if (whichTurn == "b")
            {

                if (possibleMovesBlack > 0 && IsinDangerBlack())
                {
                    if (!IsInDangerBlackTemp())
                    {
                        return null;
                    }

                    return "echec";
                }
                if (possibleMovesBlack == 0 && IsInDangerWhiteTemp())
                {
                    return "WIN";
                }

                return null;
            }

            int possibleMovesWhite;
            possibleMovesWhite = EchecWhite().Count;
            if (possibleMovesWhite == 0 && IsInDangerWhiteTemp())
            {
                return "win";
            }
            else if (whichTurn == "w")
            {

                if (possibleMovesWhite > 0 && IsInDangerWhite())
                {
                    if (!IsInDangerWhiteTemp())
                    {
                        return null;
                    }

                    return "echec";
                }
                if (possibleMovesWhite == 0 && IsInDangerWhiteTemp())
                {
                    return "win";
                }

                return null;
            }
            return null;
        }

        /// <summary>
        /// Determine si le roi noire est en danger 
        /// </summary>
        /// <returns>si le roi est en danger</returns>
        public bool IsinDangerBlack()
        {
            List<int> dangerZoneBlack = new();
            List<int> moveRoiWhite = new();

            for (int i = 0; i < pieces.Length - 1; i++)
            {
                Piece checkPieceMove = pieces[i];
                for (int y = 0; y < pieces.Length - 1; y++)
                {
                    if (checkPieceMove != null && (char.IsUpper(checkPieceMove.Type) || checkPieceMove.Type == 'k'))
                    {
                        if (checkPieceMove.PlayMove(i, y))
                        {
                            if (checkPieceMove.Type == 'k')
                            {
                                moveRoiWhite.Add(i);
                            }
                            else
                            {
                                dangerZoneBlack.Add(y);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < moveRoiWhite.Count; i++)
            {
                for (int j = 0; j < dangerZoneBlack.Count; j++)
                {
                    if (moveRoiWhite.ElementAt(i) == dangerZoneBlack.ElementAt(j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Determine si le roi noire est en danger dans le tableau temporaire
        /// </summary>
        /// <returns>si il est en danger</returns>
        public bool IsInDangerBlackTemp()
        {
            List<int> dangerZoneBlack = new();
            List<int> moveRoiWhite = new();

            for (int i = 0; i < TempPieces.Length - 1; i++)
            {
                Piece checkPieceMove = TempPieces[i];
                for (int y = 0; y < TempPieces.Length - 1; y++)
                {
                    if (checkPieceMove != null && (char.IsUpper(checkPieceMove.Type) || checkPieceMove.Type == 'k'))
                    {
                        if (checkPieceMove.PlayMoveTemp(i, y, TempPieces))
                        {
                            if (checkPieceMove.Type == 'k')
                            {
                                moveRoiWhite.Add(i);
                            }
                            else
                            {
                                dangerZoneBlack.Add(y);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < moveRoiWhite.Count; i++)
            {
                for (int j = 0; j < dangerZoneBlack.Count; j++)
                {
                    if (moveRoiWhite.ElementAt(i) == dangerZoneBlack.ElementAt(j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Determine si le roi blanc est en danger 
        /// </summary>
        /// <returns>si le roi est en danger</returns>
        public bool IsInDangerWhite()
        {
            List<int> dangerZoneBlack = new();
            List<int> moveRoiWhite = new();

            for (int i = 0; i < pieces.Length - 1; i++)
            {
                Piece checkPieceMove = pieces[i];
                for (int y = 0; y < pieces.Length - 1; y++)
                {
                    if (checkPieceMove != null && (char.IsLower(checkPieceMove.Type) || checkPieceMove.Type == 'K'))
                    {
                        if (checkPieceMove.PlayMove(i, y))
                        {
                            if (checkPieceMove.Type == 'K')
                            {
                                moveRoiWhite.Add(i);
                            }
                            else
                            {
                                dangerZoneBlack.Add(y);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < moveRoiWhite.Count; i++)
            {
                for (int j = 0; j < dangerZoneBlack.Count; j++)
                {
                    if (moveRoiWhite.ElementAt(i) == dangerZoneBlack.ElementAt(j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Determine si le roi blanc est en danger dans le tableau temporaire
        /// </summary>
        /// <returns>si le roi est en danger</returns>
        public bool IsInDangerWhiteTemp()
        {
            List<int> dangerZoneBlack = new();
            List<int> moveRoiWhite = new();

            for (int i = 0; i < TempPieces.Length - 1; i++)
            {
                Piece checkPieceMove = TempPieces[i];
                for (int y = 0; y < TempPieces.Length - 1; y++)
                {
                    if (checkPieceMove != null && (char.IsLower(checkPieceMove.Type) || checkPieceMove.Type == 'K'))
                    {
                        if (checkPieceMove.PlayMoveTemp(i, y, TempPieces))
                        {
                            if (checkPieceMove.Type == 'K')
                            {
                                moveRoiWhite.Add(i);
                            }
                            else
                            {
                                dangerZoneBlack.Add(y);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < moveRoiWhite.Count; i++)
            {
                for (int j = 0; j < dangerZoneBlack.Count; j++)
                {
                    if (moveRoiWhite.ElementAt(i) == dangerZoneBlack.ElementAt(j))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Creer une liste de tout les mouvement possible du roi blanc
        /// </summary>
        /// <returns>La liste des mouvement</returns>
        private List<int> EchecWhite()
        {
            List<int> dangerZoneBlack = new();
            List<int> moveRoiWhite = new();

            for (int i = 0; i < TempPieces.Length - 1; i++)
            {
                Piece checkPieceMove = TempPieces[i];
                for (int y = 0; y < TempPieces.Length - 1; y++)
                {
                    if (checkPieceMove != null && (char.IsLower(checkPieceMove.Type) || checkPieceMove.Type == 'K'))
                    {
                        if (checkPieceMove.PlayMoveTemp(i, y, TempPieces))
                        {
                            if (checkPieceMove.Type == 'K')
                            {
                                moveRoiWhite.Add(y);
                            }
                            else
                            {
                                dangerZoneBlack.Add(y);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < dangerZoneBlack.Count; i++)
            {
                for (int j = 0; j < moveRoiWhite.Count; j++)
                {
                    if (moveRoiWhite.ElementAt(j) == dangerZoneBlack.ElementAt(i))
                    {
                        moveRoiWhite.RemoveAt(j);
                    }
                }
            }

            return moveRoiWhite;
        }

        /// <summary>
        /// Creer une liste de tout les mouvement possible du roi noire
        /// </summary>
        /// <returns>La liste des mouvement</returns>
        private List<int> EchecBlack()
        {
            List<int> dangerZoneWhite = new();
            List<int> moveRoiBlack = new();

            for (int i = 0; i < TempPieces.Length - 1; i++)
            {
                Piece checkPieceMove = TempPieces[i];
                for (int y = 0; y < TempPieces.Length - 1; y++)
                {
                    if (checkPieceMove != null && (char.IsUpper(checkPieceMove.Type) || checkPieceMove.Type == 'k'))
                    {
                        if (checkPieceMove.PlayMoveTemp(i, y, TempPieces))
                        {
                            if (checkPieceMove.Type == 'k')
                            {
                                moveRoiBlack.Add(y);
                            }
                            else
                            {
                                dangerZoneWhite.Add(y);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < dangerZoneWhite.Count; i++)
            {
                for (int j = 0; j < moveRoiBlack.Count; j++)
                {
                    if (moveRoiBlack.ElementAt(j) == dangerZoneWhite.ElementAt(i))
                    {
                        moveRoiBlack.RemoveAt(j);
                    }
                }
            }

            return moveRoiBlack;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        private bool CheckTurn(Piece piece)
        {
            switch (whichTurn)
            {
                case "w":
                    return char.IsUpper(piece.Type);
                case "b":
                    return char.IsLower(piece.Type);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Change a qui est le tour de jouer
        /// </summary>
        private void ChangeTurn()
        {
            switch (whichTurn)
            {
                case "w":
                    whichTurn = "b";
                    break;
                case "b":
                    whichTurn = "w";
                    break;
                default:
                    whichTurn = "w";
                    break;
            }
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
        /// Regarde si il y a une piece a l'index donner
        /// </summary>
        /// <param name="x">Coordonnes X de la piece</param>
        /// <param name="y">Coordonnes Y de la piece</param>
        /// <returns>si il y a une piece a l'index donner</returns>
        public bool IsPieceAtPosition(int x, int y)
        {
            if (pieces[GetIndex(x, y)] == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Initialise les piece dans leur emplacement de base dans le tableau de piece de la partie
        /// </summary>
        private void InitPieces()
        {
            string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";


            pieces = new Piece[64];
            string[] fields = fen.Split(' ');
            string[] ranks = fields[0].Split('/');

            int index = 0;
            foreach (string rank in ranks)
            {
                foreach (char c in rank)
                {
                    if (char.IsDigit(c))
                    {
                        index += (int)char.GetNumericValue(c);
                    }
                    else
                    {
                        switch (c)
                        {
                            case 'P':
                                pieces[index] = new Pawn(c, pieces);
                                break;
                            case 'N':
                                pieces[index] = new Knight(c, pieces);
                                break;
                            case 'B':
                                pieces[index] = new Bishop(c, pieces);
                                break;
                            case 'R':
                                pieces[index] = new Rook(c, pieces);
                                break;
                            case 'Q':
                                pieces[index] = new Queen(c, pieces);
                                break;
                            case 'K':
                                pieces[index] = new King(c, pieces);
                                break;
                            case 'p':
                                pieces[index] = new Pawn(c, pieces);
                                break;
                            case 'n':
                                pieces[index] = new Knight(c, pieces);
                                break;
                            case 'b':
                                pieces[index] = new Bishop(c, pieces);
                                break;
                            case 'r':
                                pieces[index] = new Rook(c, pieces);
                                break;
                            case 'q':
                                pieces[index] = new Queen(c, pieces);
                                break;
                            case 'k':
                                pieces[index] = new King(c, pieces);
                                break;
                        }
                        index++;
                    }
                }
            }
        }

        /// <summary>
        /// Prend le tableau de piece et le transforme en string formater avec FREN
        /// </summary>
        /// <returns>un string formater avec FREN</returns>
        /// <exception cref="ArgumentException">Permet de faire un string avec un tableau contenant des index vide</exception>
        public override string ToString()
        {
            if (pieces.Length != 64)
            {
                throw new ArgumentException("Invalid number of pieces");
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 64; i += 8)
            {
                int emptyCount = 0;

                for (int j = i; j < i + 8; j++)
                {
                    Piece piece = pieces[j];

                    if (piece == null)
                    {
                        emptyCount++;
                    }
                    else
                    {
                        if (emptyCount > 0)
                        {
                            sb.Append(emptyCount);
                            emptyCount = 0;
                        }

                        sb.Append(piece.Type);
                    }
                }

                if (emptyCount > 0)
                {
                    sb.Append(emptyCount);
                }

                if (i < 56)
                {
                    sb.Append('/');
                }
            }

            sb.Append(' ');
            sb.Append(whichTurn);
            sb.Append(' ');
            sb.Append("KQkq - 0 1");

            return sb.ToString();
        }
    }
}
