namespace Echec.model.pieces
{
    public class Pion : PieceSpecial
    {
        private bool isEnPassant;

        public Pion() { }
        public Pion(char type, bool isEnPassant, bool isMoved = false)
        {
            Type = type;
            IsMoved = isMoved;
            IsEnPassant = isEnPassant;
        }

        public bool IsEnPassant
        {
            get { return isEnPassant; }
            set { isEnPassant = value; }
        }
    }
}
