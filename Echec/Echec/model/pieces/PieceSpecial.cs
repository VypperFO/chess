using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec.model.pieces
{
    public abstract class PieceSpecial : Piece
    {
        protected bool isMoved;
        public PieceSpecial() { }

        public PieceSpecial(string name, bool isMoved)
        {
            Name = name;
            IsMoved = isMoved;
        }

        public bool IsMoved
        { 
            get { return isMoved; } 
            set { isMoved = value; }
        }
    }
}
