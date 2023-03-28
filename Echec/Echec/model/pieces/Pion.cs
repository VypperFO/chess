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
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

          



            int deltaX = Math.Abs(startX - endX);
            int deltaY = startY - endY;

            /// TODO PROMOTION ET CHECK COLOR
            if ((deltaX == 0 && deltaY == 1 && Pieces[endIndex] == null) || (IsMoved == false && deltaX == 0 && deltaY == 2 && Pieces[endIndex] == null) || (deltaX == 1 && deltaY == 1 && Pieces[endIndex] != null))
            {

                IsMoved = true;
                return true;
            }
            return false;

        }
            
    }
}