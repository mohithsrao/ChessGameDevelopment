using ChessElements.Moves;
using ChessInfrastructure.Base;
using System.Collections.Generic;
using System.Linq;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Extensions
{
    public static class ListExtension
    {
        public static void AssignBackground(this List<MoveBase> list,Tile movedTile)
        {
            foreach (var item in list)
            {
                var tile = ChessBoard.Instance.Board.FirstOrDefault(x => x.Row == item.Row && x.Column == item.Column);
                if((item.Type == MoveType.Attack && (item as AttackMove).AttackedPiece == null) || 
                   (item.Type == MoveType.Attack && (item as AttackMove).AttackedPiece != null && movedTile.Piece.Color == tile.Piece.Color))
                {
                    tile.Background = TileBackground.Transparent;
                }
                else if (item.Type == MoveType.Attack && (item as AttackMove).AttackedPiece != null && movedTile.Piece.Color != tile.Piece.Color)
                {
                    tile.Background = TileBackground.Red;
                }
                else
                {
                    tile.Background = TileBackground.Green;
                }
            }
        }
    }
}
