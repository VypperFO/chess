﻿namespace Echec.model
{
    public class Coordonnée
    {
        private int xStart;
        private int yStart;
        private int xDestination;
        private int yDestination;

        public Coordonnée(int xStart, int yStart, int xDestination, int yDestination)
        {
            XStart = xStart;
            YStart = yStart;
            XDestination = xDestination;
            YDestination = yDestination;
        }

        public int XStart
        {
            get { return xStart; }
            set { xStart = value; }
        }
        public int YStart
        {
            get { return yStart; }
            set { yStart = value; }
        }
        public int XDestination
        {
            get { return xDestination; }
            set { xDestination = value; }
        }
        public int YDestination
        {
            get { return yDestination; }
            set { yDestination = value; }
        }
    }
}
