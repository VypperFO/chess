namespace Echec.model.pieces
{
    public class Reine : Piece
    {
        public Reine() { }
        public Reine(char type)
        {
            Type = type;
        }

        public override bool playMove(int indexStart, int indexEnd)
        {
            if (Math.Abs(indexEnd - indexStart) % 2 == 1 || indexStart % 2 != indexEnd % 2)
            {
                return false;
            }
            return true;
        }
    }
}
