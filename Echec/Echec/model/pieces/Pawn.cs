namespace ChessGame.model.pieces
{
    public class Pawn : SpecialPiece
    {
        public Pawn() { }

        public Pawn(char type, Piece[] pieces, bool isMoved = false) : base(type, pieces)
        {
            IsMoved = isMoved;
        }

        /// <summary>
        /// Verifie si la piece pour faire le deplacement donner en parametre
        /// </summary>
        /// <param name="startIndex">Coordonnes de depart du mouvement de la piece</param>
        /// <param name="endIndex">Coordonnes de fin du mouvement de la piece</param>
        /// <returns>Si la piece a le droit de faire se deplacement</returns>
        public override bool PlayMove(int startIndex, int endIndex)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;


            int deltaX = Math.Abs(startX - endX);
            int deltaY = startY - endY;

            if (SameColor(endIndex))
            {
                return false;
            }

            if (char.IsUpper(Type))
            {
                if (deltaX == 0 && deltaY == 1 && Pieces[endIndex] == null || IsMoved == false && deltaX == 0 && deltaY == 2 && Pieces[endIndex] == null || deltaX == 1 && deltaY == 1 && Pieces[endIndex] != null)
                {
                    IsMoved = true;
                    return true;
                }
                return false;
            }
            else
            {
                if (deltaX == 0 && deltaY == -1 && Pieces[endIndex] == null || IsMoved == false && deltaX == 0 && deltaY == -2 && Pieces[endIndex] == null || deltaX == 1 && deltaY == -1 && Pieces[endIndex] != null)
                {
                    IsMoved = true;
                    return true;
                }
                return false;
            }
        }



        public override bool PlayMove2(int startIndex, int endIndex, Piece[] TempPieces)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;


            int deltaX = Math.Abs(startX - endX);
            int deltaY = startY - endY;

            if (SameColor2(endIndex, TempPieces))
            {
                return false;
            }

            if (char.IsUpper(Type))
            {
                if (deltaX == 0 && deltaY == 1 && Pieces[endIndex] == null || IsMoved == false && deltaX == 0 && deltaY == 2 && Pieces[endIndex] == null || deltaX == 1 && deltaY == 1 && Pieces[endIndex] != null)
                {
                    IsMoved = true;
                    return true;
                }
                return false;
            }
            else
            {
                if (deltaX == 0 && deltaY == -1 && Pieces[endIndex] == null || IsMoved == false && deltaX == 0 && deltaY == -2 && Pieces[endIndex] == null || deltaX == 1 && deltaY == -1 && Pieces[endIndex] != null)
                {
                    IsMoved = true;
                    return true;
                }
                return false;
            }
        }
    }
}