using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class King : PieceBase
    {
        #region Constructor
        public King(PieceColor player)
        {
            base.Player = player;
            base.Type = PieceType.King;
        }
        #endregion

    }
}
