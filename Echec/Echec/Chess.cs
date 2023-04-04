using ChessGame.view;
using ChessGame.model;

namespace ChessGame
{
    public class Chess
    {

        private List<Player> listAllPlayer = new(); // liste de tout les joueur possible de selectionner
        private List<Game> listGame = new(); // liste de tout les partie 

        static void Main()
        {
            Chess chess = new();
        }

        public Chess()
        {
            ApplicationConfiguration.Initialize();
            FormMenu menu = new(this);
            Application.Run(menu);
        }

        /// <summary>
        /// Envoie les cordonnees du coup a la partie
        /// </summary>
        /// <param name="xStart">cordonnees de depart X du coup</param>
        /// <param name="yStart">cordonnees de fin Y du coup</param>
        /// <param name="xEnd">cordonnees de depart X du coup</param>
        /// <param name="yEnd">cordonnees de fin Y du coup</param>
        /// <param name="form">Form dans lequel les pieces sont bouger</param>
        public void PlayMove(int xStart, int yStart, int xEnd, int yEnd, FormGame form)
        {
            Coordinates coords = new Coordinates(xStart, yStart, xEnd, yEnd);
            Game game = listGame.ElementAt(form.Id);
            string turnPlayed;
            if (game.PlayMove(coords) != null)
            {
                turnPlayed = game.PlayMove(coords);

                if (turnPlayed == "null")
                {
                    Player Player1 = game.ListPlayers.ElementAt(0);
                    Player Player2 = game.ListPlayers.ElementAt(1);
                    setNull(Player1.Name);
                    setNull(Player2.Name);
                    form.gameNull();
                }
                else if (turnPlayed == "win")
                {
                    Player Player1 = game.ListPlayers.ElementAt(0);
                    Player Player2 = game.ListPlayers.ElementAt(1);
                    setLoose(Player1.Name);
                    setWin(Player2.Name);
                    form.gameWon(Player2.Name);
                }
                else if (turnPlayed == "WIN")
                {
                    Player Player1 = game.ListPlayers.ElementAt(0);
                    Player Player2 = game.ListPlayers.ElementAt(1);
                    setWin(Player1.Name);
                    setLoose(Player2.Name);
                    form.gameWon(Player1.Name);
                }
                else
                {
                    form.ParseFen(turnPlayed);
                }
            }

        }

        /// <summary>
        /// Creer une nouvelle partie et place les pieces dans leur position de depart
        /// </summary>
        public void NewGame()
        {
            int id;
            FormGame myForm = new(this);
            Game game = new();

            listGame.Add(game);

            id = listGame.Count - 1;
            myForm.Id = id;

            myForm.ParseFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            myForm.Show();
        }

        /// <summary>
        /// Lit les stats des stats qui sont dans le fichier texte
        /// </summary>
        /// <returns>une liste de tout les joueurs avec leur stats</returns>
        public List<string> ReadStats()
        {
            listAllPlayer.Clear();
            string path = "statistique.txt";
            string[] readText = File.ReadAllLines(path);
            List<string> strings = new List<string>();
            List<string> playerNames = new List<string>();

            int count = 0;
            foreach (string s in readText)
            {
                strings.Add(s);
                count++;

                if (count == 5)
                {
                    Player player = new Player(strings.ElementAt(0), strings.ElementAt(1), strings.ElementAt(2), strings.ElementAt(3));
                    listAllPlayer.Add(player);
                    count = 0;
                    strings.Clear();
                }
            }

            for (int i = 0; i < listAllPlayer.Count(); i++)
            {
                playerNames.Add(listAllPlayer.ElementAt(i).Name);
            }
            return playerNames;
        }

        /// <summary>
        /// Creer un nouveau joueur dans le fichier
        /// </summary>
        /// <param name="name">nom du joueur</param>
        public void NewPlayer(string name)
        {
            if (!IsUserExisting(name))
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "statistique.txt"), true))
                {
                    outputFile.WriteLine(name);
                    outputFile.WriteLine("0");
                    outputFile.WriteLine("0");
                    outputFile.WriteLine("0");
                    outputFile.WriteLine("/");
                }
            }
        }

        /// <summary>
        /// Obtient les stats d'un joueur a un certain index
        /// </summary>
        /// <param name="index">index ou ce trouve le joueur dans le fichier</param>
        /// <returns>une liste contenant les stats du joueur</returns>
        public List<string> GetStats(int index)
        {
            List<string> strings = new List<string>();
            strings.Add(listAllPlayer.ElementAt(index).NbNull);
            strings.Add(listAllPlayer.ElementAt(index).NbVictory);
            strings.Add(listAllPlayer.ElementAt(index).NbDefeat);

            return strings;
        }

        /// <summary>
        /// Determine si un joueur avec le meme nom existe deja ou non
        /// </summary>
        /// <param name="name">nom du joueur rechercher</param>
        /// <returns>si il existe deja dans le fichier</returns>
        public bool IsUserExisting(string name)
        {
            string path = "statistique.txt";
            string[] readText = File.ReadAllLines(path);

            foreach (string s in readText)
            {
                if (s.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Obtient un joueur a l'aide de son nom
        /// </summary>
        /// <param name="name">nom du joueur</param>
        /// <returns>le joueur </returns>
        public Player GetPlayer(string name)
        {

            foreach (Player player in listAllPlayer)
            {
                if (player.Name == name)
                {
                    return player;
                }
            }
            return null;
        }

        /// <summary>
        /// Initialise les 2 joueur comme les joueurs de la partie
        /// </summary>
        /// <param name="playerOne">Joueur 1</param>
        /// <param name="playerTwo">Joueur 2</param>
        public void sendPlayers(string playerOne, string playerTwo)
        {
            Player player1 = GetPlayer(playerOne);
            Player player2 = GetPlayer(playerTwo);
            Game game = listGame.ElementAt(listGame.Count - 1);
            game.addPlayerToGame(player1, player2);
        }

        /// <summary>
        /// Rajouter une null au statistique d'un joueur
        /// </summary>
        /// <param name="name">nom du joueur</param>
        public void setNull(string name)
        {
            string path = "statistique.txt";
            int index = 0;
            var lines = File.ReadAllLines("statistique.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == name)
                {
                    index = i + 3;
                }
            }
            string[] arrLine = File.ReadAllLines(path);
            string var = arrLine[index];
            int var2 = int.Parse(var);
            var2 = var2 + 1;
            arrLine[index] = var2.ToString();
            File.WriteAllLines(path, arrLine);
        }

        /// <summary>
        /// Rajouter une partie gagner au statistique d'un joueur
        /// </summary>
        /// <param name="name">nom du joueur</param>
        public void setWin(string name)
        {
            string path = "statistique.txt";
            int index = 0;
            var lines = File.ReadAllLines("statistique.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == name)
                {
                    index = i + 1;
                }
            }
            string[] arrLine = File.ReadAllLines(path);
            string var = arrLine[index];
            int var2 = int.Parse(var);
            var2 = var2 + 1;
            arrLine[index] = var2.ToString();
            File.WriteAllLines(path, arrLine);
        }

        /// <summary>
        /// Rajouter une partie perdu au statistique d'un joueur
        /// </summary>
        /// <param name="name">nom du joueur</param>
        public void setLoose(string name)
        {
            string path = "statistique.txt";
            int index = 0;
            var lines = File.ReadAllLines("statistique.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == name)
                {
                    index = i + 2;
                }
            }
            string[] arrLine = File.ReadAllLines(path);
            string var = arrLine[index];
            int var2 = int.Parse(var);
            var2 = var2 + 1;
            arrLine[index] = var2.ToString();
            File.WriteAllLines(path, arrLine);
        }

    }
}