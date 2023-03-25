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

        public override bool playMove(int indexStart, int indexEnd)
        {
            indexStart++;
            indexEnd++;

            if (indexEnd == indexStart -1 || indexEnd == indexStart + 1)
            {
                return false;
            }
            return false;
        }
    }
}
