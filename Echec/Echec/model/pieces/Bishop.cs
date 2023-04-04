namespace ChessGame.model.pieces
{
    public class Bishop : Piece
    {
        public Bishop() { }
        public Bishop(char type, Piece[] pieces) : base(type, pieces) { }

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

            if (Math.Abs(startX - endX) != Math.Abs(startY - endY) || startIndex == endIndex)
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

        /// <summary>
        /// Verifie si la piece pour faire le deplacement donner en parametre dans un tableau temporaire
        /// </summary>
        /// <param name="startIndex">Coordonnes de depart du mouvement de la piece</param>
        /// <param name="endIndex">Coordonnes de fin du mouvement de la piece</param>
        /// <param name="TempPieces">tableau temporaire</param>
        /// <returns>Si la piece a le droit de faire se deplacement</returns>
        public override bool PlayMoveTemp(int startIndex, int endIndex, Piece[] TempPieces)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            if (Math.Abs(startX - endX) != Math.Abs(startY - endY) || startIndex == endIndex)
            {
                return false;
            }

            if (SameColorTemp(endIndex,TempPieces))
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
