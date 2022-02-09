using BoardLayer;

namespace ChessLayer
{
    class ChessMatch
    {
        public Board MatchBoard { get;private set; }
        private int _turn;
        private Color _currentPlayer;
        public bool MatchFinished { get; private set; }

        public ChessMatch()
        {
            MatchBoard = new Board(8, 8);
            _turn = 1;
            _currentPlayer = Color.White;
            MatchFinished = false;
            SetInitialPieces();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Piece p = MatchBoard.RemovePiece(origin);
            p.IncrementMoviment();
            Piece capturedPiece = MatchBoard.RemovePiece(destiny);
            MatchBoard.SetPiece(p, destiny);
        }

        public void SetInitialPieces()
        {
            MatchBoard.SetPiece(new Rook(MatchBoard, Color.Black), new ChessPosition('a', 8).ToPosition());
        }
    }
}
