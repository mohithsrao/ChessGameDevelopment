using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Knight : PieceBase
    {
        #region Constructor
        public Knight(PieceColor player)
        {
            base.Player = player;
            base.Type = PieceType.Knight;
        }
        #endregion

    }
}
