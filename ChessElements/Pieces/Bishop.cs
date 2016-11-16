using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Bishop : PieceBase
    {
        #region Constructor
        public Bishop(PieceColor player)
        {
            base.Player = player;
            base.Type = PieceType.Bishop;
        }
        #endregion

    }
}
