using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec.model.pieces
{
    public class Piece
    {
        protected string name = "";
        public char Type { get; set; } // 'K' for king, 'Q' for queen, 'R' for rook, 'B' for bishop, 'N' for knight, 'P' for pawn
        public bool IsWhite { get; set; }

        public Piece() { }

        public Piece(string name)
        {
            Name = name;
        }

        public string Name { 
            get { return name; } 
            set { name = value; }
        }
    }
}
