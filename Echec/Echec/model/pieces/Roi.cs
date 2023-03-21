using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec.model.pieces
{
    public class Roi: PieceSpecial
    {
        public Roi() { }
        public Roi(string name, bool isMoved) 
        {
            Name = name;
            IsMoved = isMoved;
        }
    }
}
