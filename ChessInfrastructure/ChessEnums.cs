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

        public enum Player
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
            A = 7,
            B = 6,
            C = 5,
            D = 4,
            E = 3,
            F = 2,
            G = 1,
            H = 0
        }
    }
}
