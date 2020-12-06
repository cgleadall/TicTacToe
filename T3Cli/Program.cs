using System;
using T3Models;
using T3Models.Exceptions;

namespace T3Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to T3...");

            var board = new Board();

            Console.WriteLine("");
            var ch = '0';
            var round = 1;

            Player currentPlayer = Player.O;

            while (ch != 'x')
            {
                WriteBoard(board.CurrentBoard);

                currentPlayer = (round % 2 == 0) ? Player.O : Player.X;

                Console.WriteLine($"Player {currentPlayer.ToString()}, Please choose your spot, or X to quit.");

                ch = Console.ReadKey().KeyChar;
                if( ch == 'X'){
                    ch = 'x';
                    continue;
                }
                try{
                    board.TakeTurn(currentPlayer, Int32.Parse(ch.ToString()));
                    round++;
                } catch (NotYourTurnException ){
                    Console.WriteLine();
                    Console.WriteLine($"It is not player {currentPlayer.ToString()}'s turn.");
                    Console.WriteLine();
                    round++;
                }
                catch( PositionNotEmptyException ){
                    Console.WriteLine();
                    Console.WriteLine($"Position, {ch}, is not empty, please try again.");
                    Console.WriteLine();
                } catch (FormatException ){
                    Console.WriteLine();
                    Console.WriteLine($"{ch}, is not a valid spot, please try again.");
                    Console.WriteLine();
                    
                }
            }
        }

        public static void WriteBoard(Player[] board){
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($" {GetCellValue(board,0)} | {GetCellValue(board, 1)} | {GetCellValue(board, 2)} ");
            Console.WriteLine( "---+---+---");
            Console.WriteLine($" {GetCellValue(board,3)} | {GetCellValue(board, 4)} | {GetCellValue(board, 5)} ");
            Console.WriteLine( "---+---+---");
            Console.WriteLine($" {GetCellValue(board,6)} | {GetCellValue(board, 7)} | {GetCellValue(board, 8)} ");

            Console.WriteLine();
            Console.WriteLine();
        }

        private static string GetCellValue(Player[] board, int position){
            if( board[position] == Player.None) return $"{position+1}";
            return $"{board[position].ToString()}";
        }
    }
}
