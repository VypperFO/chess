namespace ChessGame.model.pieces
{
    public class Queen : Piece
    {
        public Queen() { }
        public Queen(char type, Piece[] pieces) : base(type, pieces) { }

        /// <summary>
        /// Verifie si la piece pour faire le deplacement donner en parametre
        /// </summary>
        /// <param name="startIndex">Coordonnes de depart du mouvement de la piece</param>
        /// <param name="endIndex">Coordonnes de fin du mouvement de la piece</param>
        /// <returns>Si la piece a le droit de faire se deplacement</returns>
        public override bool PlayMove(int startIndex, int endIndex)
        {
            Rook tower = new Rook(Type, Pieces);
            Bishop bishop = new Bishop(Type, Pieces);
            if (tower.PlayMove(startIndex, endIndex) || bishop.PlayMove(startIndex, endIndex))
            {
                return true;
            }
            return false;
        }

        public override bool PlayMoveTemp(int startIndex, int endIndex, Piece[] TempPieces)
        {
            Rook tower = new Rook(Type, Pieces);
            Bishop bishop = new Bishop(Type, Pieces);
            if (tower.PlayMoveTemp(startIndex, endIndex,TempPieces) || bishop.PlayMoveTemp(startIndex, endIndex, TempPieces))
            {
                return true;
            }
            return false;
        }
    }
}
