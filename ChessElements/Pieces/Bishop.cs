using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Bishop : PieceBase
    {
        #region Constructor
        public Bishop(PieceColor color)
        {
            base.Color = color;
            base.Type = PieceType.Bishop;
        }
        #endregion

    }
}
