using static ChessInfrastructure.ChessEnums;
using System.Collections.Generic;
using ChessInfrastructure.Interfaces;

namespace ChessInfrastructure.Base
{
    public abstract class PieceBase : ObservableClass,IMovable
    {
        private PieceType _type;
        public PieceType Type
        {
            get { return _type; }
            set { _type = value; RaisePropertyChanged("Type"); }
        }

        private PieceColor _color;
        public PieceColor Color
        {
            get { return _color; }
            set { _color = value; RaisePropertyChanged("Color"); }
        }

        public abstract List<MoveBase> GetMoveList(IDropable tile);
    }
}
