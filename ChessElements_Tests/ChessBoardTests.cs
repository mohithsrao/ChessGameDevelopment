using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static ChessInfrastructure.ChessEnums;
using ChessElements_Tests.Resources;

namespace ChessElements.Tests
{
    [TestClass()]
    public class ChessBoardTests
    {
        [TestMethod()]
        public void GetSurroundingTiles_tilePassedIsNull_Test()
        {
            //Arrange
            Tile tile = null;
            var areaLength = 5;
            //Act
            try
            {
                ChessBoard.Instance.GetSurroundingTiles(tile, areaLength);
            }
            catch (ArgumentNullException ex)
            {
                StringAssert.Contains(ex.Message, "Tile cannot be empty");
                return;
            }
            //Assert
            Assert.Fail(Resource.NoException);
        }

        [TestMethod()]
        public void GetSurroundingTiles_lengthPassedIsEven_Test()
        {
            //Arrange
            Tile tile = new Tile(Rows.Four, Columns.D);
            var areaLength = 4;
            //Act
            try
            {
                ChessBoard.Instance.GetSurroundingTiles(tile, areaLength);
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, "cannot be an even number");
                return;
            }
            //Assert
            Assert.Fail(Resource.NoException);
        }

        [TestMethod()]
        public void GetSurroundingTiles_GetCenterTiles_Test()
        {
            //Check for null return
            Tile tileD4 = new Tile(Rows.Four, Columns.D);
            var areaLength = 5;
            var list = ChessBoard.Instance.GetSurroundingTiles(tileD4, areaLength);
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Cast<Tile>().Where(x => x == null).Count() == 0);//All the tiles must be inside the board
        }

        [TestMethod()]
        public void GetSurroundingTiles_GetCornerTiles_Test()
        {
            var areaLength = 5;
            //Check for corner tile A1
            Tile tileA1 = new Tile(Rows.One, Columns.A);
            var listA1 = ChessBoard.Instance.GetSurroundingTiles(tileA1, areaLength);
            Assert.IsNotNull(listA1);
            Assert.IsTrue(listA1.Cast<Tile>().Where(x => x != null).Count() == 9);//Only 9 tiles must be inside the board

            //Check for corner tile A8
            Tile tileA8 = new Tile(Rows.Eight, Columns.A);
            var listA8 = ChessBoard.Instance.GetSurroundingTiles(tileA8, areaLength);
            Assert.IsNotNull(listA8);
            Assert.IsTrue(listA8.Cast<Tile>().Where(x => x != null).Count() == 9);//Only 9 tiles must be inside the board

            //Check for corner tile H1
            Tile tileH1 = new Tile(Rows.One, Columns.H);
            var listH1 = ChessBoard.Instance.GetSurroundingTiles(tileH1, areaLength);
            Assert.IsNotNull(listH1);
            Assert.IsTrue(listH1.Cast<Tile>().Where(x => x != null).Count() == 9);//Only 9 tiles must be inside the board

            //Check for corner tile H8
            Tile tileH8 = new Tile(Rows.Eight, Columns.H);
            var listH8 = ChessBoard.Instance.GetSurroundingTiles(tileH8, areaLength);
            Assert.IsNotNull(listH8);
            Assert.IsTrue(listH8.Cast<Tile>().Where(x => x != null).Count() == 9);//Only 9 tiles must be inside the board
        }

        [TestMethod()]
        public void ClearHighLight_Test()
        {
            ChessBoard.Instance.Clearhighlights();

            Assert.IsTrue(ChessBoard.Instance.Board.All(x => x.Background == TileBackground.Transparent));
        }
    }
}