using System;
using System.Collections.Generic;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class King : PieceBase
    {
        #region Constructor
        public King(PieceColor color)
        {
            base.Color = color;
            base.Type = PieceType.King;
        }
        #endregion

        #region Publicj Methods

        public override List<Tile> GetMoveList(Tile tile)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
