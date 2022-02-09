namespace BoardLayer
{
    class Board
    {
        public int Rows { get; set; }
        public int Cols { get; set; }

        private Piece[,] pieces;

        public Board(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            pieces = new Piece[rows, cols];
        }

        public Piece GetOnePiece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece GetOnePiece(Position pos)
        {
            return pieces[pos.Row, pos.Column];
        }

        public bool isPositionEmpty(Position pos)
        {
            CheckPositionValidation(pos);
            return GetOnePiece(pos) == null;
        }

        public Piece RemovePiece(Position pos)
        {
            if(isPositionEmpty(pos))
            {
                return null;
            }
            else
            {
                Piece aux = GetOnePiece(pos);
                aux.Position = null;
                pieces[pos.Row, pos.Column] = null;
                return aux;
            }
        }

        public void SetPiece(Piece p, Position pos)
        {
            if(isPositionEmpty(pos))
            {
                pieces[pos.Row, pos.Column] = p;
                p.Position = pos;
            }
            else
            {
                throw new BoardException("There's already a piece in this position!");
            }
            
        }

        public bool IsPositionValid(Position pos)
        {
            if(pos.Row < 0 || pos.Row >= Rows || pos.Column < 0 || pos.Column >= Cols)
            {
                return false;
            }
            return true;
        }

        public void CheckPositionValidation(Position pos)
        {
            if(!IsPositionValid(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
