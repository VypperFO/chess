using System.Media;

namespace Echec.model
{
    public class Partie
    {
        public Plateau Board { get; set; }
        public List<Joueur> ListPlayers { get; set; }
        private List<string> listBoardConfig;

        public Partie()
        {
            Board = new Plateau();
            ListPlayers = new List<Joueur>();
            listBoardConfig = new List<string>();
            listBoardConfig.Add(Board.ToString());
        }

        public string PlayMove(Coordonnée coords)
        {
            Plateau boardMoved = Board.playMove(coords);

            if (boardMoved != null)
            {
                if (checkBoardConfig(listBoardConfig) != "")
                {
                    return "null";
                }  
                listBoardConfig.Add(boardMoved.ToString());
                Console.WriteLine(listBoardConfig.ElementAt(listBoardConfig.Count - 1).ToString());
                return boardMoved.ToString();
            }
            return listBoardConfig.ElementAt(listBoardConfig.Count -1).ToString();
        }

        public void addPlayerToGame(Joueur player1, Joueur player2)
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
