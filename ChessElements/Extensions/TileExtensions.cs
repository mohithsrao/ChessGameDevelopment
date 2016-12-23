using ChessElements.Moves;
using ChessInfrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Extensions
{
    public static class TileExtensions
    {
        /// <summary>
        /// Method to get the distance between two tiles
        /// </summary>
        /// <param name="fromTile"></param>
        /// <param name="toTile"></param>
        /// <returns></returns>
        public static double GetDistance(this Tile fromTile,Tile toTile)
        {
            return Math.Sqrt(Math.Pow(((int)fromTile.Row - (int)toTile.Row), 2) + Math.Pow(((int)fromTile.Column - (int)toTile.Column), 2));
        }

        /// <summary>
        /// Method to get the next move of a piece
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="list"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static bool GetNextMove(this Tile tile,ref List<MoveBase> list, int row, int column)
        {
            if ((row >= (int)Rows.Eight && row <= (int)Rows.One) && (column >= (int)Columns.A && column <= (int)Columns.H))
            {
                var nxtTile = ChessBoard.Instance.Board.FirstOrDefault(x => (int)x.Row == row && (int)x.Column == column);
                if (nxtTile.IsEmptyTile)
                {
                    list.Add(new NormalMove(nxtTile.Row,nxtTile.Column));
                    return true;
                }
                else if (nxtTile.Piece.Color != tile.Piece.Color)
                {
                    list.Add(new AttackMove(nxtTile.Row, nxtTile.Column, nxtTile.Piece));
                }
            }
            return false;
        }
    }
}
