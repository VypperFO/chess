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

        public override bool playMove(int startIndex, int endIndex)
        {
            // TODO
            return true;
        }
    }
}
