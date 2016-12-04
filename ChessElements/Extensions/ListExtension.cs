using System.Collections.Generic;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Extensions
{
    public static class ListExtension
    {
        public static void AssignBackground(this List<Tile> list)
        {
            foreach (var item in list)
            {
                item.Background = item.IsEmptyTile ? TileBackground.Green : TileBackground.Red;
            }
        }
    }
}
