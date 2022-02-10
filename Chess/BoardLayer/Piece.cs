namespace BoardLayer
{
    abstract class Piece
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

        public bool ThereArePossibleMoviments()
        {
            bool[,] pm = PossibleMoviments();
            for(int i=0; i<Board.Rows; i++)
            {
                for(int j=0; j<Board.Cols; j++)
                {
                    if (pm[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position destiny)
        {
            return PossibleMoviments()[destiny.Row, destiny.Column];
        }

        public abstract bool[,] PossibleMoviments();
    }
}
