using Echec.model.pieces;
using System.Text;

namespace Echec.model
{
    public class Plateau
    {
        private Piece[]? pieces;
        private string whichTurn;

        public Plateau()
        {
            whichTurn = "w";
            initPieces();
        }
        public string playMove(Coordonnée coords)
        {
            int indexStart = getIndex(coords.XStart / 100, coords.YStart / 100);
            int indexEnd = getIndex(coords.XDestination / 100, coords.YDestination / 100);

            Piece piece = pieces[indexStart];

            if (piece == null || !checkTurn(piece) || !piece.PlayMove(indexStart, indexEnd))
            {
                return null;
            }

            if (isChecked() == "echec")
            {
                return null;
            }

            if(isChecked() == "WIN" || isChecked() == "win")
            {
                return isChecked();
            }

            Console.WriteLine(isChecked());

            pieces.SetValue(pieces[indexStart], indexEnd);
            pieces.SetValue(null, indexStart);
            /*echecWhite();
            echecBlack();*/
            changeTurn();
            return this.ToString();
        }

        private string isChecked()
        {
            int possibleMoves;
            if (whichTurn.Equals("w"))
            {
                possibleMoves = echecBlack().Count;
                if (possibleMoves == 0)
                {
                    return "WIN";
                }
            }

            if (whichTurn.Equals("b"))
            {
                possibleMoves = echecWhite().Count;
                if (possibleMoves == 0)
                {
                    return "win";
                }
            }
            return null;
        }

        private List<int> echecWhite()
        {
            List<int> dangerZoneBlack = new();
            List<int> moveRoiWhite = new();

            // Add all possible ending index
            for (int i = 0; i < pieces.Length - 1; i++)
            {
                Piece checkPieceMove = pieces[i];
                for (int y = 0; y < pieces.Length - 1; y++)
                {
                    if (checkPieceMove != null && (Char.IsLower(checkPieceMove.Type) || checkPieceMove.Type == 'K'))
                    {
                        if (checkPieceMove.PlayMove(i, y))
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
            Console.WriteLine("White");
            for (int i = 0; i < moveRoiWhite.Count; i++)
            {
                Console.Write(moveRoiWhite.ElementAt(i) + ", ");
            }
            Console.WriteLine("");
            return moveRoiWhite;
        }

        private List<int> echecBlack()
        {
            List<int> dangerZoneWhite = new();
            List<int> moveRoiBlack = new();

            // Add all possible ending index
            for (int i = 0; i < pieces.Length - 1; i++)
            {
                Piece checkPieceMove = pieces[i];
                for (int y = 0; y < pieces.Length - 1; y++)
                {
                    if (checkPieceMove != null && (Char.IsUpper(checkPieceMove.Type) || checkPieceMove.Type == 'k'))
                    {
                        if (checkPieceMove.PlayMove(i, y))
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

            Console.WriteLine("Black");
            for (int i = 0; i < moveRoiBlack.Count; i++)
            {
                Console.Write(moveRoiBlack.ElementAt(i) + ", ");
            }
            Console.WriteLine("");
            return moveRoiBlack;
        }


       


        private bool checkTurn(Piece piece)
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

        private void changeTurn()
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

        private int getIndex(int x, int y)
        {
            return y * 8 + x;
        }

        public bool IsPieceAtPosition(int x, int y)
        {
            if (pieces[getIndex(x, y)] == null)
            {
                return false;
            }
            return true;
        }

        private void initPieces()
        {
            //string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            string fen = "k6p/7R/8/1Q6/8/8/8/K6P - 0 1";

            pieces = new Piece[64];
            string[] fields = fen.Split(' ');
            string[] ranks = fields[0].Split('/');

            int index = 0;
            foreach (string rank in ranks)
            {
                foreach (char c in rank)
                {
                    if (Char.IsDigit(c))
                    {
                        index += (int)Char.GetNumericValue(c);
                    }
                    else
                    {
                        switch (c)
                        {
                            case 'P':
                                pieces[index] = new Pion(c, pieces);
                                break;
                            case 'N':
                                pieces[index] = new Cavalier(c, pieces);
                                break;
                            case 'B':
                                pieces[index] = new Fou(c, pieces);
                                break;
                            case 'R':
                                pieces[index] = new Tour(c, pieces);
                                break;
                            case 'Q':
                                pieces[index] = new Reine(c, pieces);
                                break;
                            case 'K':
                                pieces[index] = new Roi(c, pieces);
                                break;
                            case 'p':
                                pieces[index] = new Pion(c, pieces);
                                break;
                            case 'n':
                                pieces[index] = new Cavalier(c, pieces);
                                break;
                            case 'b':
                                pieces[index] = new Fou(c, pieces);
                                break;
                            case 'r':
                                pieces[index] = new Tour(c, pieces);
                                break;
                            case 'q':
                                pieces[index] = new Reine(c, pieces);
                                break;
                            case 'k':
                                pieces[index] = new Roi(c, pieces);
                                break;
                        }
                        index++;
                    }
                }
            }
        }
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
