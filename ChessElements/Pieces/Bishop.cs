using System;
using System.Collections.Generic;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Bishop : PieceBase
    {
        #region Constructor
        public Bishop(PieceColor color)
        {
            base.Color = color;
            base.Type = PieceType.Bishop;
        }
        #endregion

        #region Public Method
        public override List<Tile> GetMoveList(Tile tile)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
