using System;

namespace TicTacToe
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Field numbers
            char[] arr = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char playerInput;
            char computerInput;

            Console.WriteLine("Enter any number to begin!");

            // Shows board
            Board();

            while (true)
            {
                // Converts players input to char
                playerInput = Convert.ToChar(Console.ReadLine());

                // Checks if input is a number and if field is free
                if (CheckInput())
                {
                    Console.Clear();

                    // Finds entered field
                    // Finds entered field
                    field(playerInput);

                    // Checks for a winner or full board
                    if (GetWinner())
                    {
                        break;
                    }
                    else if (FullBoard())
                    {
                        break;
                    }

                    // Gets random field thats available
                    computerInput = Computer();

                    // Finds entered field
                    field(computerInput);

                    // Checks for a winner or full board
                    if (GetWinner())
                    {
                        break;
                    }
                    else if (FullBoard())
                    {
                        break;
                    }
                }
                Board();
            }

            // Board method
            void Board()
            {
                // Message and rules
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Welcome.\nPlayer1 = X and Player2 = O\nPick a field by entering its number");
                Console.WriteLine("------------------------------------\n");
                Console.ResetColor();

                Console.WriteLine($" {arr[0]} | {arr[1]} | {arr[2]}");
                Console.WriteLine($"---|---|--- ");
                Console.WriteLine($" {arr[3]} | {arr[4]} | {arr[5]}");
                Console.WriteLine($"---|---|--- ");
                Console.WriteLine($" {arr[6]} | {arr[7]} | {arr[8]}\n");
            }

            // Finds next player to pick field
            char CheckPlayer()
            {
                int player1Turns = 0;
                int player2Turns = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 'X')
                    {
                        player1Turns++;
                    }
                    else if (arr[i] == 'O')
                    {
                        player2Turns++;
                    }
                }

                if (player1Turns <= player2Turns)
                {
                    return 'X';
                }
                else
                {
                    return 'O';
                }
            }

            // Method return available number
            char Computer()
            {
                Random random = new Random();
                computerInput = char.Parse(Convert.ToString(random.Next(1, 10)));

                while (true)
                {
                    if (arr[int.Parse(computerInput.ToString()) - 1] == 'X' || arr[int.Parse(computerInput.ToString()) - 1] == 'O')
                    {
                        computerInput = char.Parse(Convert.ToString(random.Next(1, 10)));
                    }
                    else
                    {
                        break;
                    }
                }
                return computerInput;
            }

            // Checks for a winner
            bool GetWinner()
            {
                // Ways to win -->
                if (arr[0] == arr[1] && arr[1] == arr[2] || arr[3] == arr[4] && arr[4] == arr[5] || arr[6] == arr[7] && arr[7] == arr[8] || arr[0] == arr[3] && arr[3] == arr[6] || arr[1] == arr[4] && arr[4] == arr[7] || arr[2] == arr[5] && arr[5] == arr[8] || arr[0] == arr[4] && arr[4] == arr[8] || arr[2] == arr[4] && arr[4] == arr[6])
                {
                    int player1Turns = 0;
                    int player2Turns = 0;
                    string winner;

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] == 'X')
                        {
                            player1Turns++;
                        }
                        else if (arr[i] == 'O')
                        {
                            player2Turns++;
                        }
                    }

                    if (player1Turns > player2Turns)
                    {
                        winner = "Player1 X";
                    }
                    else
                    {
                        winner = "Player2 O";
                    }
                    Board();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The winner is {winner}");
                    Console.ResetColor();

                    return true;
                }
                else
                {
                    return false;
                }
            }

            // Checks if bord is full whitout any winner
            bool FullBoard()
            {
                int full = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 'X' || arr[i] == 'O')
                    {
                        full++;
                    }
                }

                if (full == 9)
                {
                    Board();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The game was even");
                    Console.ResetColor();
                    return true;
                }
                else
                {
                    return false;
                }
            }

            // Checks if input/field is taken, and checks if input contains characters
            bool CheckInput()
            {
                if (char.IsLetter(playerInput))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Only numbers to pick a field");
                    Console.ResetColor();
                    return false;
                }
                else if (arr[int.Parse(playerInput.ToString()) - 1] == 'X' || arr[int.Parse(playerInput.ToString()) - 1] == 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Field is allready taken!");
                    Console.ResetColor();

                    return false;
                }
                else
                {
                    return true;
                }
            }

            // Finds entered field and places X or O
            void field(char input)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (input == arr[i])
                    {
                        arr[i] = CheckPlayer();
                    }
                }
            }
        }
    }
}