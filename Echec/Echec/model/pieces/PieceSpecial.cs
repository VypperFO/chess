namespace Echec.model.pieces
{
    public abstract class PieceSpecial : Piece
    {
        protected bool IsMoved { get; set; }
        public PieceSpecial() { }

        public PieceSpecial(char type, Piece[] pieces,bool isMoved = false) : base(type, pieces)
        {
            IsMoved = isMoved;
        }
    }
}
