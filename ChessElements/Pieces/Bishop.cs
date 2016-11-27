using ChessElements.Extensions;
using System.Collections.Generic;
using System.Linq;
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

        #region Public Method

        /// <summary>
        /// Method to get the move list of a Bishop
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public override List<Tile> GetMoveList(Tile tile)
        {
            if (tile == null) return null;
            if (tile.Piece == null) return null;

            var list = new List<Tile>();
            var canMovePP = true;
            var canMovePN = true;
            var canMoveNP = true;
            var canMoveNN = true;
            for (int i = 1; i < 8; i++)
            {
                if (canMovePP)
                {
                    var pprow = (int)tile.Row + i;
                    var ppcol = (int)tile.Column + i;
                    canMovePP = tile.GetNextMove(list, pprow, ppcol);
                }
                if (canMovePN)
                {
                    var pnrow = (int)tile.Row + i;
                    var pncol = (int)tile.Column - i;
                    canMovePN = tile.GetNextMove(list, pnrow, pncol);
                }
                if (canMoveNP)
                {
                    var nprow = (int)tile.Row - i;
                    var npcol = (int)tile.Column + i;
                    canMoveNP = tile.GetNextMove(list, nprow, npcol);
                }
                if (canMoveNN)
                {
                    var nnrow = (int)tile.Row - i;
                    var nncol = (int)tile.Column - i;
                    canMoveNN = tile.GetNextMove(list, nnrow, nncol);
                }
            }
            return list;
        }

        #endregion

        #region Private Method

        #endregion

    }
}
