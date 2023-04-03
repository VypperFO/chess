﻿namespace Echec.model.pieces
{
    public class Knight : Piece
    {
        public Knight() { }
        public Knight(char type, Piece[] pieces): base(type, pieces)
        {
        }

        public override bool PlayMove(int startIndex, int endIndex)
        {
            int startX = startIndex % 8;
            int startY = startIndex / 8;
            int endX = endIndex % 8;
            int endY = endIndex / 8;

            int deltaX = Math.Abs(startX - endX);
            int deltaY = Math.Abs(startY - endY);

            if ((deltaX == 1 && deltaY == 2) || (deltaX == 2 && deltaY == 1) && !SameColor(endIndex))
            {
                return true;
            }

            return false;
        }
    }
}