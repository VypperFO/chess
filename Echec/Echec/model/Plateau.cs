using Echec.model.pieces;
using System.Text;

namespace Echec.model
{
    public class Plateau
    {
        private Piece[] pieces;

        public Plateau()
        {
            initPieces();
        }
        public Plateau playMove(Coordonnée coords)
        {
            int caca = coords.YStart / 100;
            int caca2 = coords.XStart / 100;
            int indexStart = getIndexChange(caca2, caca);
            int indexEnd = getIndexChange(coords.XDestination / 100, coords.YDestination / 100);

            pieces[indexEnd] = pieces[indexStart];
            pieces[indexStart] = null;
            return this;
        }

        private int getIndexChange(int x, int y)
        {
            return ((y)) * 8 + x;
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

            sb.Append(" w KQkq - 0 1");

            return sb.ToString();
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
                        pieces[index] = new Piece(c);
                        index++;
                    }
                }
            }
        }
    }
}
