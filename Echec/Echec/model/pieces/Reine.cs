namespace Echec.model.pieces
{
    public class Reine : Piece
    {
        public Reine() { }
        public Reine(char type, Piece[] pieces): base(type, pieces) { }

        public override bool PlayMove(int startIndex, int endIndex)
        {
            Tour tower = new Tour(Type, Pieces);
            Fou bishop = new Fou(Type, Pieces);
           if (tower.PlayMove(startIndex, endIndex) || bishop.PlayMove(startIndex, endIndex) ){
                return true;
            }
           return false;
        }
    }
}
