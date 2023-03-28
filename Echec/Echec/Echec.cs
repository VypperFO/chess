using Echec.model;
using Echec.view;
using Microsoft.VisualBasic;
using System;

namespace Echec
{
    public class Echec
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        private List<Joueur> listAllPlayer = new();
        private List<Partie> listGame = new();

        static void Main()
        {
            Echec chess = new();
        }

        public Echec()
        {
            ApplicationConfiguration.Initialize();
            FormMenu menu = new(this);
            Application.Run(menu);
        }

        public void PlayMove(int xStart, int yStart, int xEnd, int yEnd, FormGame form)
        {
            Coordonnée coords = new Coordonnée(xStart, yStart, xEnd, yEnd);
            Partie game = listGame.ElementAt(form.Id);

            string turnPlayed = game.PlayMove(coords);

            form.ParseFen(turnPlayed);
        }

        public void NewGame()
        {
            int id;
            FormGame myForm = new(this);
            Partie game = new();

            listGame.Add(game);

            id = listGame.Count - 1;
            myForm.Id = id;

            myForm.ParseFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            myForm.Show();
        }
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
                    Joueur player = new Joueur(strings.ElementAt(0), strings.ElementAt(1), strings.ElementAt(2), strings.ElementAt(3));
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

        public List<string> GetStats(int index)
        {
            List<string> strings = new List<string>();
            strings.Add(listAllPlayer.ElementAt(index).NbNull);
            strings.Add(listAllPlayer.ElementAt(index).NbVictory);
            strings.Add(listAllPlayer.ElementAt(index).NbDefeat);

            return strings;
        }

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

        public Joueur GetPlayer(string name)
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
        
        public void sendPlayers(string playerOne, string playerTwo)
        {
            Joueur player1 = GetPlayer(playerOne);
            Joueur player2 = GetPlayer(playerTwo);
            Partie game = listGame.ElementAt(listGame.Count - 1);
            game.addPlayerToGame(player1,player2);
        }
    }
}