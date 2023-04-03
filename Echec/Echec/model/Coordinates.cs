namespace Echec.model
{
    public class Coordinates
    {
        public int XStart { get; set; }
        public int YStart { get; set; }
        public int XDestination { get; set; }
        public int YDestination { get; set; }

        public Coordinates(int xStart, int yStart, int xDestination, int yDestination)
        {
            XStart = xStart;
            YStart = yStart;
            XDestination = xDestination;
            YDestination = yDestination;
        }
    }
}
