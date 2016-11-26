using System;
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
        public override List<Tile> GetMoveList(Tile tile)
        {
            if (tile.IsEmptyTile) return null;

            var list = new List<Tile>();            
            var surroundingList = ChessBoard.Instance.GetSurroundingTiles(tile, SQUAREAREALENGTH);

            foreach (var nxtTile in surroundingList)
            {
                if (nxtTile != null)
                {
                    var dist = GetDistance(nxtTile, tile);
                    if (dist == KNIGHTMOVEDISTANCE)
                    {
                        if (nxtTile.IsEmptyTile)
                        {
                            nxtTile.Background = TileBackground.Green;
                            list.Add(nxtTile);
                            continue;
                        }
                        else if (nxtTile.Piece.Color != tile.Piece.Color)
                        {
                            nxtTile.Background = TileBackground.Red;
                            list.Add(nxtTile);
                        }
                    }
                }
            }
            return list;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to get the distance between two tiles
        /// </summary>
        /// <param name="fromTile"></param>
        /// <param name="toTile"></param>
        /// <returns></returns>
        private double GetDistance(Tile fromTile, Tile toTile)
        {
            return Math.Sqrt(Math.Pow(((int)fromTile.Row - (int)toTile.Row),2) + Math.Pow(((int)fromTile.Column - (int)toTile.Column), 2));
        }

        #endregion
    }
}
