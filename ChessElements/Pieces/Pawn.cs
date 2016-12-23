using ChessElements.Moves;
using ChessInfrastructure.Base;
using ChessInfrastructure.Interfaces;
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
        private List<MoveBase> GetList(Tile[,] list,Tile tile)
        {
            var moveList = new List<MoveBase>();
            int maxDistance = ((tile.Row == Rows.Two && tile.Piece.Color == PieceColor.White)|| (tile.Row == Rows.Seven && tile.Piece.Color == PieceColor.Black)) ? 2 : 1;//Determins the distane the piece can travel based on the start position
            for (int i = 1; i <= maxDistance; i++)//Iterates of the number of steps the Pawn can take
            {
                var nextTile = list[(tile.Piece.Color == PieceColor.White) ? CENTER - i : CENTER + i, CENTER];//Gets the tile at the location required from the Board
                if (nextTile != null)
                {
                    if (nextTile.IsEmptyTile)//Possible Move on an Empty tile
                    {
                        moveList.Add(new NormalMove(nextTile.Row,nextTile.Column));
                    }
                    else
                    {
                        break;//Exit from the loop as Pawn's cannot jump
                    }                    
                }
            }
            var diaOne = GetDiagonalTileMove(list, tile, true);//Right Diagonal Tile
            if (diaOne != null)
            {
                moveList.Add(new AttackMove(diaOne.Row, diaOne.Column, diaOne.Piece));
            }
            var diaTwo = GetDiagonalTileMove(list, tile, false);//Left Diagonal Tile
            if (diaTwo != null)
            {
                moveList.Add(new AttackMove(diaTwo.Row, diaTwo.Column, diaTwo.Piece));
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
        private Tile GetDiagonalTileMove(Tile[,] list, Tile tile,bool rightDiagonal)
        {
            var i = (tile.Piece.Color == PieceColor.White) ? CENTER - 1 : CENTER + 1;
            var j = rightDiagonal ? CENTER - 1 : CENTER + 1;
            var diagTile = list[i, j];
            if (diagTile != null)
            {
                if (!diagTile.IsEmptyTile && diagTile.Piece.Color != tile.Piece.Color)
                {
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
        public override List<MoveBase> GetMoveList(IDropable droppedTile)
        {
            var tile = droppedTile as Tile;
            if (tile == null) return null;
            if (!tile.IsEmptyTile)
            {
                var listArea = ChessBoard.Instance.GetSurroundingTiles(tile, SQUAREAREALENGTH);
                if (listArea != null && listArea.Length > 0)
                {
                    var list = GetList(listArea, tile);
                    return list;
                }
            }
            return null;
        }

        #endregion
    }
}
