using System;
using BoardLayer;
using ChessLayer;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(8, 8);

            b.SetPiece(new Rook(b, Color.Black), new Position(0, 0));
            b.SetPiece(new Knight(b, Color.Black), new Position(0, 1));
            b.SetPiece(new Bishop(b, Color.Black), new Position(0, 2));
            b.SetPiece(new Queen(b, Color.Black), new Position(0, 3));
            b.SetPiece(new King(b, Color.Black), new Position(0, 4));
            b.SetPiece(new Bishop(b, Color.Black), new Position(0, 5));
            b.SetPiece(new Knight(b, Color.Black), new Position(0, 6));
            b.SetPiece(new Rook(b, Color.Black), new Position(0, 7));

            Screen.printBoard(b);

            Console.ReadLine();
        }
    }
}
