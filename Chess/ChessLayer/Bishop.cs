using BoardLayer;

namespace ChessLayer
{
    class Bishop : Piece
    {

        public Bishop(Board board, Color color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "B";
        }
    }
}