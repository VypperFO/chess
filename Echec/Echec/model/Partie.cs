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
        private List<String> listBoardConfig;

        public Partie() { }

        public string playMove(Coordonnée coords)
        {
            return "knbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNK w KQkq - 0 1";
        }

        public Plateau Board
        {
            get { return board; }
            set { board = value; }
        }

        
    }
}
