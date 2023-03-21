using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec.model.pieces
{
    public class Pion : PieceSpecial
    {
        private bool isEnPassant;

        public Pion() { }
        public Pion(string name, bool isMoved, bool isEnPassant)
        {
            Name = name;
            IsMoved = isMoved;
            IsEnPassant = isEnPassant;
        }

        public bool IsEnPassant
        {
            get { return isEnPassant; }
            set { isEnPassant = value; }
        }
    }
}
