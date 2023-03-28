namespace Echec.model.pieces
{
    public class Piece
    {
        public char Type { get; set; }
        public Piece[] Pieces { get; set; }

        public Piece() { }

        public Piece(char type, Piece[] pieces)
        {
            Type = type;
            Pieces = pieces;
        }

        public virtual bool PlayMove(int startIndex, int endIndex) { return false; }

        public bool SameColor(int endIndex)
        {
            // White
            if(Char.IsUpper(Type) && Char.IsUpper(Pieces[endIndex].Type))
            {
                return true;
            }

            // Black
            if (Char.IsLower(Type) && Char.IsLower(Pieces[endIndex].Type))
            {
                return true;
            }

            return false;
        }   
    }
}
