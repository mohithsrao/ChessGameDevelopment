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

    }
}
