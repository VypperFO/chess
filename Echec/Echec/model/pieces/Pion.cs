namespace Echec.model.pieces
{
    public class Pion : PieceSpecial
    {
        public Pion() { }

        public Pion(char type, bool isMoved = false)
        {
            Type = type;
            IsMoved = isMoved;
        }

        public override bool playMove(int indexStart, int indexEnd)
        {
            indexStart++;
            indexEnd++;

            if (indexEnd == indexStart + 1 || (indexStart == 2 && indexEnd == 4))
            {
                return true;
            }
            else if ((indexEnd == indexStart + 2 && indexStart == 2) || (indexEnd == indexStart + 1 && (indexStart % 2 != indexEnd % 2)))
            {
                return true;
            }
            return false;
        }
    }
}
