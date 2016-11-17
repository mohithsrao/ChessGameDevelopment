namespace ChessInfrastructure
{
    public static class ChessEnums
    {
        public enum PieceType
        {
            Pawn,
            Rook,
            Knight,
            Bishop,
            Queen,
            King
        }

        public enum PieceColor
        {
            White,
            Black
        }

        public enum Rows
        {
            One = 7,
            Two = 6,
            Three = 5,
            Four = 4,
            Five = 3,
            Six = 2,
            Seven = 1,
            Eight = 0
        }

        public enum Columns
        {
            A = 0,
            B = 1,
            C = 2,
            D = 3,
            E = 4,
            F = 5,
            G = 6,
            H = 7
        }
    }
}
