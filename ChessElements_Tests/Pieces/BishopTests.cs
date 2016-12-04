using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessElements.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessElements.Pieces.Tests
{
    [TestClass()]
    public class BishopTests
    {
        [TestMethod()]
        public void GetMoveList_Test()
        {
            var emptTtile = new Tile(ChessInfrastructure.ChessEnums.Rows.Eight, ChessInfrastructure.ChessEnums.Columns.A);
            var piece = new Bishop(ChessInfrastructure.ChessEnums.PieceColor.Black);

            piece.GetMoveList(emptTtile);
        }
    }
}