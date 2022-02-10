using BoardLayer;
using System.Collections.Generic;

namespace ChessLayer
{
    class ChessMatch
    {
        public Board MatchBoard { get;private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool MatchFinished { get; private set; }
        private HashSet<Piece> _pieces;
        private HashSet<Piece> _capturedPieces;


        public ChessMatch()
        {
            MatchBoard = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            MatchFinished = false;

            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();

            SetInitialPieces();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Piece p = MatchBoard.RemovePiece(origin);
            p.IncrementMoviment();
            Piece capturedPiece = MatchBoard.RemovePiece(destiny);
            MatchBoard.SetPiece(p, destiny);

            if(capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }
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

        public void SetNewPiece(char col, int row, Piece p)
        {
            MatchBoard.SetPiece(p, new ChessPosition(col, row).ToPosition());
            _pieces.Add(p);
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece p in _capturedPieces)
            {
                if(p.Color == color)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in _pieces)
            {
                if (p.Color == color)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private void SetInitialPieces()
        {
            //Setting the black pieces
            SetNewPiece('a', 8, new Rook(MatchBoard, Color.Black));
            SetNewPiece('e', 8, new King(MatchBoard, Color.Black));
            SetNewPiece('h', 8, new Rook(MatchBoard, Color.Black));

            //Setting the white pieces
            SetNewPiece('a', 1, new Rook(MatchBoard, Color.White));
            SetNewPiece('e', 1, new King(MatchBoard, Color.White));
            SetNewPiece('h', 1, new Rook(MatchBoard, Color.White));
            SetNewPiece('d', 1, new Rook(MatchBoard, Color.White));
            SetNewPiece('f', 1, new Rook(MatchBoard, Color.White));
            SetNewPiece('d', 2, new Rook(MatchBoard, Color.White));
            SetNewPiece('e', 2, new Rook(MatchBoard, Color.White));
            SetNewPiece('f', 2, new Rook(MatchBoard, Color.White));
        }
    }
}
