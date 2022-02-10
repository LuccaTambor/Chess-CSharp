using BoardLayer;

namespace ChessLayer
{
    class Bishop : Piece
    {

        public Bishop(Board board, Color color) : base(color, board)
        {

        }

        private bool VerifyMove(Position pos)
        {
            Piece p = Board.GetOnePiece(pos);

            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] possibleMoviments = new bool[Board.Rows, Board.Cols];

            Position pos = new Position(0, 0);

            //Verifing north movement
            pos.DefineValues(Position.Row - 1, Position.Column);
            while (Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
                if (Board.GetOnePiece(pos) != null && Board.GetOnePiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row--;
            }
            //Verifing south movement
            pos.DefineValues(Position.Row + 1, Position.Column);
            while (Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
                if (Board.GetOnePiece(pos) != null && Board.GetOnePiece(pos).Color != Color)
                {
                    break;
                }
                pos.Row++;
            }
            //Verifing east movement
            pos.DefineValues(Position.Row, Position.Column + 1);
            while (Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
                if (Board.GetOnePiece(pos) != null && Board.GetOnePiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column++;
            }
            //Verifing west movement
            pos.DefineValues(Position.Row, Position.Column - 1);
            while (Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
                if (Board.GetOnePiece(pos) != null && Board.GetOnePiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column--;
            }

            return possibleMoviments;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}