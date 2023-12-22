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
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Text;

namespace Slot_Machine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declare numbers of rows and columns
            const int ROWS = 3;
            const int COLUMNS = 3;
            //declare range of numbers that should be displayed randomly
            const int MAX = 9;
            const int MIN = 1;
            // declare bonus win for multiple matching rows/columns
            const int BONUS_WIN = 10;
            // declare characters that user should press for choosing rows or columns
            const char COLUMNS_CHAR = 'c';
            const char ROWS_CHAR = 'r';
            const char DIA_CHAR = 'd';
            // creates random number
            Random random = new Random();
            //game start initial statement
            string initialStatement = "\nSlot machine! place your bet! every spin costs 1$, if you win you get 1$!";
            Console.WriteLine(initialStatement);
            //the user here inputs the amount of money that wants to bet
            int userBet = Int32.Parse(Console.ReadLine()); // Int32.Parse() method is used to convert the string to a number.
            int cashBox = userBet;
            // game start second statement
            string userChoiceText = "do you want to play rows (r), columns (c) or diagonals (d)?";
            Console.WriteLine(userChoiceText);
            // read the input from the user
            ConsoleKeyInfo userChoiceKeyInfo = Console.ReadKey(true);
            Char userChoiceChar = userChoiceKeyInfo.KeyChar;
            // initialized array with the slot numbers
            int[,] slotNumbers = new int[ROWS, COLUMNS]; // define the exact number of rows and columns


            // ----- debugging code -----

            slotNumbers[0, 0] = 5; slotNumbers[0, 1] = 4; slotNumbers[0, 2] = 5;


            slotNumbers[1, 0] = 2; slotNumbers[1, 1] = 5; slotNumbers[1, 2] = 9;


            slotNumbers[2, 0] = 5; slotNumbers[2, 1] = 6; slotNumbers[2, 2] = 5;

            // declare number of matching rows/columns that later will change depending on the progression of the game
            int numberOfMatchingRows = 0;
            int numberOfMatchingColumns = 0;
            int numberOfMatches = 0;

            bool winningRowFound = true;
            bool winningMatchFoundLeft = true;
            bool winningMatchFoundRight = true;
            bool winningColFound = true;


            Console.Write($"you bet {userBet}$ ");
            Console.WriteLine($"your total amount of money is {cashBox}$");


            while (true) // while loop is used for repeating a block of code until the user blocks it
            {
                numberOfMatchingRows = 0; //reset wining row count
                numberOfMatchingColumns = 0; // reset winning column count
                numberOfMatches = 0;

                // 1 - fill 2 dimensional array with random slotNumbers
                //-----------------------------------------------------

                /*
                 
                for (int col = 0; col < slotNumbers.GetLength(0); col++)
                {
                    for (int row = 0; row < slotNumbers.GetLength(1); row++)
                    {
                        int computerChoice = random.Next(MIN, MAX + 1);
                        slotNumbers[col, row] = computerChoice;
                    }
                }

                 */

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

                //++++++***** R O W S *******++++

                if (userChoiceChar == ROWS_CHAR)
                {
                    // 3 - check if numbers of a row are all the same

                    Console.WriteLine($"\n \nyour total amount of money is {cashBox}$");

                    for (int rowCheck = 0; rowCheck < slotNumbers.GetLength(0); rowCheck++)
                    {
                        // switch on again
                        winningRowFound = true;

                        for (int colCheck = 0; colCheck < slotNumbers.GetLength(1); colCheck++)
                        {
                            if (slotNumbers[rowCheck, 0] != slotNumbers[rowCheck, colCheck])
                            {
                                winningRowFound = false;
                                break;
                            }
                        }

                        //handling of gameStatus      
                        if (winningRowFound)
                        {
                            numberOfMatchingRows++;
                        }
                    }

                    // 4 - output win / lose

                    if (numberOfMatchingRows == 0)
                    {
                        Console.WriteLine("You Lose!");
                    }
                    else
                    {
                        Console.WriteLine($"You Win! number of matching rows: {numberOfMatchingRows} ");
                    }

                    // 5 - keep track of money

                    if (winningRowFound == true)
                    {
                        cashBox++;
                    }
                    else if (numberOfMatchingRows == 2)
                    {
                        cashBox += BONUS_WIN;
                    }
                    else if (numberOfMatchingRows == 3)
                    {
                        cashBox += (BONUS_WIN * 3);
                    }
                    else
                    {
                        cashBox--;
                    }
                }

                // ++++++***** C O L U M N S *****+++++++

                if (userChoiceChar == COLUMNS_CHAR)
                {
                    // 3 - check if numbers of a row are all the same

                    Console.WriteLine($"\n \nyour total amount of money is {cashBox}$");

                    for (int colCheck = 0; colCheck < slotNumbers.GetLength(0); colCheck++)
                    {
                        // switch on again
                        winningColFound = true;

                        for (int rowCheck = 0; rowCheck < slotNumbers.GetLength(1); rowCheck++)
                        {
                            if (slotNumbers[0, colCheck] != slotNumbers[rowCheck, colCheck])
                            {
                                winningColFound = false;
                                break;
                            }
                        }

                        //handling of gameStatus      


                        if (winningColFound)
                        {
                            numberOfMatchingColumns++;
                        }
                    }

                    // 4 - output win / lose

                    if (numberOfMatchingColumns == 0)
                    {
                        Console.WriteLine("You Lose!");

                    }
                    else
                    {
                        Console.WriteLine($"You Win! number of matching columns: {numberOfMatchingColumns} ");
                    }

                    // 5 - keep track of money

                    if (winningColFound == true)
                    {
                        cashBox++;
                    }
                    else if (numberOfMatchingColumns == 2)
                    {
                        cashBox += BONUS_WIN;
                    }
                    else if (numberOfMatchingColumns == 3)
                    {
                        cashBox += (BONUS_WIN * 3);

                    }
                    else
                    {
                        cashBox--;
                    }
                }


                // +++++***** D I A G O N A L S *******++++++
                if (userChoiceChar == DIA_CHAR)
                {
                    Console.WriteLine($"\n \nyour total amount of money is {cashBox}$");
                    // +++++***** L     E     F   T *******++++++
                    for (int i = 0; i < slotNumbers.GetLength(0); i++)
                    {
                        winningMatchFoundLeft = true;

                        if (slotNumbers[0, 0] != slotNumbers[i, i])
                        {
                            winningMatchFoundLeft = false;
                            break;
                        }
                    }
                    // +++++***** R   I  G   H    T *******++++++
                    for (int i = 0; i < slotNumbers.GetLength(1); i++)
                    {
                        winningMatchFoundRight = true;

                        int columnIndex = slotNumbers.GetLength(1) - i - 1;

                        if (slotNumbers[0, slotNumbers.GetLength(1) - 1] != slotNumbers[i, columnIndex])
                        {
                            winningMatchFoundRight = false;
                            break;
                        }
                    }


                    if (winningMatchFoundLeft == true)

                    {
                        numberOfMatches++;
                    }
                    if (winningMatchFoundRight == true)

                    {
                        numberOfMatches++;
                    }
                    // 4 - output win / lose

                    if (numberOfMatches == 0)
                    {
                        Console.WriteLine("You Lose!");

                    }
                    else
                    {
                        Console.WriteLine($"You Win! number of matching diagonals: {numberOfMatches} ");
                    }

                    // 5 - keep track of money

                    if (winningMatchFoundLeft == true)
                    {
                        cashBox++;
                    }
                    if (winningMatchFoundRight == true)
                    {
                        cashBox++;
                    }
                    else if (numberOfMatches == 2)
                    {
                        cashBox += BONUS_WIN * 3;
                    }
                    else
                    {
                        cashBox--;
                    }
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
                    Console.WriteLine(userChoiceText);
                    ConsoleKeyInfo userNumberChoice = Console.ReadKey(true);
                    userChoiceChar = userNumberChoice.KeyChar;


                }
                else if (cashBox == 0)
                {

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