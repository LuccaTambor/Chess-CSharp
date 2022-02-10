using BoardLayer;

namespace ChessLayer
{
    class ChessMatch
    {
        public Board MatchBoard { get;private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool MatchFinished { get; private set; }

        public ChessMatch()
        {
            MatchBoard = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
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

        public void MakePlay(Position origin, Position destiny)
        {
            ExecuteMovement(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidOriginPosition(Position origin)
        {
            MatchBoard.CheckPositionValidation(origin);

            if(MatchBoard.GetOnePiece(origin) == null)
            {
                throw new BoardException("There is no piece in this position!");
            }

            if(CurrentPlayer != MatchBoard.GetOnePiece(origin).Color)
            {
                throw new BoardException("The chosen piece is not your from the current player color!");
            }

            if(!MatchBoard.GetOnePiece(origin).ThereArePossibleMoviments())
            {
                throw new BoardException("The chosen piece has no possible movements!");
            }
        }

        public void ValidDestinyPosition(Position origin, Position destiny)
        {
            MatchBoard.CheckPositionValidation(destiny);

            if(!MatchBoard.GetOnePiece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Invalid Destiny position!");
            }
        }

        private void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void SetInitialPieces()
        {
            //Setting the black pieces
            MatchBoard.SetPiece(new Rook(MatchBoard, Color.Black), new ChessPosition('a', 8).ToPosition());
            MatchBoard.SetPiece(new King(MatchBoard, Color.Black), new ChessPosition('e', 8).ToPosition());
            MatchBoard.SetPiece(new Rook(MatchBoard, Color.Black), new ChessPosition('h', 8).ToPosition());

            //Setting the white pieces
            MatchBoard.SetPiece(new Rook(MatchBoard, Color.White), new ChessPosition('a', 1).ToPosition());
            MatchBoard.SetPiece(new King(MatchBoard, Color.White), new ChessPosition('e', 1).ToPosition());
            MatchBoard.SetPiece(new Rook(MatchBoard, Color.White), new ChessPosition('h', 1).ToPosition());
            MatchBoard.SetPiece(new Rook(MatchBoard, Color.White), new ChessPosition('d', 1).ToPosition());
            MatchBoard.SetPiece(new Rook(MatchBoard, Color.White), new ChessPosition('f', 1).ToPosition());
            MatchBoard.SetPiece(new Rook(MatchBoard, Color.White), new ChessPosition('d', 2).ToPosition());
            MatchBoard.SetPiece(new Rook(MatchBoard, Color.White), new ChessPosition('e', 2).ToPosition());
            MatchBoard.SetPiece(new Rook(MatchBoard, Color.White), new ChessPosition('f', 2).ToPosition());
        }
    }
}
