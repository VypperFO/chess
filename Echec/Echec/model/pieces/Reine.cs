namespace Echec.model.pieces
{
    public class Reine : Piece
    {
        public Reine() { }
        public Reine(char type, Piece[] pieces): base(type, pieces) { }

        public override bool PlayMove(int startIndex, int endIndex)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            if (Math.Abs(startX - endX) != Math.Abs(startY - endY) && startX != endX && startY != endY)
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
