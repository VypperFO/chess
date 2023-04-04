namespace ChessGame.model.pieces
{
    public class Rook : SpecialPiece
    {

        public Rook() { }
        public Rook(char type, Piece[] pieces, bool isMoved = false) : base(type, pieces, isMoved) { }

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

        public override bool PlayMove2(int startIndex, int endIndex, Piece[] TempPieces)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            if (startX != endX && startY != endY)
            {
                return false;
            }

            if (SameColor2(endIndex,TempPieces))
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
