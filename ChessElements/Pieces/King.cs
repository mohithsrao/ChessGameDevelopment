using ChessElements.Extensions;
using ChessInfrastructure.Base;
using ChessInfrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class King : PieceBase
    {
        #region Constructor
        public King(PieceColor color)
        {
            base.Color = color;
            base.Type = PieceType.King;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Get move list for King
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public override List<MoveBase> GetMoveList(IDropable dropedTile)
        {
            var tile = dropedTile as Tile;
            if (tile == null) return null;

            var enemyMoves = GetAllEnemyPiecesMoveList(tile);
            var list = new List<MoveBase>();
            var i = 1;
            //Diagonal Moves
            var ppdrow = (int)tile.Row + i;
            var ppdcolumn = (int)tile.Column + i;
            tile.GetNextMove(ref list, ppdrow, ppdcolumn);

            var npdrow = (int)tile.Row - i;
            var npdcolumn = (int)tile.Column + i;
            tile.GetNextMove(ref list, npdrow, npdcolumn);

            var pndrow = (int)tile.Row + i;
            var pndcolumn = (int)tile.Column - i;
            tile.GetNextMove(ref list, pndrow, pndcolumn);

            var nndrow = (int)tile.Row - i;
            var nndcolumn = (int)tile.Column - i;
            tile.GetNextMove(ref list, nndrow, nndcolumn);

            //Right Angled moves
            var pphrow = (int)tile.Row;
            var pphcolumn = (int)tile.Column + i;
            tile.GetNextMove(ref list, pphrow, pphcolumn);

            var pnhrow = (int)tile.Row;
            var pnhcolumn = (int)tile.Column - i;
            tile.GetNextMove(ref list, pnhrow, pnhcolumn);

            var nphrow = (int)tile.Row + i;
            var nphcolumn = (int)tile.Column;
            tile.GetNextMove(ref list, nphrow, nphcolumn);

            var nnhrow = (int)tile.Row - i;
            var nnhcolumn = (int)tile.Column;
            tile.GetNextMove(ref list, nnhrow, nnhcolumn);

            var finalList = list.Except(enemyMoves);

            return finalList.ToList();
        }

        private IEnumerable<MoveBase> GetAllEnemyPiecesMoveList(Tile kingTile)
        {
            var list = new List<MoveBase>();
            var enemyTiles = ChessBoard.Instance.Board.Where(x => (!x.IsEmptyTile && x.Piece.Color != kingTile.Piece.Color && x.Piece.Type != PieceType.King));

            foreach (var tile in enemyTiles)
            {
                list.AddRange(tile.Piece.GetMoveList(tile));
            }            

            return list.Distinct<MoveBase>();
        }

        #endregion
    }
}
