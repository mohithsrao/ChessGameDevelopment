namespace ChessInfrastructure.Base
{
    public abstract class MoveBase
    {
        public MoveBase(ChessEnums.Rows _row, ChessEnums.Columns _column)
        {
            row = _row;
            column = _column;
        }

        public ChessEnums.Columns column { get; private set; }
        public ChessEnums.Rows row { get;  }
        public ChessEnums.MoveType Type { get; set; }
}
}
