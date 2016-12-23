using ChessInfrastructure.Base;
using ChessInfrastructure;

namespace ChessElements.Moves
{
    public class NormalMove : MoveBase
    {
        public NormalMove(ChessEnums.Rows _row, ChessEnums.Columns _column) : base(_row, _column)
        {
            Type = ChessEnums.MoveType.Normal;
        }
    }
}
