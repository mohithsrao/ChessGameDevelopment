using ChessElements.Extensions;
using ChessElements.Moves;
using ChessInfrastructure.Base;
using ChessInfrastructure.Interfaces;
using System.Collections.Generic;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Knight : PieceBase
    {
        private const int SQUAREAREALENGTH = 5;//Length of the 2D Array
        private const double KNIGHTMOVEDISTANCE = 2.23606797749979;

        #region Constructor
        public Knight(PieceColor color)
        {
            base.Color = color;
            base.Type = PieceType.Knight;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to get the List of moves for Knight
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public override List<MoveBase> GetMoveList(IDropable droppedTile)
        {
            var tile = droppedTile as Tile;
            if (tile == null) return null;
            if (tile.IsEmptyTile) return null;

            var list = new List<MoveBase>();            
            var surroundingList = ChessBoard.Instance.GetSurroundingTiles(tile, SQUAREAREALENGTH);

            foreach (var nxtTile in surroundingList)
            {
                if (nxtTile != null)
                {
                    var dist = nxtTile.GetDistance(tile);
                    if (dist == KNIGHTMOVEDISTANCE)
                    {
                        if (nxtTile.IsEmptyTile)
                        {
                            list.Add(new NormalMove(nxtTile.Row,nxtTile.Column));
                            continue;
                        }
                        else if (nxtTile.Piece.Color != tile.Piece.Color)
                        {
                            list.Add(new AttackMove(nxtTile.Row, nxtTile.Column, nxtTile.Piece));
                        }
                    }
                }
            }
            return list;
        }

        #endregion

        #region Private Methods
        
        #endregion
    }
}
