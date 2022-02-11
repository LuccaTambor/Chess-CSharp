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
        public bool Check { get; private set; }


        public ChessMatch()
        {
            MatchBoard = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            MatchFinished = false;
            Check = false;

            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();

            SetInitialPieces();
        }

        public Piece ExecuteMovement(Position origin, Position destiny)
        {
            Piece p = MatchBoard.RemovePiece(origin);
            p.IncrementMoviment();
            Piece capturedPiece = MatchBoard.RemovePiece(destiny);
            MatchBoard.SetPiece(p, destiny);

            if(capturedPiece != null)
            {
                _capturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = MatchBoard.RemovePiece(destiny);
            p.DecrementMoviment();

            if(capturedPiece != null)
            {
                MatchBoard.SetPiece(capturedPiece, destiny);

                _capturedPieces.Remove(capturedPiece);
            }
            MatchBoard.SetPiece(p, origin);
        }

        public void MakePlay(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteMovement(origin, destiny);

            if(IsInCheck(CurrentPlayer))
            {
                UndoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in Check!");
            }

            if(IsInCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if(IsInCheckMate(Adversary(CurrentPlayer)))
            {
                MatchFinished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
            
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

        private Color Adversary(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece GetKing(Color color)
        {
            foreach (Piece p in PiecesInPlay(color))
            {
                if(p is King)
                {
                    return p;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece king = GetKing(color);

            if(king == null)
            {
                throw new BoardException("King not founded!Something went Wrong!"); 
            }

            foreach(Piece p in PiecesInPlay(Adversary(color)))
            {
                bool[,] possibleMov = p.PossibleMoviments();
                if (possibleMov[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsInCheckMate(Color color)
        {
            if(!IsInCheck(color))
            {
                return false;
            }

            foreach(Piece p in PiecesInPlay(color))
            {
                bool[,] possibilities = p.PossibleMoviments();
                for(int i = 0; i < MatchBoard.Rows; i++)
                {
                    for(int j = 0; j < MatchBoard.Cols; j++)
                    {
                        if (possibilities[i, j])
                        {
                            Position origin = p.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteMovement(origin, destiny);
                            bool checkTest = IsInCheck(color);
                            UndoMovement(origin, destiny, capturedPiece);

                            if(!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
            SetNewPiece('b', 8, new Rook(MatchBoard, Color.Black));
            SetNewPiece('a', 8, new King(MatchBoard, Color.Black));

            //Setting the white pieces
            SetNewPiece('c', 1, new Rook(MatchBoard, Color.White));
            SetNewPiece('d', 1, new King(MatchBoard, Color.White));
            SetNewPiece('h', 7, new Rook(MatchBoard, Color.White));
          
        }
    }
}
