namespace Echec.model.pieces
{
    public class Pion : PieceSpecial
    {
        public Pion() { }

        public Pion(char type, Piece[] pieces, bool isMoved = false): base(type, pieces)
        {
            IsMoved = isMoved;
        }

        public override bool PlayMove(int startIndex, int endIndex)
        {
            // TODO
            return true;
        }
    }
}
