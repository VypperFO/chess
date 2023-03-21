using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec.model
{
    public class Partie
    {
        private List<Joueur> listPlayers;
        private Plateau board;
        private int roundsInRow;
        private bool whichTurn;
        private List<String> listBoardConfig;

        public Plateau Board
        {
            get { return board; }
            set { board = value; }
        }

        public int RoundsInRow
        {
            get { return roundsInRow; }
            set => roundsInRow = value;
        }

        public bool WhichTurn
        {
            get { return whichTurn; }
            set { whichTurn = value; }
        }
    }
}
