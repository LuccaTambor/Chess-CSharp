using System;
using BoardLayer;
using ChessLayer;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ChessMatch match = new ChessMatch();

                while(!match.MatchFinished)
                {
                    Console.Clear();
                    Screen.printBoard(match.MatchBoard);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] possibleMoviments = match.MatchBoard.GetOnePiece(origin).PossibleMoviments();

                    Console.Clear();
                    Screen.printBoard(match.MatchBoard, possibleMoviments);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    match.ExecuteMovement(origin, destiny);

                }
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
