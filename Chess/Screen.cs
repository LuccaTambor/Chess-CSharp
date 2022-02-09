using System;
using System.Collections.Generic;
using System.Text;
using BoardLayer;

namespace Chess
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for (int i = 0; i<board.Rows; i++)
            {
                for (int j = 0; j<board.Cols; j++)
                {
                    if(board.GetOnePiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.GetOnePiece(i, j) + " ");
                    }    
                }
                Console.WriteLine();
            }
        }
    }
}
