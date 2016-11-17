using System.Collections.Generic;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements.Pieces
{
    public class Pawn : PieceBase
    {
        #region Private Variables

        private static Tile[,] _movementArea;
        private const int SQUAREAREALENGTH = 5;

        #endregion

        #region Constructor

        static Pawn()
        {
            _movementArea = new Tile[SQUAREAREALENGTH, SQUAREAREALENGTH];
        }

        public Pawn(PieceColor player)
        {
            base.Player = player;
            base.Type = PieceType.Pawn;
        }
        #endregion

        #region Private Methods
        
        

        #endregion

        #region Public Methods

        public override void Move()
        {

        }

        public override void GetMoveList(Tile tile)
        {
            var list = ChessBoard.Instance.GetSurroundingTiles(tile, SQUAREAREALENGTH);
        }

        #endregion
    }
}
