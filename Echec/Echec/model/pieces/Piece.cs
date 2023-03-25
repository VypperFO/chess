namespace Echec.model.pieces
{
    public class Piece
    {
        public char Type { get; set; }

        public Piece() { }

        public Piece(char type)
        {
            Type = type;
        }

        public virtual bool playMove(int indexStart, int indexEnd) {
            return false;
        }
    }
}
