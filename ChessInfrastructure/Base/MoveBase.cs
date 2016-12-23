namespace ChessInfrastructure.Base
{
    public abstract class MoveBase
    {
        public MoveBase(ChessEnums.Rows _row, ChessEnums.Columns _column)
        {
            Row = _row;
            Column = _column;
        }

        public ChessEnums.Columns Column { get; private set; }
        public ChessEnums.Rows Row { get;  }
        public ChessEnums.MoveType Type { get; set; }
}
}
