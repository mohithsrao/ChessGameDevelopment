using ChessElements;
using ChessInfrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static ChessInfrastructure.ChessEnums;

namespace ChessGame.ViewModels
{
    public class MainWindowViewModel : ObservableClass
    {
        #region Properties

        private ObservableCollection<ChessPiece> _chessBoard = new ObservableCollection<ChessPiece>();
        public ObservableCollection<ChessPiece> ChessBoard
        {
            get { return _chessBoard; }
            set
            {
                if (_chessBoard == value) return;
                _chessBoard = value;
                RaisePropertyChanged("ChessBoard");
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for loading the ViewModel of the main Window of the application
        /// </summary>
        public MainWindowViewModel()
        {
            InitiateGUI();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Loades the UI with initial positions of all the pawns in the Chess Board
        /// </summary>
        private void InitiateGUI()
        {
            ChessBoard = new ObservableCollection<ChessPiece>
        {
            new ChessPiece{Row = Rows.Two,Column = Columns.A, Type=PieceType.Pawn, Player=Player.White},
            new ChessPiece{Row = Rows.Two,Column = Columns.B, Type=PieceType.Pawn, Player=Player.White},
            new ChessPiece{Row = Rows.Two,Column = Columns.C, Type=PieceType.Pawn, Player=Player.White},
            new ChessPiece{Row = Rows.Two,Column = Columns.D, Type=PieceType.Pawn, Player=Player.White},
            new ChessPiece{Row = Rows.Two,Column = Columns.E, Type=PieceType.Pawn, Player=Player.White},
            new ChessPiece{Row = Rows.Two,Column = Columns.F, Type=PieceType.Pawn, Player=Player.White},
            new ChessPiece{Row = Rows.Two,Column = Columns.G, Type=PieceType.Pawn, Player=Player.White},
            new ChessPiece{Row = Rows.Two,Column = Columns.H, Type=PieceType.Pawn, Player=Player.White},
            new ChessPiece{Row = Rows.One,Column = Columns.A, Type=PieceType.Rook, Player=Player.White},
            new ChessPiece{Row = Rows.One,Column = Columns.B, Type=PieceType.Knight, Player=Player.White},
            new ChessPiece{Row = Rows.One,Column = Columns.C, Type=PieceType.Bishop, Player=Player.White},
            new ChessPiece{Row = Rows.One,Column = Columns.D, Type=PieceType.King, Player=Player.White},
            new ChessPiece{Row = Rows.One,Column = Columns.E, Type=PieceType.Queen, Player=Player.White},
            new ChessPiece{Row = Rows.One,Column = Columns.F, Type=PieceType.Bishop, Player=Player.White},
            new ChessPiece{Row = Rows.One,Column = Columns.G, Type=PieceType.Knight, Player=Player.White},
            new ChessPiece{Row = Rows.One,Column = Columns.H, Type=PieceType.Rook, Player=Player.White},
            new ChessPiece{Row = Rows.Seven,Column = Columns.A, Type=PieceType.Pawn, Player=Player.Black},
            new ChessPiece{Row = Rows.Seven,Column = Columns.B, Type=PieceType.Pawn, Player=Player.Black},
            new ChessPiece{Row = Rows.Seven,Column = Columns.C, Type=PieceType.Pawn, Player=Player.Black},
            new ChessPiece{Row = Rows.Seven,Column = Columns.D, Type=PieceType.Pawn, Player=Player.Black},
            new ChessPiece{Row = Rows.Seven,Column = Columns.E, Type=PieceType.Pawn, Player=Player.Black},
            new ChessPiece{Row = Rows.Seven,Column = Columns.F, Type=PieceType.Pawn, Player=Player.Black},
            new ChessPiece{Row = Rows.Seven,Column = Columns.G, Type=PieceType.Pawn, Player=Player.Black},
            new ChessPiece{Row = Rows.Seven,Column = Columns.H, Type=PieceType.Pawn, Player=Player.Black},
            new ChessPiece{Row = Rows.Eight,Column = Columns.A, Type=PieceType.Rook, Player=Player.Black},
            new ChessPiece{Row = Rows.Eight,Column = Columns.B, Type=PieceType.Knight, Player=Player.Black},
            new ChessPiece{Row = Rows.Eight,Column = Columns.C, Type=PieceType.Bishop, Player=Player.Black},
            new ChessPiece{Row = Rows.Eight,Column = Columns.D, Type=PieceType.King, Player=Player.Black},
            new ChessPiece{Row = Rows.Eight,Column = Columns.E, Type=PieceType.Queen, Player=Player.Black},
            new ChessPiece{Row = Rows.Eight,Column = Columns.F, Type=PieceType.Bishop, Player=Player.Black},
            new ChessPiece{Row = Rows.Eight,Column = Columns.G, Type=PieceType.Knight, Player=Player.Black},
            new ChessPiece{Row = Rows.Eight,Column = Columns.H, Type=PieceType.Rook, Player=Player.Black}
        };
        }

        #endregion
    }
}
