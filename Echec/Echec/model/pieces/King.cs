namespace ChessGame.model.pieces
{
    public class King : SpecialPiece
    {
        public King() { }
        public King(char type, Piece[] pieces, bool isMoved = false) : base(type, pieces, isMoved) { }

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
            int deltaY = Math.Abs(startY - endY);

            if (SameColor(endIndex))
            {
                return false;
            }

            if (deltaX == 1 && deltaY == 0 || deltaX == 0 && deltaY == 1 || deltaX == 1 && deltaY == 1)
            {
                return true;
            }

            return false;
        }

        public override bool PlayMove2(int startIndex, int endIndex, Piece[] TempPieces)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            int deltaX = Math.Abs(startX - endX);
            int deltaY = Math.Abs(startY - endY);

            if (SameColor2(endIndex, TempPieces))
            {
                return false;
            }

            if (deltaX == 1 && deltaY == 0 || deltaX == 0 && deltaY == 1 || deltaX == 1 && deltaY == 1)
            {
                return true;
            }

            return false;
        }

        public override bool testMoves(int startIndex, int endIndex)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            int deltaX = Math.Abs(startX - endX);
            int deltaY = Math.Abs(startY - endY);

            if (deltaX == 1 && deltaY == 0 || deltaX == 0 && deltaY == 1 || deltaX == 1 && deltaY == 1)
            {
                return true;
            }

            return false;
        }
    }
}

