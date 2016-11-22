using System;
using System.Collections.Generic;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Queen : PieceBase
    {
        #region Constructor
        public Queen(PieceColor color)
        {
            base.Color = color;
            base.Type = PieceType.Queen;
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
