namespace Echec.model.pieces
{
    public class Tour : PieceSpecial
    {

        public Tour() { }
        public Tour(char type, bool isMoved = false)
        {
            Type = type;
            IsMoved = isMoved;
        }

        public override bool playMove(int indexStart, int indexEnd)
        {
            if (indexStart % 2 != indexEnd % 2)
            {
                return false;
            }
            IsMoved = true;
            return true;
        }
    }
}
