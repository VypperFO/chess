namespace Echec.model
{
    public class Partie
    {
        private List<Joueur> listPlayers;
        private Plateau board;
        private List<Plateau> listBoardConfig;

        public Partie()
        {
            board = new Plateau();
            listBoardConfig = new List<Plateau>();
            listBoardConfig.Add(board);
        }

        public string playMove(Coordonnée coords)
        {
            Plateau boardMoved = board.playMove(coords);

            if (boardMoved != null)
            {
                listBoardConfig.Add(boardMoved);
                return boardMoved.ToString();
            } 
            return listBoardConfig.ElementAt(listBoardConfig.Count -1).ToString();
        }

        public Plateau Board
        {
            get { return board; }
            set { board = value; }
        }


    }
}
