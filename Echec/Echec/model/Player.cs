namespace ChessGame.model
{
    public class Player
    {
        public string Name { get; set; } // nom du joueur
        public string NbNull { get; set; } // nombre de partie null du joueur
        public string NbVictory { get; set; } // nombre de victoire du joueur
        public string NbDefeat { get; set; } // nombre de defaite du joueur

        public Player() { }
        public Player(string name, string nbVictory, string nbDefeat, string nbNull)
        {
            Name = name;
            NbVictory = nbVictory;
            NbDefeat = nbDefeat;
            NbNull = nbNull;
        }
    }
}
