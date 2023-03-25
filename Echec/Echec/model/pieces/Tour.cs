namespace Echec.model.pieces
{
    public class Tour : PieceSpecial
    {

        public Tour() { }
        public Tour(char type, bool isMoved)
        {
            Type = type;
            IsMoved = isMoved;
        }
    }
}
