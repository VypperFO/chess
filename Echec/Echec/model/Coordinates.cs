namespace ChessGame.model
{
    public class Coordinates
    {
        public int XStart { get; set; } // cordonnees de depart X
        public int YStart { get; set; } // cordonnees de depart Y
        public int XDestination { get; set; } // cordonnees de destination X
        public int YDestination { get; set; } // cordonnees de destination Y

        public Coordinates() { }

        public Coordinates(int xStart, int yStart, int xDestination, int yDestination)
        {
            XStart = xStart;
            YStart = yStart;
            XDestination = xDestination;
            YDestination = yDestination;
        }
    }
}
