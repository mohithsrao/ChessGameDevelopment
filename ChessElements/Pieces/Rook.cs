using System;
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

        public override List<Tile> GetMoveList(Tile tile)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
