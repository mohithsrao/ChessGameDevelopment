namespace ChessInfrastructure
{
    public static class ChessEnums
    {
        /// <summary>
        /// Enum to denote Piece type
        /// </summary>
        public enum PieceType
        {
            Pawn,
            Rook,
            Knight,
            Bishop,
            Queen,
            King
        }

        /// <summary>
        /// Enum to denote Color od pieces
        /// </summary>
        public enum PieceColor
        {
            White,
            Black
        }

        /// <summary>
        /// Enum to denote rows in the game
        /// </summary>
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

        /// <summary>
        /// Enum to denote Columns in the game
        /// </summary>
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

        /// <summary>
        /// Enum to denote Tile background color
        /// </summary>
        public enum TileBackground
        {
            Transparent,
            Green,
            Red
        }

        /// <summary>
        /// Enum Used to Denote the Type of Move
        /// </summary>
        public enum MoveType
        {
            Attack,
            Normal
        }
    }
}
