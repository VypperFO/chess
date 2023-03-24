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
        private List<string> listBoardConfig;
        private int id;

        public Partie() { }
        public int Id
        {
            get { return id; }
        }

        public Partie(int id)
        {
            this.board = new Plateau();
            this.listBoardConfig = new List<string>();
            this.listBoardConfig.Add("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            this.id = id;
        }

        public string playMove(Coordonnée coords)
        {
            string boardMoved = board.playMove(coords, listBoardConfig.ElementAt(listBoardConfig.Count -1));

            if (boardMoved != null)
            {
                listBoardConfig.Add(boardMoved);
                return boardMoved;
            }
            return null;
        }

        public Plateau Board
        {
            get { return board; }
            set { board = value; }
        }

        
    }
}
