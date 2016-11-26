using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ChessElements.Pieces.Tests
{
    [TestClass()]
    public class PawnTests
    {
        [TestMethod()]
        public void Pawn_GetMoveList_Test()
        {
            //Test for empty piece
            var piece = new Pawn(ChessInfrastructure.ChessEnums.PieceColor.Black);
            var tileE8 = new Tile(ChessInfrastructure.ChessEnums.Rows.Eight, ChessInfrastructure.ChessEnums.Columns.A);
            
            var listE8 = piece.GetMoveList(tileE8);
            if (!tileE8.IsEmptyTile)
            {
                Assert.IsTrue(listE8.Count > 1);
            }
            else
            {
                Assert.IsTrue(listE8== null);
            }

            //Test for Seven A 2 moves
            var tilesev8 = new Tile(ChessInfrastructure.ChessEnums.Rows.Seven, ChessInfrastructure.ChessEnums.Columns.A,piece);

            var listsev8 = piece.GetMoveList(tilesev8);
                Assert.IsTrue(listsev8.Count == 2);

            //Test for Seven G White with piece in front 3 moves
            var tilesevG = new Tile(ChessInfrastructure.ChessEnums.Rows.Seven, ChessInfrastructure.ChessEnums.Columns.G, piece);
            var pieceInFrontWite = ChessBoard.Instance.Board.FirstOrDefault(x => x.Row == ChessInfrastructure.ChessEnums.Rows.Six && x.Column == ChessInfrastructure.ChessEnums.Columns.H);
            pieceInFrontWite.Piece = new Pawn(ChessInfrastructure.ChessEnums.PieceColor.White);

            var listsevG = piece.GetMoveList(tilesevG);
            Assert.IsTrue(listsevG.Count == 3);
            Assert.IsTrue(listsevG.Where(x => x.Background == ChessInfrastructure.ChessEnums.TileBackground.Red).Count() == 1);
            Assert.IsTrue(listsevG.Where(x => x.Background == ChessInfrastructure.ChessEnums.TileBackground.Green).Count() == 2);

            //Test for Seven H with piece in front 0 moves
            var tilesevH = new Tile(ChessInfrastructure.ChessEnums.Rows.Seven, ChessInfrastructure.ChessEnums.Columns.H, piece);
            var pieceInFront = ChessBoard.Instance.Board.FirstOrDefault(x => x.Row == ChessInfrastructure.ChessEnums.Rows.Six && x.Column == ChessInfrastructure.ChessEnums.Columns.H);
            pieceInFront.Piece = new Pawn(ChessInfrastructure.ChessEnums.PieceColor.Black);

            var listsevH = piece.GetMoveList(tilesevH);
            Assert.IsTrue(listsevH.Count == 0);
        }
    }
}