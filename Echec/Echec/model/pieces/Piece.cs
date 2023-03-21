using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echec.model.pieces
{
    public abstract class Piece
    {
        protected string name = "";

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
