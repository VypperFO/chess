namespace Echec.model.pieces
{
    public abstract class PieceSpecial : Piece
    {
        protected bool isMoved;
        public PieceSpecial() { }

        public PieceSpecial(char type, bool isMoved)
        {
            Type = type;
            IsMoved = isMoved;
        }

        public bool IsMoved
        {
            get { return isMoved; }
            set { isMoved = value; }
        }
    }
}
