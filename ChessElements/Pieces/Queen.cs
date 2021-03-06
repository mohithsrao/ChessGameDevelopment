﻿using ChessElements.Extensions;
using ChessInfrastructure.Base;
using ChessInfrastructure.Interfaces;
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
        public override List<MoveBase> GetMoveList(IDropable droppedTile)
        {
            var tile = droppedTile as Tile;
            if (tile == null) return null;
            var list = new List<MoveBase>();
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
                    ppdCanMove = tile.GetNextMove(ref list, row, column);
                }
                if (npdCanMove)
                {
                    var row = (int)tile.Row - i;
                    var column = (int)tile.Column + i;
                    npdCanMove = tile.GetNextMove(ref list, row, column);
                }
                if (pndCanMove)
                {
                    var row = (int)tile.Row + i;
                    var column = (int)tile.Column - i;
                    pndCanMove = tile.GetNextMove(ref list, row, column);
                }
                if (nndCanMove)
                {
                    var row = (int)tile.Row - i;
                    var column = (int)tile.Column - i;
                    nndCanMove = tile.GetNextMove(ref list, row, column);
                }
                //Right Angled moves
                if (pphCanMove)
                {
                    var row = (int)tile.Row;
                    var column = (int)tile.Column + i;
                    pphCanMove = tile.GetNextMove(ref list, row, column);
                }
                if (pnhCanMove)
                {
                    var row = (int)tile.Row;
                    var column = (int)tile.Column - i;
                    pnhCanMove = tile.GetNextMove(ref list, row, column);
                }
                if (nphCanMove)
                {
                    var row = (int)tile.Row + i;
                    var column = (int)tile.Column;
                    nphCanMove = tile.GetNextMove(ref list, row, column);
                }
                if (nnhCanMove)
                {
                    var row = (int)tile.Row - i;
                    var column = (int)tile.Column;
                    nnhCanMove = tile.GetNextMove(ref list, row, column);
                }
            }

            return list;
        }

        #endregion

    }
}
