using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec.model
{
    public class Joueur
    {
        private string name;
        private int nbVictory;
        private int nbDefeat;
        private int nbNull;

        public string Name 
        { 
            get { return name; }
            set { name = value; }
        }

        public int NbVictory
        {
            get { return nbVictory; }
            set { nbVictory = value; }
        }

        public int NbDefeat
        {
            get { return nbDefeat; }
            set { nbDefeat = value; }
        }

        public int NbNull
        {
            get { return nbNull; }
            set { nbNull = value; }
        }
    }
}
