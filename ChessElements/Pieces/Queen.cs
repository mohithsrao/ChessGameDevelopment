using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Queen : PieceBase
    {
        #region Constructor
        public Queen(PieceColor player)
        {
            base.Player = player;
            base.Type = PieceType.Queen;
        }
        #endregion

    }
}
