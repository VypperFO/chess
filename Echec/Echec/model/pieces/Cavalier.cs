namespace Echec.model.pieces
{
    public class Cavalier : Piece
    {
        public Cavalier() { }
        public Cavalier(char type)
        {
            Type = type;
        }

        public override bool playMove(int indexStart, int indexEnd)
        {
            indexStart++;
            indexEnd++;
            if (Math.Abs(indexEnd - indexStart) == 3 && Math.Abs(indexEnd % 2 - indexStart % 2) == 1)
            {
                return true;
            }
            return false;
        }
    }
}
