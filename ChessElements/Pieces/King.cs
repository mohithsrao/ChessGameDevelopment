using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class King : PieceBase
    {
        #region Constructor
        public King(PieceColor color)
        {
            base.Color = color;
            base.Type = PieceType.King;
        }
        #endregion

    }
}
