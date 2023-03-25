namespace Echec.model.pieces
{
    public class Roi : PieceSpecial
    {
        public Roi() { }
        public Roi(char type, bool isMoved = false)
        {
            Type = type;
            IsMoved = isMoved;
        }
    }
}
