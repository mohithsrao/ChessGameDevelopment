using System;

namespace ChessElements.Extensions
{
    public static class TileExtensions
    {
        /// <summary>
        /// Method to get the distance between two tiles
        /// </summary>
        /// <param name="fromTile"></param>
        /// <param name="toTile"></param>
        /// <returns></returns>
        public static double GetDistance(this Tile fromTile,Tile toTile)
        {
            return Math.Sqrt(Math.Pow(((int)fromTile.Row - (int)toTile.Row), 2) + Math.Pow(((int)fromTile.Column - (int)toTile.Column), 2));
        }
    }
}
