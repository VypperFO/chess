namespace ChessGame.model.pieces
{
    public class Piece
    {
        public char Type { get; set; } // Couleur de la piece
        public Piece[] Pieces { get; set; } // quelle est la piece

        public Piece() { }

        public Piece(char type, Piece[] pieces)
        {
            Type = type; 
            Pieces = pieces;
        }

        public virtual bool PlayMove(int startIndex, int endIndex) { return false; }

        public virtual bool PlayMoveTemp(int startIndex, int endIndex, Piece[] TempPieces) { return false; }

        /// <summary>
        /// Verifie si la destination d'une piece conient une piece de la meme couleur que la piece qui fait le mouvement
        /// </summary>
        /// <param name="endIndex">la destination de la piece</param>
        /// <returns>si la destination d'une piece conient une piece de la meme couleur</returns>
        public bool SameColor(int endIndex)
        {
            if (Pieces[endIndex] == null)
            {
                return false;
            }

            // White
            if (char.IsUpper(Type) && char.IsUpper(Pieces[endIndex].Type))
            {
                return true;
            }

            // Black
            if (char.IsLower(Type) && char.IsLower(Pieces[endIndex].Type))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifie si la destination d'une piece conient une piece de la meme couleur que la piece qui fait le mouvement
        /// </summary>
        /// <param name="endIndex">la destination de la piece</param>
        /// <param name="TempPieces"></param>
        /// <returns>si la destination d'une piece conient une piece de la meme couleur</returns>
        public bool SameColorTemp(int endIndex, Piece[] TempPieces)
        {
            if (TempPieces[endIndex] == null)
            {
                return false;
            }

            // White
            if (char.IsUpper(Type) && char.IsUpper(TempPieces[endIndex].Type))
            {
                return true;
            }

            // Black
            if (char.IsLower(Type) && char.IsLower(TempPieces[endIndex].Type))
            {
                return true;
            }

            return false;
        }
    }
}
