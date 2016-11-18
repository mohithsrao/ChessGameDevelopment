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

    }
}
