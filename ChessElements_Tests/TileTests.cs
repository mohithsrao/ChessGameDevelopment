using ChessElements.Pieces;
using ChessInfrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Tests
{
    [TestClass()]
    public class TileTests
    {
        [TestMethod()]
        public void RemoveTile_Test()
        {
            //When Passed value is null
            var tile = new Tile(Rows.Four, Columns.E, new Pawn(PieceColor.Black));
            var dragTile = (tile as IDragable);

            dragTile.Remove(null);

            Assert.IsNull(tile.Piece);

            //When Piece is present
            var tileZero = new Tile(Rows.Four, Columns.E,new Pawn(PieceColor.Black));
            var dragableTile = (tileZero as IDragable);

            dragableTile.Remove(new object());

            Assert.IsNull(tileZero.Piece);

            //When Piece is not present
            var tileone = new Tile(Rows.Four, Columns.E);
            var dragableTileone = (tileone as IDragable);

            dragableTileone.Remove(new object());

            Assert.IsNull(tileone.Piece);
        }

        [TestMethod()]
        public void DropTile_Test()
        {
            //When Piece is Droped on other tile 
            var tileone = new Tile(Rows.Four, Columns.E);
            var dragableTileone = (tileone as IDragable);

            dragableTileone.Remove(new object());

            Assert.IsNull(tileone.Piece);
        }
    }
}