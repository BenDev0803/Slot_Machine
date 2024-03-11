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
            UI_Design.printInitialStatement(initialStatement);
            //the user here inputs the amount of money that wants to bet
            int userBet = Int32.Parse(Console.ReadLine()); // Int32.Parse() method is used to convert the string to a number.
            string youBet = "you bet " + userBet;
            UI_Design.printYouBet(youBet);
            int cashBox = userBet;
            string totalAmountMoney = "your total amount of money is " + cashBox;
            UI_Design.printTotalAmountMoney(totalAmountMoney);
            // game start second statement
            string userChoiceText = "do you want to play rows (r), columns (c) or diagonals (d)?";
            UI_Design.printuserChoiceText(userChoiceText);
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

                UI_Design.displayArrayInRowsAndColumns(slotNumbers);
            }
        }
    }
}
