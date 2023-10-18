/*
Design a game where the user can play a make believe slot machine. 
The user will be asked to make a wager to play various lines in a 3 x 3 grid. 
They can play center line, all three horizontal lines, all vertical lines and diagonals.
For instance the user can enter $3 dollars and play all three horizontal lines. 
If the top line hits a winning combination, they earn $1 dollar for that line.

Tips: The mention of a grid here should be a dead giveaway that you need a 2D array. 
You will also need functionality that can check a horizontal line, a vertical line and a diagonal. 
Depending on the number of lines they play, you may need to execute all three of these statements one or multiple times to look for winning lines. 
If they are playing three lines, you would call your horizontal line check function three times... 
one for the top row, one for the center row and one for the bottom row. 
Each of these row checking algorithms will then need to look for winning combinations. 
The result is then dumped into the player’s money total. 
As for the mechanism to determine what the wheels produce per spin, use a random number generating function.

- fill array with random numbers
- output that array
- check if middle row is all the same --> if numbers[0][1] == numbers[1][1]
- output win / lose
- keep track of money
 */
// if arr1[0][1] == arr2[0][1]


using System;

namespace Slot_Machine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int ROWS = 3;
            const int COLUMNS = 3;
            Random random = new Random();

            Console.WriteLine("\nSlot machine! place your bet! every spin costs 1$, if you win you get 1$!");
            int[,] numbers = new int[ROWS,COLUMNS]; // define the exact number of rows and columns
            int userBet = Int32.Parse(Console.ReadLine()); // Int32.Parse() method is used to convert the string to a number.
            
            Console.Write($"you bet {userBet}$ ");


            while(true) // while loop is used for repeating a block of code until the user blocks it
            {

                // 1 - fill 2 dimensional array with random numbers
                //-----------------------------------------------------
                for (int col = 0; col < numbers.GetLength(0); col++)
                {
                    for (int row = 0; row < numbers.GetLength(1); row++)
                    {
                        int computerChoice = random.Next(1, 10);
                        numbers[col, row] = computerChoice;
                        //numbers.ToString();
                        //Console.Write(numbers[col, row]);

                    }
                }
                //-----------------------------------------------------


                // 2 - display array in rows and columns
                //-----------------------------------------------------
                for(int col = 0;  col < numbers.GetLength(0); col++)
                {
                    Console.WriteLine();

                    for (int row = 0; row < numbers.GetLength(1); row++)
                    {
                        Console.Write(' ');
                        Console.Write(numbers[col, row]);
                        Console.Write(' ');
                    }
                }
                //----------------------------------------------------

                // 3 - check if middle row is all the same

                for (int check = 0; check < numbers.GetLength(0); check++)
                {
                    for(int match = 0; match < numbers.GetLength(1); match++)
                    {
                        if (numbers[check, match] == numbers[check, match] + 1)
                        {
                            Console.WriteLine("you win!");
                        }
                    }
                }

                // repeat the game 
                //---------------------------------------------------- 
                Console.WriteLine("\nDo you want to play again? y/n");
                string userAnswer = Console.ReadLine();

                if (userAnswer == "n") 
                {
                    break;
                }
                //----------------------------------------------------
            }
        }
    }
}