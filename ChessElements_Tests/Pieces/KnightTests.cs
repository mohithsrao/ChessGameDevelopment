using ChessElements.Extensions;
using ChessInfrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ChessElements.Pieces.Tests
{
    [TestClass()]
    public class KnightTests
    {
        [TestMethod()]
        public void Knight_GetMoveList_Test()
        {
            //Test for empty tile
            var tile = new Tile(ChessEnums.Rows.One, ChessEnums.Columns.A);
            var piece = new Knight(ChessEnums.PieceColor.Black);

            Assert.IsNull(piece.GetMoveList(tile));

            //Test for Corner tiles A1 with Knight
            var A1piece = new Knight(ChessEnums.PieceColor.Black);
            var A1tile = new Tile(ChessEnums.Rows.One, ChessEnums.Columns.A, A1piece);

            var A1List = A1piece.GetMoveList(A1tile);
            //A1List.AssignBackground();

            Assert.IsNotNull(A1List);
            Assert.IsTrue(A1List.Count == 2);
            Assert.IsTrue(A1List.Where(x => x.Type == ChessEnums.MoveType.Normal).Count() == 1);
            Assert.IsTrue(A1List.Where(x => x.Type == ChessEnums.MoveType.Attack).Count() == 1);

            //Test for Corner tiles A8 with Knight
            var A8piece = new Knight(ChessEnums.PieceColor.Black);
            var A8tile = new Tile(ChessEnums.Rows.Eight, ChessEnums.Columns.A, A8piece);

            var A8List = A1piece.GetMoveList(A8tile);
            //A8List.AssignBackground();

            Assert.IsNotNull(A8List);
            Assert.IsTrue(A8List.Count == 1);
            Assert.IsTrue(A8List.Where(x => x.Type == ChessEnums.MoveType.Normal).Count() == 1);

            //Test for Corner tiles H1 with Knight
            var H1piece = new Knight(ChessEnums.PieceColor.Black);
            var H1tile = new Tile(ChessEnums.Rows.One, ChessEnums.Columns.H, H1piece);

            var H1List = A1piece.GetMoveList(H1tile);
            //H1List.AssignBackground();

            Assert.IsNotNull(H1List);
            Assert.IsTrue(H1List.Count == 2);
            Assert.IsTrue(H1List.Where(x => x.Type == ChessEnums.MoveType.Normal).Count() == 1);
            Assert.IsTrue(H1List.Where(x => x.Type == ChessEnums.MoveType.Attack).Count() == 1);


            //Test for Corner tiles H8 with Knight
            var H8piece = new Knight(ChessEnums.PieceColor.Black);
            var H8tile = new Tile(ChessEnums.Rows.Eight, ChessEnums.Columns.H, H8piece);

            var H8List = A1piece.GetMoveList(H8tile);
            //H8List.AssignBackground();

            Assert.IsNotNull(H8List);
            Assert.IsTrue(H8List.Count == 1);
            Assert.IsTrue(H8List.Where(x => x.Type == ChessEnums.MoveType.Normal).Count() == 1);
        }
    }
}