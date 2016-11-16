using ChessInfrastructure;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements
{
    public abstract class PieceBase : ObservableClass
    {
        private PieceType _Type;
        public PieceType Type
        {
            get { return _Type; }
            set { _Type = value; RaisePropertyChanged("Type"); }
        }

        private PieceColor _Player;
        public PieceColor Player
        {
            get { return _Player; }
            set { _Player = value; RaisePropertyChanged("Player"); }
        }
    }
}
