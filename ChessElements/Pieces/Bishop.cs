using ChessElements.Extensions;
using ChessInfrastructure.Base;
using System.Collections.Generic;
using static ChessInfrastructure.ChessEnums;
using ChessInfrastructure.Interfaces;

namespace ChessElements.Pieces
{
    public class Bishop : PieceBase
    {
        #region Properties

        #endregion
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
        public override List<MoveBase> GetMoveList(IDropable dropedTile)
        {
            var tile = dropedTile as Tile;
            if (tile == null) return null;
            if (tile.Piece == null) return null;

            var list = new List<MoveBase>();
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
                    canMovePP = tile.GetNextMove(ref list, pprow, ppcol);
                }
                if (canMovePN)
                {
                    var pnrow = (int)tile.Row + i;
                    var pncol = (int)tile.Column - i;
                    canMovePN = tile.GetNextMove(ref list, pnrow, pncol);
                }
                if (canMoveNP)
                {
                    var nprow = (int)tile.Row - i;
                    var npcol = (int)tile.Column + i;
                    canMoveNP = tile.GetNextMove(ref list, nprow, npcol);
                }
                if (canMoveNN)
                {
                    var nnrow = (int)tile.Row - i;
                    var nncol = (int)tile.Column - i;
                    canMoveNN = tile.GetNextMove(ref list, nnrow, nncol);
                }
            }
            return list;
        }

        #endregion

        #region Private Method

        #endregion

    }
}
