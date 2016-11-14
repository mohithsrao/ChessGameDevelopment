using ChessInfrastructure;
using static ChessInfrastructure.ChessEnums;

namespace ChessElements
{
    public class ChessPiece : ObservableClass
    {
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
