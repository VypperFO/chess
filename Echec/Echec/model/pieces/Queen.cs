namespace Echec.model.pieces
{
    public class Queen : Piece
    {
        public Queen() { }
        public Queen(char type, Piece[] pieces): base(type, pieces) { }

        public override bool PlayMove(int startIndex, int endIndex)
        {
            Rook tower = new Rook(Type, Pieces);
            Bishop bishop = new Bishop(Type, Pieces);
           if (tower.PlayMove(startIndex, endIndex) || bishop.PlayMove(startIndex, endIndex) ){
                return true;
            }
           return false;
        }
    }
}
