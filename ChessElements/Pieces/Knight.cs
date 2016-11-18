﻿using static ChessInfrastructure.ChessEnums;

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

    }
}
