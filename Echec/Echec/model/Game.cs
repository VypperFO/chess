namespace ChessGame.model
{
    public class Game
    {
        private Board Board { get; set; } // plateau de la partie
        public List<Player> ListPlayers { get; set; } // liste des joueur dans la partie
        private List<string> listBoardConfig; // list de tout les config de board qui a ete jouer dans cette partie

        public Game()
        {
            Board = new Board();
            ListPlayers = new List<Player>();
            listBoardConfig = new List<string>
            {
                Board.ToString()
            };
        }

        /// <summary>
        /// Envoie les coordonne du mouvement fait par le joueur
        /// </summary>
        /// <param name="coords">les coordonne du mouvement</param>
        /// <returns>la reponse du plateau suite au mouvement</returns>
        public string PlayMove(Coordinates coords)
        {
            string boardMoved = Board.PlayMove(coords);

            if (boardMoved != null)
            {
                if (CheckBoardConfig(listBoardConfig) != "")
                {
                    return "null";
                }

                listBoardConfig.Add(boardMoved);
                Console.WriteLine(listBoardConfig.ElementAt(listBoardConfig.Count - 1).ToString());
                return boardMoved;
            }
            return listBoardConfig.ElementAt(listBoardConfig.Count - 1);
        }

        /// <summary>
        /// Rajouter les joueur a la partie
        /// </summary>
        /// <param name="player1">Joueur 1 de la partie</param>
        /// <param name="player2">Joueur 2 de la partie</param>
        public void AddPlayerToGame(Player player1, Player player2)
        {
            ListPlayers.Add(player1);
            ListPlayers.Add(player2);
        }

        /// <summary>
        /// Determine si la meme configuration de plateau a ete jouer 5 fois dans une meme partie
        /// </summary>
        /// <param name="list">list de tout les configugrations de plateau de la partie</param>
        /// <returns>sous forme de string si la partie continue d'etre jouer ou elle est fini</returns>
        public string CheckBoardConfig(List<string> list)
        {
            var q = from x in list
                    group x by x into g
                    let count = g.Count()
                    orderby count descending
                    select new { Value = g.Key, Count = count };
            foreach (var x in q)
            {
                if (x.Count == 5)
                {
                    return "null";
                }
            }
            return "";
        }
    }
}
