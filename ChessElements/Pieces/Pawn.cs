using System.Collections.Generic;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Pawn : PieceBase
    {
        #region Private Variables
        
        private const int SQUAREAREALENGTH = 5;//Length of the 2D Array
        private const int CENTER = 2;//Center of the 2D Array

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

        /// <summary>
        /// Method to fetch all the move list of the Pawn in 2D Array.
        /// It Takes into consideration the PieceColor and Starting Location to determine the piece distance
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tile"></param>
        /// <returns></returns>
        private List<Tile> GetList(Tile[,] list,Tile tile)
        {
            var moveList = new List<Tile>();
            int maxDistance = ((tile.Row == Rows.Two && tile.Piece.Color == PieceColor.White)|| (tile.Row == Rows.Seven && tile.Piece.Color == PieceColor.Black)) ? 2 : 1;//Determins the distane the piece can travel based on the start position
            for (int i = 1; i <= maxDistance; i++)//Iterates of the number of steps the Pawn can take
            {
                var nextTile = list[(tile.Piece.Color == PieceColor.White) ? CENTER - i : CENTER + i, CENTER];//Gets the tile at the location required from the Board
                if (nextTile != null)
                {
                    if (nextTile.IsEmptyTile)//Possible Move on an Empty tile
                    {
                        nextTile.Background = TileBackground.Green;
                        moveList.Add(nextTile);
                    }
                    if (maxDistance == 1)//If Pawn not in Starting position Get the Diagonal Tiles
                    {
                        var diaOne = GetDiagonalTileMove(list, tile, maxDistance, true);//Right Diagonal Tile
                        if(diaOne != null)
                        {
                            moveList.Add(diaOne);
                        }
                        var diaTwo = GetDiagonalTileMove(list, tile, maxDistance, false);//Left Diagonal Tile
                        if (diaTwo != null)
                        {
                            moveList.Add(diaTwo);
                        }
                    }
                }
            }
            return moveList;
        }

        /// <summary>
        /// Method to get the diagonal tile if enemy Piece exists
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tile"></param>
        /// <param name="distance"></param>
        /// <param name="rightDiagonal"></param>
        /// <returns></returns>
        private Tile GetDiagonalTileMove(Tile[,] list, Tile tile,int distance,bool rightDiagonal)
        {
            var i = (tile.Piece.Color == PieceColor.White) ? CENTER - distance : CENTER + distance;
            var j = rightDiagonal ? CENTER - distance : CENTER + distance;
            var diagTile = list[i, j];
            if (diagTile != null)
            {
                if (!diagTile.IsEmptyTile && diagTile.Piece.Color != tile.Piece.Color)
                {
                    diagTile.Background = TileBackground.Red;
                    return diagTile;
                }
            }
            return null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to get all the moves for a Pawn including Capturing and Normal move
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public override List<Tile> GetMoveList(Tile tile)
        {
            var listArea = ChessBoard.Instance.GetSurroundingTiles(tile, SQUAREAREALENGTH);
            var list = GetList(listArea, tile);
            return list;
        }

        #endregion
    }
}
