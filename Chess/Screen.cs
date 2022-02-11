using System;
using System.Collections.Generic;
using System.Text;
using BoardLayer;
using ChessLayer;

namespace Chess
{
    class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            Screen.PrintBoard(match.MatchBoard);
            Console.WriteLine();
            PrintCapturesPieces(match);
            Console.WriteLine();
            Console.WriteLine($"Turn {match.Turn}");

            if (!match.MatchFinished)
            {
                Console.WriteLine($"Waiting play: {match.CurrentPlayer}");

                if (match.Check)
                {
                    Console.WriteLine("You are in Check!");
                }
            }
            else
            {
                Console.WriteLine("Checkmate!");
                Console.WriteLine("Winner: " + match.CurrentPlayer);
            }

            
        }

        public static void PrintCapturesPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces: ");

            Console.Write("White: ");
            PrintPieceSet(match.CapturedPieces(Color.White));

            Console.WriteLine();

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("Black: ");
            PrintPieceSet(match.CapturedPieces(Color.Black));

            Console.ForegroundColor = aux;

            Console.WriteLine();
        }

        public static void PrintPieceSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach(Piece p in set)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i<board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j<board.Cols; j++)
                {
                    PrintPiece(board.GetOnePiece(i, j)); 
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] possibleMovements)
        {
            ConsoleColor standartColor = Console.BackgroundColor;
            ConsoleColor alteredColor = ConsoleColor.DarkGray;


            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Cols; j++)
                {
                    if(possibleMovements[i, j])
                    {
                        Console.BackgroundColor = alteredColor;
                    }
                    else
                    {
                        Console.BackgroundColor = standartColor;
                    }
                    PrintPiece(board.GetOnePiece(i, j));
                    Console.BackgroundColor = standartColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            //Console.BackgroundColor = standartColor;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char col = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(col, row);
        }

        public static void PrintPiece(Piece p)
        {

            if(p == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (p.Color == Color.White)
                {
                    Console.Write(p);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(p);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
            
        }
    }
}
