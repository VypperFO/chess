using static System.Windows.Forms.AxHost;

namespace Echec.model.pieces
{
    public class Fou : Piece
    {
        public Fou() { }
        public Fou(char type, Piece[] pieces)
        {
            Type = type;
            Pieces = pieces;
        }

        public override bool playMove(int startIndex, int endIndex)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            // Check if the movement is diagonal
            if (Math.Abs(startX - endX) != Math.Abs(startY - endY))
            {
                return false;
            }

            // Check if there are any pieces in the way
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

            // The movement is valid
            return true;
        }
    }
}
