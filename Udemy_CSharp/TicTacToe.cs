using System.Security.Cryptography;

namespace Udemy_CSharp
{
    public class TicTacToe
    {
        public static void Graj()
        {
            //Define board
            string[,] board =
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };

            //Define starting player sign
            string playerSign = "X";

            //Main loop to play
            do
            {
                //Print current board status
                PrintBoard(board);

                //Ask to choose a field to place a mark
                Console.WriteLine($"Graczu {playerSign}: Wybierz pole!");

                //check if choosen field is valid
                string choosenField = Console.ReadLine();
                bool fieldFound = false;
                for (int i = 0; i < board.GetLength(0); i++)
                    for (int j = 0; j < board.GetLength(1); j++)
                        if (board[i, j] == choosenField)
                        {
                            board[i, j] = playerSign;
                            fieldFound = true;
                        }

                //If no, start the loop again
                if (!fieldFound)
                    continue;

                //Check if board is solved
                if (Checker(board))
                {
                    Console.Clear();
                    Console.WriteLine($"Winner is {playerSign}\n");
                    PrintBoard(board);
                    break;
                }

                //If board is not solved (loop not terminated above) - change player sign and clear console before next loop iteration
                if (playerSign == "X")
                    playerSign = "O";
                else
                    playerSign = "X";

                Console.Clear();

            } while (true);
        }

        public static void PrintBoard(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                    Console.Write(board[i, j] + "    ");

                Console.WriteLine("\n");
            }
        }

        public static bool Checker(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
                if (board[i, 0] == board[i, 1] & board[i, 0] == board[i, 2])
                    return true;

            for (int j = 0; j < board.GetLength(1); j++)
                if (board[0, j] == board[1, j] & board[0, j] == board[2, j])
                    return true;

            if (board[0, 0] == board[1, 1] & board[0, 0] == board[2, 2])
                return true;

            if (board[2, 0] == board[1, 1] & board[2, 0] == board[2, 0])
                return true;

            return false;
        }
    }
}