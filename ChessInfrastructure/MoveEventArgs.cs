using ChessInfrastructure.BaseClass;
using System;

namespace ChessInfrastructure
{
    public class MoveEventArgs : EventArgs
    {
        private ChessEnums.Rows rows;
        private ChessEnums.Columns columns;
        private PieceBase piece;

        public ChessEnums.Rows Rows
        {
            get
            {
                return rows;
            }

            set
            {
                rows = value;
            }
        }

        public ChessEnums.Columns Columns
        {
            get
            {
                return columns;
            }

            set
            {
                columns = value;
            }
        }

        public PieceBase Piece
        {
            get
            {
                return piece;
            }

            set
            {
                piece = value;
            }
        }

        public MoveEventArgs(PieceBase _piece, ChessEnums.Rows _row, ChessEnums.Columns _columns)
        {
            Piece = _piece;
            Rows = _row;
            Columns = _columns;
        }
    }
}
