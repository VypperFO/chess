using static System.Windows.Forms.AxHost;

namespace Echec.model.pieces
{
    public class Fou : Piece
    {
        public Fou() { }
        public Fou(char type, Piece[] pieces): base(type, pieces) { }

        public override bool PlayMove(int startIndex, int endIndex)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            if (Math.Abs(startX - endX) != Math.Abs(startY - endY) || (startIndex == endIndex))
            {
                return false;
            }

            int xDir = Math.Sign(endX - startX);
            int yDir = Math.Sign(endY - startY);
            int x = startX + xDir;
            int y = startY + yDir;
            while (x != endX && y != endY)
            {
                int position = y * 8 + x;
                if (Pieces[position] != null)
                {
                    return false;
                }
                x += xDir;
                y += yDir;
            }

            return true;
        }
    }
}
