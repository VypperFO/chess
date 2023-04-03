namespace Echec.model
{
    public class Player
    {
        public string Name  { get; set; }
        public string NbNull  { get; set; }
        public string NbVictory  { get; set; }
        public string NbDefeat  { get; set; }

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
