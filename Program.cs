﻿/*
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


using System;


namespace Slot_Machine // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // declare numbers of rows and columns
            const int ROWS = 3;
            const int COLUMNS = 3;
            const int DIAGONALS = 2;
            //declare range of numbers that should be displayed randomly
            const int MAX = 9;
            const int MIN = 1;
            // declare bonus win for multiple matching rows/columns
            const int BONUS_WIN = 10;
            // declare characters that user should press for choosing rows, diagonals, columns, yes or no
            const char COLUMNS_CHAR = 'c';
            const char ROWS_CHAR = 'r';
            const char DIA_CHAR = 'd';
            const char YES_CHAR = 'y';
            const char NO_CHAR = 'n';
            // cashbox win / cashbox loss constants
            const int CASHBOX_WIN = 2;
            const int CASHBOX_LOSS = -1;
            const int PLAYING_COST = -1;
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
            // declare number of matching rows/columns that later will change depending on the progression of the game

            int numberOfMatches = 0;

            bool winningMatchFound = true;
            bool winningMatchFoundLeft = true;
            bool winningMatchFoundRight = true;
            
            Console.Write($"you bet {userBet}$ ");
            Console.WriteLine($"your total amount of money is {cashBox}$");


            while (true) // while loop is used for repeating a block of code until the user blocks it
            {
                numberOfMatches = 0; // reset number of matches

                // 1 - fill 2 dimensional array with random slotNumbers
                //-----------------------------------------------------

                for (int col = 0; col < slotNumbers.GetLength(0); col++)
                {
                    for (int row = 0; row < slotNumbers.GetLength(1); row++)
                    {
                        int computerChoice = random.Next(MIN, MAX + 1);
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
                }
            }
        }
    }
