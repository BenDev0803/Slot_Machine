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

- fill array with random slotNumbers
- output that array
- check if middle row is all the same
- output win / lose
- keep track of money
 */
// if arr1[0][1] == arr2[0][1]


using System;
using System.Security.Cryptography;
using System.Text;

namespace Slot_Machine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            const int ROWS = 3;
            const int COLUMNS = 3;
            const int MAX = 9;
            const int MIN = 1;
            Random random = new Random();
            string initialStatement = "\nSlot machine! place your bet! every spin costs 1$, if you win you get 1$!";
            Console.WriteLine(initialStatement);
            int[,] slotNumbers = new int[ROWS, COLUMNS]; // define the exact number of rows and columns
            int userBet = Int32.Parse(Console.ReadLine()); // Int32.Parse() method is used to convert the string to a number.
            int cashBox = userBet;
            bool gameStatus = false;
            Console.Write($"you bet {userBet}$ ");
            Console.WriteLine($"your total amount of money is {cashBox}$");


            while (true) // while loop is used for repeating a block of code until the user blocks it
            {

                // 1 - fill 2 dimensional array with random slotNumbers
                //-----------------------------------------------------
                for (int col = 0; col < slotNumbers.GetLength(0); col++)
                {
                    for (int row = 0; row < slotNumbers.GetLength(1); row++)
                    {
                        int computerChoice = random.Next(MIN, MAX +1);
                        slotNumbers[col, row] = computerChoice;
                    }
                }
                //-----------------------------------------------------

                // 2 - display array in rows and columns
                //-----------------------------------------------------
                for (int col = 0; col < slotNumbers.GetLength(0); col++)
                {
                    Console.WriteLine();

                    for (int row = 0; row < slotNumbers.GetLength(1); row++)
                    {
                        Console.Write(' ');
                        Console.Write(slotNumbers[col, row]);
                        Console.Write(' ');
                    }
                    Console.Write(' ');
                }
                //----------------------------------------------------

                // 3 - check if numbers of a row are all the same

                Console.WriteLine($"\n \nyour total amount of money is {cashBox}$");

                for (int rowCheck = 0; rowCheck < slotNumbers.GetLength(0); rowCheck++)
                {
                    if (slotNumbers[rowCheck, 0] == slotNumbers[rowCheck, 1] && slotNumbers[rowCheck, 0] == slotNumbers[rowCheck, 2])
                    {
                        gameStatus = true;
                        break;
                    }
                    else
                    {
                        gameStatus = false;
                    }
                }
                // 4 - output win / lose

                if (gameStatus == true)
                {
                    Console.WriteLine("You Win!");
                }
                else
                {

                    Console.WriteLine("You lose!");
                }

                // 5 - keep track of money

                if(gameStatus == true)
                {
                    cashBox++;
                }
                else
                {
                    cashBox--;
                }

                //final part of game

                string userAnswer;

                if (cashBox > 0) 
                {
                    Console.WriteLine("\nDo you want to play again? y/n");
                    userAnswer = Console.ReadLine();
                    if (userAnswer == "n")
                    {
                        break;
                    }
                }

                else if(cashBox == 0){
                    
                    Console.WriteLine("You don't have money! do you want to bet again? y/n");
                    
                    string userConfirmation = Console.ReadLine();

                    if (userConfirmation == "y")
                    {
                        Console.WriteLine($"amount that you want to bet ");
                        int lossConfirmation = Int32.Parse(Console.ReadLine());
                        cashBox = lossConfirmation;
                    }
                    else
                    {
                        break;
                    }
                }
                Console.Clear();
            }
        }
    }
}