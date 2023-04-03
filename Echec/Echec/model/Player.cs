namespace Echec.model
{
    public class Player
    {
        private string name;
        private string nbNull;
        private string nbVictory;
        private string nbDefeat;

        public Player() { }
        public Player(string name, string nbVictory, string nbDefeat, string nbNull)
        {
            this.name = name;
            this.nbVictory = nbVictory;
            this.nbDefeat = nbDefeat;
            this.nbNull = nbNull;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string NbVictory
        {
            get { return nbVictory; }
            set { nbVictory = value; }
        }

        public string NbDefeat
        {
            get { return nbDefeat; }
            set { nbDefeat = value; }
        }

        public string NbNull
        {
            get { return nbNull; }
            set { nbNull = value; }
        }
    }
}
