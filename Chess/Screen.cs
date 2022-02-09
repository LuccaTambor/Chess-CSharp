using System;
using System.Collections.Generic;
using System.Text;
using BoardLayer;
using ChessLayer;

namespace Chess
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i<board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j<board.Cols; j++)
                {
                    if(board.GetOnePiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.GetOnePiece(i, j));
                        Console.Write(" ");
                    }    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
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
        }
    }
}
