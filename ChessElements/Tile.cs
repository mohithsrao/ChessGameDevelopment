using ChessInfrastructure;
using System.Windows;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements
{
    public class Tile : ObservableClass
    {
        #region Constructor

        public Tile(Rows row, Columns column)
        {
            _row = row;
            _column = column;
        }

        public Tile(Rows row, Columns column, ChessPiece piece)
        {
            _row = row;
            _column = column;
            _piece = piece;
        }

        #endregion

        public Point Pos
        {
            get { return new Point((int)Column * 50d, (int)Row * 50d); }
        }

        private Rows _row;
        public Rows Row
        {
            get { return _row; }
            set { _row = value; RaisePropertyChanged("Row"); }
        }

        private Columns _column;
        public Columns Column
        {
            get { return _column; }
            set { _column = value; RaisePropertyChanged("Column"); }
        }

        private ChessPiece _piece;
        public ChessPiece Piece
        {
            get { return _piece; }
            set { _piece = value; RaisePropertyChanged("Piece"); }
        }
    }
}
