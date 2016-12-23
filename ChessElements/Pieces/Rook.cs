using ChessElements.Extensions;
using ChessInfrastructure.Base;
using ChessInfrastructure.Interfaces;
using System.Collections.Generic;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Rook : PieceBase
    {
        #region Constructor
        public Rook(PieceColor color)
        {
            base.Color = color;
            base.Type = PieceType.Rook;
        }
        #endregion

        #region Public Methods

        public override List<MoveBase> GetMoveList(IDropable droppedTile)
        {
            var tile = droppedTile as Tile;
            if (tile == null) return null;
            if (tile.IsEmptyTile) return null;

            var list = new List<MoveBase>();
            var ppcanMove = true;
            var pncanMove = true;
            var npcanMove = true;
            var nncanMove = true;
            for (int i = 1; i <= 8; i++)
            {
                if(ppcanMove)
                {
                    var row = (int)tile.Row;
                    var column = (int)tile.Column + i;
                    ppcanMove = tile.GetNextMove(ref list, row, column);
                }
                if (pncanMove)
                {
                    var row = (int)tile.Row;
                    var column = (int)tile.Column - i;
                    pncanMove = tile.GetNextMove(ref list, row, column);
                }
                if (npcanMove)
                {
                    var row = (int)tile.Row + i;
                    var column = (int)tile.Column;
                    npcanMove = tile.GetNextMove(ref list, row, column);
                }
                if (nncanMove)
                {
                    var row = (int)tile.Row - i;
                    var column = (int)tile.Column;
                    nncanMove = tile.GetNextMove(ref list, row, column);
                }
            }

            return list;
        }

        #endregion

        #region Private Methods
        
        #endregion
    }
}
