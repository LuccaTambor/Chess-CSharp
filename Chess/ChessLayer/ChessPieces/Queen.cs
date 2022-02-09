using BoardLayer;

namespace ChessLayer
{
    class Queen : Piece
    {

        public Queen(Board board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "Q";
        }
    }
}