using BoardLayer;

namespace ChessLayer
{
    class Pawn : Piece
    {

        public Pawn(Board board, Color color) : base(color, board)
        {

        }

        private bool VerifyMove(Position pos)
        {
            Piece p = Board.GetOnePiece(pos);

            return p == null || p.Color != Color;
        }

        private bool ThereIsEnemy(Position pos)
        {
            Piece p = Board.GetOnePiece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.GetOnePiece(pos) == null;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] possibleMoviments = new bool[Board.Rows, Board.Cols];

            Position pos = new Position(0, 0);

            if(Color == Color.White)
            {
                //Standart move of a Pawn
                pos.DefineValues(Position.Row - 1, Position.Column);
                if(Board.IsPositionValid(pos) && Free(pos))
                {
                    possibleMoviments[pos.Row, pos.Column] = true;
                }

                //First move of a pawn where he can move two spaces
                pos.DefineValues(Position.Row - 2, Position.Column);
                if (Board.IsPositionValid(pos) && Free(pos) && MovementQtd == 0)
                {
                    possibleMoviments[pos.Row, pos.Column] = true;
                }

                //Movement of pawn if theres a enemy on its diagonals
                pos.DefineValues(Position.Row - 1, Position.Column - 1);
                if (Board.IsPositionValid(pos) && ThereIsEnemy(pos))
                {
                    possibleMoviments[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row - 1, Position.Column + 1);
                if (Board.IsPositionValid(pos) && ThereIsEnemy(pos))
                {
                    possibleMoviments[pos.Row, pos.Column] = true;
                }

            }
            else
            {
                //Standart move of a Pawn
                pos.DefineValues(Position.Row + 1, Position.Column);
                if (Board.IsPositionValid(pos) && Free(pos))
                {
                    possibleMoviments[pos.Row, pos.Column] = true;
                }

                //First move of a pawn where he can move two spaces
                pos.DefineValues(Position.Row + 2, Position.Column);
                if (Board.IsPositionValid(pos) && Free(pos) && MovementQtd == 0)
                {
                    possibleMoviments[pos.Row, pos.Column] = true;
                }

                //Movement of pawn if theres a enemy on its diagonals
                pos.DefineValues(Position.Row + 1, Position.Column - 1);
                if (Board.IsPositionValid(pos) && ThereIsEnemy(pos))
                {
                    possibleMoviments[pos.Row, pos.Column] = true;
                }
                pos.DefineValues(Position.Row + 1, Position.Column + 1);
                if (Board.IsPositionValid(pos) && ThereIsEnemy(pos))
                {
                    possibleMoviments[pos.Row, pos.Column] = true;
                }
            }

            return possibleMoviments;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}