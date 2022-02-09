using System;
using BoardLayer;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(8, 8);

            Screen.printBoard(b);

            Console.ReadLine();
        }
    }
}
