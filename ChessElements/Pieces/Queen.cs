using ChessElements.Extensions;
using System;
using System.Collections.Generic;
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

        #region Public Methods

        /// <summary>
        /// Gets the move list for Queen
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public override List<Tile> GetMoveList(Tile tile)
        {
            var list = new List<Tile>();
            bool ppdCanMove = true, 
                npdCanMove = true, 
                pndCanMove = true, 
                nndCanMove = true, 
                pphCanMove = true, 
                pnhCanMove = true, 
                nphCanMove = true,
                nnhCanMove = true;
            for (int i = 1; i <= 8; i++)
            {
                //Diagonal Moves
                if(ppdCanMove)
                {
                    var row = (int)tile.Row + i;
                    var column = (int)tile.Column + i;
                    ppdCanMove = tile.GetNextMove(list, row, column);
                }
                if (npdCanMove)
                {
                    var row = (int)tile.Row - i;
                    var column = (int)tile.Column + i;
                    npdCanMove = tile.GetNextMove(list, row, column);
                }
                if (pndCanMove)
                {
                    var row = (int)tile.Row + i;
                    var column = (int)tile.Column - i;
                    pndCanMove = tile.GetNextMove(list, row, column);
                }
                if (nndCanMove)
                {
                    var row = (int)tile.Row - i;
                    var column = (int)tile.Column - i;
                    nndCanMove = tile.GetNextMove(list, row, column);
                }
                //Right Angled moves
                if (pphCanMove)
                {
                    var row = (int)tile.Row;
                    var column = (int)tile.Column + i;
                    pphCanMove = tile.GetNextMove(list, row, column);
                }
                if (pnhCanMove)
                {
                    var row = (int)tile.Row;
                    var column = (int)tile.Column - i;
                    pnhCanMove = tile.GetNextMove(list, row, column);
                }
                if (nphCanMove)
                {
                    var row = (int)tile.Row + i;
                    var column = (int)tile.Column;
                    nphCanMove = tile.GetNextMove(list, row, column);
                }
                if (nnhCanMove)
                {
                    var row = (int)tile.Row - i;
                    var column = (int)tile.Column;
                    nnhCanMove = tile.GetNextMove(list, row, column);
                }
            }

            return list;
        }

        #endregion

    }
}
