using ChessInfrastructure.Base;
using System.Collections.Generic;
using System.Linq;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Extensions
{
    public static class ListExtension
    {
        public static void AssignBackground(this List<MoveBase> list)
        {
            foreach (var item in list)
            {
                var tile = ChessBoard.Instance.Board.FirstOrDefault(x => x.Row == item.row && x.Column == item.column);
                tile.Background = item.Type == MoveType.Normal ? TileBackground.Green : TileBackground.Red;
            }
        }
    }
}
