using Echec.model.pieces;
using Echec.Properties;
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
        public Plateau? playMove(Coordonnée coords)
        {
            int indexStart = getIndexChange(coords.XStart / 100, coords.YStart / 100);
            int indexEnd = getIndexChange(coords.XDestination / 100, coords.YDestination / 100);

            Piece piece = pieces[indexStart];

            if(piece == null || !checkTurn(piece) || !piece.PlayMove(indexStart, indexEnd))
            {
                return null;
            }

            changeTurn();
            pieces.SetValue(pieces[indexStart], indexEnd);
            pieces.SetValue(null, indexStart);
            return this;
        }

        private bool checkTurn(Piece piece)
        {
            switch (whichTurn) {
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
            switch(whichTurn)
            {
                case "w":
                    whichTurn= "b";
                    break;
                case "b":
                    whichTurn= "w";
                    break;
                default:
                    whichTurn= "w";
                    break;
            }
        }

        private int getIndexChange(int x, int y)
        {
            return y * 8 + x;
        }

        public bool IsPieceAtPosition(int x, int y)
        {
            if (pieces[getIndexChange(x, y)] == null)
            {
                return false;
            }
            return true;
        }

        private void initPieces()
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
