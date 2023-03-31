namespace Echec.model.pieces
{
    public class Tour : PieceSpecial
    {

        public Tour() { }
        public Tour(char type, Piece[] pieces, bool isMoved = false): base(type, pieces, isMoved)
        {
        }

        public override bool PlayMove(int startIndex, int endIndex)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            if (startX != endX && startY != endY)
            {
                return false;
            }

            if (SameColor(endIndex))
            {
                return false;
            }

            int xDir = Math.Sign(endX - startX);
            int yDir = Math.Sign(endY - startY);
            int x = startX + xDir;
            int y = startY + yDir;
            while (x != endX || y != endY)
            {
                int position = y * 8 + x;
                if (Pieces[position] != null)
                {
                    return false;
                }
                x += xDir * (startY == endY ? 1 : 0);
                y += yDir * (startX == endX ? 1 : 0);
            }

            return true;
        }
    }
}
