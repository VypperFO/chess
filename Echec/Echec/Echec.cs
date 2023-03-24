using Echec.view;
using Echec.model;
using System.Diagnostics.Metrics;
using System.IO;
using static System.Windows.Forms.LinkLabel;

namespace Echec
{
    public class Echec
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public List<Joueur> listAllPlayer = new List<Joueur>();
        public List<Partie> listGame = new List<Partie>();

        static void Main()
        {
            Echec chess = new Echec();
        }

        public Echec() {
            ApplicationConfiguration.Initialize();
            view.FormMenu menu = new view.FormMenu(this);
            Application.Run(menu);
        }

        public void playMove(int xStart, int yStart, int xEnd, int yEnd, FormGame form)
        {
            Coordonnée coords = new Coordonnée(xStart, yStart, xEnd, yEnd);
            Partie game = listGame.ElementAt(form.Id);
            string gameMove = game.playMove(coords);
            
            if (gameMove != null)
            {
                form.parseFen(gameMove);
            }
            return;
        }

        private Partie Partie()
        {
            throw new NotImplementedException();
        }

        public void newGame(FormMenu menu)
        {
            int id = 0;

            FormGame myForm = new FormGame(this, id++);

            Partie game = new Partie(id++);
            listGame.Add(game);

            myForm.Show();
        }
        public List<string> readStats()
        {
            this.listAllPlayer.Clear();
            string path = "statistique.txt";
            string[] readText = File.ReadAllLines(path);
            List<string> strings = new List<string>();
            List<string> playerNames = new List<string>();

            int count = 0;
            foreach (string s in readText)
            {
                strings.Add(s);
                count++;

                if(count == 5)
                {
                        Joueur player = new Joueur(strings.ElementAt(0), strings.ElementAt(1), strings.ElementAt(2), strings.ElementAt(3));
                        listAllPlayer.Add(player);
                    count = 0;
                    strings.Clear();
                }
            }

            for(int i = 0; i < listAllPlayer.Count(); i++)
            {
                playerNames.Add(listAllPlayer.ElementAt(i).Name);
            }
            return playerNames;
        }

        public void newPlayer(string name)
        {
            if (!isUserExisting(name)) { 
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "statistique.txt"), true))
                {
                    outputFile.WriteLine(name);
                    outputFile.WriteLine("0");
                    outputFile.WriteLine("0");
                    outputFile.WriteLine("0");
                    outputFile.WriteLine("/");
                }
            } else
            {

            }
        }

        public List<string> getStats(int index)
        {
            List<string> strings = new List<string>();
            strings.Add(listAllPlayer.ElementAt(index).NbNull);
            strings.Add(listAllPlayer.ElementAt(index).NbVictory);
            strings.Add(listAllPlayer.ElementAt(index).NbDefeat);

            return strings;
        }

        public bool isUserExisting(string name)
        {
            string path = "statistique.txt";
            string[] readText = File.ReadAllLines(path);

            foreach (string s in readText)
            {
                if(s.Equals(name))
                {
                    return true;
                }
            }
                return false;
        }

        public Joueur getPlayer(string name)
        {

            foreach (Joueur player in listAllPlayer)
            {
                if (player.Name == name)
                {
                    return player;
                }
            }
            return null;
        }
    }
}