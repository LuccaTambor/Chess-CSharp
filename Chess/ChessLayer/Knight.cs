using BoardLayer;

namespace ChessLayer
{
    class Knight: Piece
    {

        public Knight(Board board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "H";
        }
    }
}