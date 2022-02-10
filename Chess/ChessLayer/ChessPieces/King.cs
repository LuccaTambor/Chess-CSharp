using BoardLayer;

namespace ChessLayer
{
    class King : Piece
    {

        public King(Board board, Color color) : base(color, board)
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
            if(Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
            }
            //Verifing northeast movement
            pos.DefineValues(Position.Row - 1, Position.Column + 1);
            if (Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
            }
            //Verifing east movement
            pos.DefineValues(Position.Row, Position.Column + 1);
            if (Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
            }
            //Verifing southeast movement
            pos.DefineValues(Position.Row + 1, Position.Column + 1);
            if (Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
            }
            //Verifing south movement
            pos.DefineValues(Position.Row + 1, Position.Column);
            if (Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
            }
            //Verifing southwest movement
            pos.DefineValues(Position.Row + 1, Position.Column - 1);
            if (Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
            }
            //Verifing west movement
            pos.DefineValues(Position.Row, Position.Column - 1);
            if (Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
            }
            //Verifing northwest movement
            pos.DefineValues(Position.Row - 1, Position.Column - 1);
            if (Board.IsPositionValid(pos) && VerifyMove(pos))
            {
                possibleMoviments[pos.Row, pos.Column] = true;
            }

            return possibleMoviments;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
