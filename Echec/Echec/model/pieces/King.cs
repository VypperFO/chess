namespace Echec.model.pieces
{
    public class King : SpecialPiece
    {
        public King() { }
        public King(char type, Piece[] pieces,bool isMoved = false): base(type, pieces, isMoved) { }
        public override bool PlayMove(int startIndex, int endIndex)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            int deltaX = Math.Abs(startX - endX);
            int deltaY = Math.Abs(startY - endY);

            if (SameColor(endIndex))
            {
                return false;
            }

            if ((deltaX == 1 && deltaY == 0) || (deltaX == 0 && deltaY == 1) || (deltaX == 1 && deltaY == 1))
            {
                return true;
            }

            return false;
        }
    }
}
