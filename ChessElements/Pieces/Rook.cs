using ChessElements.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public override List<Tile> GetMoveList(Tile tile)
        {
            if (tile == null) return null;
            if (tile.IsEmptyTile) return null;

            var list = new List<Tile>();
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
                    ppcanMove = tile.GetNextMove(list, row, column);
                }
                if (pncanMove)
                {
                    var row = (int)tile.Row;
                    var column = (int)tile.Column - i;
                    pncanMove = tile.GetNextMove(list, row, column);
                }
                if (npcanMove)
                {
                    var row = (int)tile.Row + i;
                    var column = (int)tile.Column;
                    npcanMove = tile.GetNextMove(list, row, column);
                }
                if (nncanMove)
                {
                    var row = (int)tile.Row - i;
                    var column = (int)tile.Column;
                    nncanMove = tile.GetNextMove(list, row, column);
                }
            }

            return list;
        }

        #endregion

        #region Private Methods
        
        #endregion
    }
}
