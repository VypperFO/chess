using Echec.view;
using Echec.model;
using System.Diagnostics.Metrics;

namespace Echec
{
     public class Echec
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public List<model.Joueur> listAllPlayer = new List<model.Joueur>();
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
            Partie game = new model.Partie();
            string move = game.playMove(coords);
            
            if (move != null)
            {
                form.parseFen(move);
            }
            return;
        }

        public void newGame()
        {
            var myForm = new FormGame(this);
            myForm.Show();
        }
        public void readStats()
        {
            
            foreach (string line in System.IO.File.ReadLines("statistique.txt"))
            {
                model.Joueur player = new model.Joueur();
                string [] parts =  line.Split("/");

                for (int i = 0; i < parts.Length; i++)
                {
                    string[] playerStats = parts[0].Split(' ');
                    player.Name = playerStats[0];
                    player.NbNull = playerStats[1];
                    player.NbVictory = playerStats[2];
                    player.NbVictory = playerStats[3];
                }
                listAllPlayer.Add(player);
            }
        }


    }
}