using System;
using ChessInfrastructure;
using static ChessInfrastructure.ChessEnums;
using System.Collections.Generic;

namespace ChessElements
{
    public abstract class PieceBase : ObservableClass
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

        public virtual void Move(Tile fromTile, Tile toTile)
        {

        }

        /// <summary>
        /// Virtual method that get all possible moves of the piece on the tile
        /// </summary>
        /// <param name="tile"></param>
        public virtual List<Tile> GetMoveList(Tile tile)
        {
            return null;
        }
    }
}
