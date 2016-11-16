using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Rook : PieceBase
    {
        #region Constructor
        public Rook(PieceColor player)
        {
            base.Player = player;
            base.Type = PieceType.Rook;
        }
        #endregion

    }
}
