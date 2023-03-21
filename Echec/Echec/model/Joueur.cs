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
        private string nbVictory;
        private string nbDefeat;
        private string nbNull;

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
