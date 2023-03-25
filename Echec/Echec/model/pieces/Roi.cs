namespace Echec.model.pieces
{
    public class Roi : PieceSpecial
    {
        public Roi() { }
        public Roi(char type, Piece[] pieces,bool isMoved = false)
        {
            Type = type;
            Pieces = pieces;
            IsMoved = isMoved;
        }
        public override bool playMove(int startIndex, int endIndex)
        {
            // pas trop sur si on garde cest sketch
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            int deltaX = Math.Abs(startX - endX);
            int deltaY = Math.Abs(startY - endY);

            if ((deltaX == 1 && deltaY == 0) || (deltaX == 0 && deltaY == 1) || (deltaX == 1 && deltaY == 1))
            {
                if (Pieces[endIndex] == null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
