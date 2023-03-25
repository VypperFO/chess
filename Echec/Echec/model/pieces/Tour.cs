namespace Echec.model.pieces
{
    public class Tour : PieceSpecial
    {

        public Tour() { }
        public Tour(char type, Piece[] pieces, bool isMoved = false)
        {
            Type = type;
            Pieces = pieces;
            IsMoved = isMoved;
        }

        public override bool playMove(int startIndex, int endIndex)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            // check if the movement horizontal or vertical
            if (startX != endX && startY != endY)
            {
                return false;
            }

            // check if any pieces in way
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
