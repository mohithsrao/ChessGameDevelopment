using System;
using System.Collections.Generic;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Knight : PieceBase
    {
        #region Constructor
        public Knight(PieceColor color)
        {
            base.Color = color;
            base.Type = PieceType.Knight;
        }

        #endregion

        #region Public Methods

        public override List<Tile> GetMoveList(Tile tile)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
