﻿using System.Collections.Generic;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Pawn : PieceBase
    {
        #region Private Variables
        
        private const int SQUAREAREALENGTH = 5;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor that takes in the Piece color 
        /// </summary>
        /// <param name="player"></param>
        public Pawn(PieceColor color)
        {
            base.Color = color;
            base.Type = PieceType.Pawn;
        }

        #endregion

        #region Private Methods

        private List<Tile> GetList(Tile[,] list,Tile tile)
        {
            var moveList = new List<Tile>();
            int maxDistance = ((tile.Row == Rows.Two && tile.Piece.Color == PieceColor.White)|| (tile.Row == Rows.Seven && tile.Piece.Color == PieceColor.Black)) ? 2 : 1;
            var center = (SQUAREAREALENGTH / 2);
            for (int i = 1; i <= maxDistance; i++)
            {
                var nextTile = list[(tile.Piece.Color == PieceColor.White) ? center - i : center + i, center];
                
                if (nextTile.IsEmptyTile)
                {
                    nextTile.Background = TileBackground.Green;
                    moveList.Add(nextTile);
                }
            }
            return moveList;
        }

        #endregion

        #region Public Methods

        public override void Move(Tile fromTile,Tile toTile)
        {

        }

        public override List<Tile> GetMoveList(Tile tile)
        {
            var listArea = ChessBoard.Instance.GetSurroundingTiles(tile, SQUAREAREALENGTH);
            var list = GetList(listArea, tile);
            return list;
        }

        #endregion
    }
}
