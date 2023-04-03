namespace Echec.model.pieces
{
    public abstract class SpecialPiece : Piece
    {
        protected bool IsMoved { get; set; }
        public SpecialPiece() { }

        public SpecialPiece(char type, Piece[] pieces,bool isMoved = false) : base(type, pieces)
        {
            IsMoved = isMoved;
        }
    }
}
