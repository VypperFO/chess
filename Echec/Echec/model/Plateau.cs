using Echec.model.pieces;
using System.Text;

namespace Echec.model
{
    public class Plateau
    {
        public string playMove(Coordonnée coords, string fen)
        {

            return "";
        }   
        
        public Piece[] convertFenPiece(string fen)
        {
            // Create a 2D array to represent the current board state
            Piece[] pieces = new Piece[32];
            List<string> fenParts = fen.Split(' ').ToList();

            // Populate the board array based on the FEN string
            string[] ranks = fenParts[0].Split('/');
            for (int rank = 0; rank < 8; rank++)
            {
                for (int file = 0; file < 8; file++)
                {
                    char c = ranks[7 - rank][file];
                    if (char.IsDigit(c))
                    {
                        file += int.Parse(c.ToString()) - 1;
                        continue;
                    }

                    Piece piece = new Piece();
                    piece.IsWhite = char.IsUpper(c);
                    piece.Type = char.ToUpper(c);
                    pieces[rank * 32 + file] = piece;
                }
            }

            return pieces;
        }

        // NE MARCHE PAS
        public string GetFenString(int xStart, int yStart, int xEnd, int yEnd, string currentFen)
        {


            // Make the specified move on the board
            Piece pieceToMove = board[xStart, yStart];
            board[xStart, yStart] = null;
            board[xEnd, yEnd] = pieceToMove;

            // Build the FEN string from the updated board state
            StringBuilder fenBuilder = new StringBuilder();
            for (int rank = 7; rank >= 0; rank--)
            {
                int emptySquares = 0;
                for (int file = 0; file < 8; file++)
                {
                    Piece piece = board[file, rank];
                    if (piece == null)
                    {
                        emptySquares++;
                    }
                    else
                    {
                        if (emptySquares > 0)
                        {
                            fenBuilder.Append(emptySquares);
                            emptySquares = 0;
                        }
                        fenBuilder.Append(piece.IsWhite ? char.ToLower(piece.Type) : char.ToUpper(piece.Type));
                    }
                }
                if (emptySquares > 0)
                {
                    fenBuilder.Append(emptySquares);
                }
                if (rank > 0)
                {
                    fenBuilder.Append("/");
                }
            }

            // Add the remaining FEN parts to the string and return it
            fenParts[0] = fenBuilder.ToString();
            return string.Join(" ", fenParts);
        }
    }
}
