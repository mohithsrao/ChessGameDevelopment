using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Pawn : PieceBase
    {
        #region Constructor
        public Pawn(PieceColor player)
        {
            base.Player = player;
            base.Type = PieceType.Pawn;
        }
        #endregion

    }
}
