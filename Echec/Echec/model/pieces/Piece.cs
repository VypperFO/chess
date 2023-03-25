namespace Echec.model.pieces
{
    public class Piece
    {
        public Piece[] Pieces { get; set; }
        public char Type { get; set; }

        public Piece() { }

        public Piece(char type, Piece[] pieces)
        {
            Type = type;
            Pieces = pieces;
        }

        public virtual bool playMove(int startIndex, int endIndex) {
            return false;
        }
    }
}
