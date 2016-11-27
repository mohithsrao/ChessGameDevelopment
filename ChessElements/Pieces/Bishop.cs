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
                    canMovePP = PopulateDiagonalMove(tile, list, pprow, ppcol);
                }

                if (canMovePN)
                {
                    var pnrow = (int)tile.Row + i;
                    var pncol = (int)tile.Column - i;
                    canMovePN = PopulateDiagonalMove(tile, list, pnrow, pncol);
                }
                if (canMoveNP)
                {
                    var nprow = (int)tile.Row - i;
                    var npcol = (int)tile.Column + i;
                    canMoveNP = PopulateDiagonalMove(tile, list, nprow, npcol);
                }
                if (canMoveNN)
                {
                    var nnrow = (int)tile.Row - i;
                    var nncol = (int)tile.Column - i;
                    canMoveNN = PopulateDiagonalMove(tile, list, nnrow, nncol);
                }
            }
            return list;
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Method to get the diagonal move
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="list"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool PopulateDiagonalMove(Tile tile, List<Tile> list, int row, int col)
        {
            if ((row >= (int)Rows.Eight && row <= (int)Rows.One) && (col >= (int)Columns.A && col <= (int)Columns.H))
            {
                var nxtTile = ChessBoard.Instance.Board.FirstOrDefault(x => (int)x.Row == row && (int)x.Column == col);
                if (nxtTile.IsEmptyTile)
                {
                    nxtTile.Background = TileBackground.Green;
                    list.Add(nxtTile);
                    return true;
                }
                else if (nxtTile.Piece.Color != tile.Piece.Color)
                {
                    nxtTile.Background = TileBackground.Red;
                    list.Add(nxtTile);
                }
            }
            return false;
        }

        #endregion

    }
}
