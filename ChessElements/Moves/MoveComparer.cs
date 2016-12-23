using ChessInfrastructure.Base;
using System.Collections.Generic;

namespace ChessElements.Moves
{
    class MoveComparer : IEqualityComparer<MoveBase>
    {
        bool IEqualityComparer<MoveBase>.Equals(MoveBase x, MoveBase y)
        {
            return x.Row == y.Row && x.Column == y.Column;
        }

        int IEqualityComparer<MoveBase>.GetHashCode(MoveBase move)
        {
            return move.Column.GetHashCode() + move.Row.GetHashCode();
        }
    }
}
