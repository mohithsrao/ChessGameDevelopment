using ChessInfrastructure;
using System.Windows;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements
{
    public class Tile : ObservableClass
    {
        #region Constructor

        /// <summary>
        /// Constructor to take in only Row and Column positions
        /// </summary>
        /// <param name="row">Row Coordinate</param>
        /// <param name="column">Column Coordinate</param>
        public Tile(Rows row, Columns column)
        {
            _row = row;
            _column = column;
        }

        /// <summary>
        /// Constructor to take in Row,Column and piece data
        /// </summary>
        /// <param name="row">Row Coordinate</param>
        /// <param name="column">Column Coordinate</param>
        /// <param name="piece">Chess piece placed on the tile</param>
        public Tile(Rows row, Columns column, PieceBase piece)
        {
            _row = row;
            _column = column;
            _piece = piece;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Position on the Canvas in GUI,
        /// 50d is hardcoded as it is the size of the square on the chess board
        /// </summary>
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

        private PieceBase _piece;
        public PieceBase Piece
        {
            get { return _piece; }
            set { _piece = value; RaisePropertyChanged("Piece"); }
        }
        
        public bool IsEmptyTile
        {
            get { return Piece == null; }
        }

        private TileBackground _background = TileBackground.Transparent;
        public TileBackground Background
        {
            get { return _background; }
            set
            {
                _background = value;
                RaisePropertyChanged("Background");
            }
        }

        #endregion

        #region Public Methods

        #endregion
    }
}
