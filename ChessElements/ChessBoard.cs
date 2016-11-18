using ChessElements.Pieces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements
{
    public sealed class ChessBoard
    {
        #region Singleton
        private static ChessBoard _instance;

        /// <summary>
        /// Static constructor to initiate the Instance Variable
        /// </summary>
        static ChessBoard()
        {
            _instance = new ChessBoard();
        }

        /// <summary>
        /// Private Constructor to restrict other classes to create instances of this class
        /// </summary>
        private ChessBoard()
        {
            _board = CreateChessBoard();
        }

        public static ChessBoard Instance
        {
            get { return _instance; }
        }
        #endregion

        #region Variables

        private ObservableCollection<Tile> _board;

        public ObservableCollection<Tile> Board
        {
            get { return _board; }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates an instance of teh board with all the 8*8 board tiles and Chess Pieces on them
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<Tile> CreateChessBoard()
        {
            var board = new ObservableCollection<Tile>
        {
            new Tile(Rows.One,Columns.A,  new Rook(PieceColor.White)),
            new Tile(Rows.One,Columns.B,  new Knight(PieceColor.White)),
            new Tile(Rows.One,Columns.C,  new Bishop(PieceColor.White)),
            new Tile(Rows.One,Columns.D,  new King(PieceColor.White)),
            new Tile(Rows.One,Columns.E,  new Queen(PieceColor.White)),
            new Tile(Rows.One,Columns.F,  new Bishop(PieceColor.White)),
            new Tile(Rows.One,Columns.G,  new Knight(PieceColor.White)),
            new Tile(Rows.One,Columns.H,  new Rook(PieceColor.White)),

            new Tile(Rows.Two,Columns.A, new Pawn(PieceColor.White)),
            new Tile(Rows.Two,Columns.B, new Pawn(PieceColor.White)),
            new Tile(Rows.Two,Columns.C, new Pawn(PieceColor.White)),
            new Tile(Rows.Two,Columns.D, new Pawn(PieceColor.White)),
            new Tile(Rows.Two,Columns.E, new Pawn(PieceColor.White)),
            new Tile(Rows.Two,Columns.F, new Pawn(PieceColor.White)),
            new Tile(Rows.Two,Columns.G, new Pawn(PieceColor.White)),
            new Tile(Rows.Two,Columns.H, new Pawn(PieceColor.White)),

            new Tile(Rows.Three,Columns.A),
            new Tile(Rows.Three,Columns.B),
            new Tile(Rows.Three,Columns.C),
            new Tile(Rows.Three,Columns.D),
            new Tile(Rows.Three,Columns.E),
            new Tile(Rows.Three,Columns.F),
            new Tile(Rows.Three,Columns.G),
            new Tile(Rows.Three,Columns.H),

            new Tile(Rows.Four,Columns.A),
            new Tile(Rows.Four,Columns.B),
            new Tile(Rows.Four,Columns.C),
            new Tile(Rows.Four,Columns.D),
            new Tile(Rows.Four,Columns.E),
            new Tile(Rows.Four,Columns.F),
            new Tile(Rows.Four,Columns.G),
            new Tile(Rows.Four,Columns.H),

            new Tile(Rows.Five,Columns.A),
            new Tile(Rows.Five,Columns.B),
            new Tile(Rows.Five,Columns.C),
            new Tile(Rows.Five,Columns.D),
            new Tile(Rows.Five,Columns.E),
            new Tile(Rows.Five,Columns.F),
            new Tile(Rows.Five,Columns.G),
            new Tile(Rows.Five,Columns.H),

            new Tile(Rows.Six,Columns.A),
            new Tile(Rows.Six,Columns.B),
            new Tile(Rows.Six,Columns.C),
            new Tile(Rows.Six,Columns.D),
            new Tile(Rows.Six,Columns.E),
            new Tile(Rows.Six,Columns.F),
            new Tile(Rows.Six,Columns.G),
            new Tile(Rows.Six,Columns.H),

            new Tile(Rows.Seven,Columns.A,  new Pawn(PieceColor.Black)),
            new Tile(Rows.Seven,Columns.B,  new Pawn(PieceColor.Black)),
            new Tile(Rows.Seven,Columns.C,  new Pawn(PieceColor.Black)),
            new Tile(Rows.Seven,Columns.D,  new Pawn(PieceColor.Black)),
            new Tile(Rows.Seven,Columns.E,  new Pawn(PieceColor.Black)),
            new Tile(Rows.Seven,Columns.F,  new Pawn(PieceColor.Black)),
            new Tile(Rows.Seven,Columns.G,  new Pawn(PieceColor.Black)),
            new Tile(Rows.Seven,Columns.H,  new Pawn(PieceColor.Black)),

            new Tile(Rows.Eight,Columns.A,  new Rook(PieceColor.Black)),
            new Tile(Rows.Eight,Columns.B,  new Knight(PieceColor.Black)),
            new Tile(Rows.Eight,Columns.C,  new Bishop(PieceColor.Black)),
            new Tile(Rows.Eight,Columns.D,  new King(PieceColor.Black)),
            new Tile(Rows.Eight,Columns.E,  new Queen(PieceColor.Black)),
            new Tile(Rows.Eight,Columns.F,  new Bishop(PieceColor.Black)),
            new Tile(Rows.Eight,Columns.G,  new Knight(PieceColor.Black)),
            new Tile(Rows.Eight,Columns.H,  new Rook(PieceColor.Black))
        };
            return board;
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Method to get the tiles surrounding the Given tile from the chess board,
        /// If the co-ordinates crosses teh board border null is returned in those locations.
        /// </summary>
        /// <param name="tile">The Center tile arround which to get the surrounding tile data</param>
        /// <param name="areaLength">The dimension of the Square Area(Should always be an odd number)</param>
        /// <returns>A 2 Dimentional array of teh tile surrounding the passed tile</returns>
        public Tile[,] GetSurroundingTiles(Tile tile, int areaLength)
        {
            if(areaLength%2 == 0) throw new ArgumentException("Argument areaLength cannot be even");

            var tileSquare = new Tile[areaLength, areaLength];//Initiating 2D Array of required length

            var rowOffset = (int)tile.Row + (areaLength / 2);//Calculate Row Offset
            for (int i = 0; i < areaLength; i++)
            {
                if ((rowOffset > (int)Rows.One) || (rowOffset < (int)Rows.Seven)) { }//IF Row Coordinate Offset falls within the board
                else
                {
                    var columnOffset = (int)tile.Column + (areaLength / 2);//Calculate column Offset
                    for (int j = 0; j < areaLength; j++)
                    {
                        if ((columnOffset > (int)Columns.H) || (columnOffset < (int)Columns.A)) { }//IF Column Coordinate Offset falls within the board
                        else
                        {
                            tileSquare[areaLength - i - 1, areaLength - j - 1] = Board.FirstOrDefault(x => (int)x.Row == rowOffset && (int)x.Column == columnOffset);//Fill 2D Array with data from board object
                        }
                        columnOffset--;//Decrement Column Offset
                    }
                }
                rowOffset--;//Decrement Row Offset     
            }

            return tileSquare;
        }

        #endregion
    }
}
