using System.Media;

namespace Echec.model
{
    public class Game
    {
        private Board Board { get; set; }
        public List<Player> ListPlayers { get; set; }
        private List<string> listBoardConfig;

        public Game()
        {
            Board = new Board();
            ListPlayers = new List<Player>();
            listBoardConfig = new List<string>();
            listBoardConfig.Add(Board.ToString());
        }

        public string PlayMove(Coordinates coords)
        {
            string boardMoved = Board.playMove(coords);

            if (boardMoved != null)
            {
                if (checkBoardConfig(listBoardConfig) != "")
                {
                    return "null";
                }
                
                listBoardConfig.Add(boardMoved);
                Console.WriteLine(listBoardConfig.ElementAt(listBoardConfig.Count - 1).ToString());
                return boardMoved;
            }
            return listBoardConfig.ElementAt(listBoardConfig.Count -1);
        }

        public void addPlayerToGame(Player player1, Player player2)
        {
           ListPlayers.Add(player1);
           ListPlayers.Add(player2);
        }

        public string checkBoardConfig(List<String> list)
        {
            var q = from x in list
                    group x by x into g
                    let count = g.Count()
                    orderby count descending
                    select new { Value = g.Key, Count = count };
            foreach (var x in q)
            {
                if(x.Count == 5)
                {
                    return "null";
                }
            }
            return "";
        }
    }
}
