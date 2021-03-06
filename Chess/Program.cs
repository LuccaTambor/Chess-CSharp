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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);


                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        match.ValidOriginPosition(origin);


                        bool[,] possibleMoviments = match.MatchBoard.GetOnePiece(origin).PossibleMoviments();

                        Console.Clear();
                        Screen.printBoard(match.MatchBoard, possibleMoviments);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadChessPosition().ToPosition();
                        match.ValidDestinyPosition(origin, destiny);

                        match.MakePlay(origin, destiny);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
