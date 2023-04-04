namespace ChessGame.model.pieces
{
    public class Knight : Piece
    {
        public Knight() { }
        public Knight(char type, Piece[] pieces) : base(type, pieces) { }

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

            if (deltaX == 1 && deltaY == 2 || deltaX == 2 && deltaY == 1 && !SameColor(endIndex))
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

            if (deltaX == 1 && deltaY == 2 || deltaX == 2 && deltaY == 1 && !SameColor2(endIndex, TempPieces))
            {
                return true;
            }

            return false;
        }
    }
}
