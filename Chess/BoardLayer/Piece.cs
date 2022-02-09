namespace BoardLayer
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementQtd { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            MovementQtd = 0;
        }

        public void IncrementMoviment()
        {
            MovementQtd++;
        }
    }
}
