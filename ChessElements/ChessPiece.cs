using ChessInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements
{
    public class ChessPiece : ObservableClass
    {
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

        private PieceType _Type;
        public PieceType Type
        {
            get { return _Type; }
            set { _Type = value; RaisePropertyChanged("Type"); }
        }

        private Player _Player;
        public Player Player
        {
            get { return _Player; }
            set { _Player = value; RaisePropertyChanged("Player"); }
        }
    }
}
