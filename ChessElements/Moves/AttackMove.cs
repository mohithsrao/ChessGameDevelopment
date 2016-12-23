using ChessInfrastructure.Base;
using ChessInfrastructure;

namespace ChessElements.Moves
{
    public class AttackMove : MoveBase
    {
        public AttackMove(ChessEnums.Rows _row, ChessEnums.Columns _column, PieceBase _attackedPiece) : base(_row, _column)
        {
            Type = ChessEnums.MoveType.Attack;
            AttackedPiece = _attackedPiece;
        }

        public PieceBase AttackedPiece { get; private set; }
    }
}
