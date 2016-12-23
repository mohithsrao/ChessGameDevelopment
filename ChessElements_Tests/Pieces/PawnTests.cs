using ChessElements.Extensions;
using ChessElements.Moves;
using ChessInfrastructure;
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
            var piece = new Pawn(ChessEnums.PieceColor.Black);
            var tileE8 = new Tile(ChessEnums.Rows.Eight, ChessEnums.Columns.A);
            
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
            var tilesev8 = new Tile(ChessEnums.Rows.Seven, ChessEnums.Columns.A,piece);

            var listsev8 = piece.GetMoveList(tilesev8).Where(x => x.Type != ChessEnums.MoveType.Attack);
            //listsev8.AssignBackground();
            Assert.IsTrue(listsev8.Count() == 2);

            //Test for Seven G White with piece in front 3 moves
            var tilesevG = new Tile(ChessEnums.Rows.Seven, ChessEnums.Columns.G, piece);
            var pieceInFrontWite = ChessBoard.Instance.Board.FirstOrDefault(x => x.Row == ChessEnums.Rows.Six && x.Column == ChessEnums.Columns.H);
            pieceInFrontWite.Piece = new Pawn(ChessEnums.PieceColor.White);

            var listsevG = piece.GetMoveList(tilesevG);
            //listsevG.AssignBackground();
            Assert.IsTrue(listsevG.Count == 4);
            Assert.IsTrue(listsevG.Where(x => x.Type == ChessEnums.MoveType.Attack && (x as AttackMove).AttackedPiece != null).Count() == 1);
            Assert.IsTrue(listsevG.Where(x => x.Type == ChessEnums.MoveType.Normal).Count() == 2);

            //Test for Seven H with piece in front 0 moves
            var tilesevH = new Tile(ChessEnums.Rows.Seven, ChessEnums.Columns.H, piece);
            var pieceInFront = ChessBoard.Instance.Board.FirstOrDefault(x => x.Row == ChessEnums.Rows.Six && x.Column == ChessEnums.Columns.H);
            pieceInFront.Piece = new Pawn(ChessEnums.PieceColor.Black);

            var listsevH = piece.GetMoveList(tilesevH);
            Assert.IsTrue(listsevH.Count == 1);
        }
    }
}