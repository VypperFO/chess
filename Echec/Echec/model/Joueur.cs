namespace Echec.model
{
    public class Joueur
    {
        private string name;
        private string nbNull;
        private string nbVictory;
        private string nbDefeat;

        public Joueur() { }
        public Joueur(string name, string nbVictory, string nbDefeat, string nbNull)
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
