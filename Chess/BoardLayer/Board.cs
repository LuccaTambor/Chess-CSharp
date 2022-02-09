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
    }
}
