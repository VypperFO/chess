namespace Echec.model.pieces
{
    public class Fou : Piece
    {
        public Fou() { }
        public Fou(char type)
        {
            Type = type;
        }

        public override bool playMove(int indexStart, int indexEnd)
        {
            int rowDiff = Math.Abs(indexStart - indexEnd) / 8;
            int colDiff = Math.Abs(indexStart - indexEnd) % 8;

            // check if move is diagonal and within bounds of board
            if (rowDiff == colDiff && indexEnd >= 0 && indexEnd <= 63)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
