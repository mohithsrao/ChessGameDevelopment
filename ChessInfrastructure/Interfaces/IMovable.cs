using ChessInfrastructure.Base;
using System.Collections.Generic;

namespace ChessInfrastructure.Interfaces
{
    public interface IMovable
    {
        /// <summary>
        /// Virtual method that get all possible moves of the piece on the tile
        /// </summary>
        /// <param name="tile"></param>
        List<MoveBase> GetMoveList(IDropable tile);
    }
}
