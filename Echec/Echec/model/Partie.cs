namespace Echec.model
{
    public class Partie
    {
        public Plateau Board { get; set; }
        private List<Joueur> listPlayers;
        private List<Plateau> listBoardConfig;

        public Partie()
        {
            Board = new Plateau();
            listBoardConfig = new List<Plateau>();
            listBoardConfig.Add(Board);
        }

        public string PlayMove(Coordonnée coords)
        {
            Plateau boardMoved = Board.playMove(coords);

            if (boardMoved != null)
            {
                listBoardConfig.Add(boardMoved);
                return boardMoved.ToString();
            }
            Console.WriteLine(listBoardConfig.ElementAt(listBoardConfig.Count - 1).ToString());
            return listBoardConfig.ElementAt(listBoardConfig.Count -1).ToString();
        }
    }
}
